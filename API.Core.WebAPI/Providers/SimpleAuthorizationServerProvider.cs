using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using API.Core.Domain.Enums;
using API.Core.Repository.Models.Identity;
using API.Core.Repository.Repositories;
using API.Core.Utils.Cryptography;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;

namespace API.Core.Rest.WebAPI.Providers
{
    public class SimpleAuthorizationServerProvider : OAuthAuthorizationServerProvider, ISimpleAuthorizationServerProvider
    {
        //private readonly IAccountService _authService;
        //public SimpleAuthorizationServerProvider(IAccountService authService)
        //{
        //    _authService = authService;
        //}

        public override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {

            string clientId = string.Empty;
            string clientSecret = string.Empty;
            AuthorizedClient authorizedClient = null;

            if (!context.TryGetBasicCredentials(out clientId, out clientSecret))
            {
                context.TryGetFormCredentials(out clientId, out clientSecret);
            }

            if (context.ClientId == null)
            {
                //Force ignore authorized client requirement.
                //switch comments to let any client in.
                //context.Validated();
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            using (AuthRepository _repo = new AuthRepository())
                authorizedClient = _repo.FindAuthorizedClient(context.ClientId);

            if (authorizedClient == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

            // force confidential clients does not apply to client facing systems
            if (authorizedClient.ApplicationType == ApplicationTypes.NativeConfidential)
            {
                if (string.IsNullOrWhiteSpace(clientSecret))
                {
                    context.SetError("invalid_clientId", "Client secret should be sent.");
                    return Task.FromResult<object>(null);
                }
                else
                {
                    if (authorizedClient.Secret != HashHelper.GetHash(clientSecret))
                    {
                        context.SetError("invalid_clientId", "Client secret is invalid.");
                        return Task.FromResult<object>(null);
                    }
                }
            }

            if (!authorizedClient.Active)
            {
                context.SetError("invalid_clientId", "Client is inactive.");
                return Task.FromResult<object>(null);
            }

            context.OwinContext.Set<string>("as:clientAllowedOrigin", authorizedClient.AllowedOrigin);
            context.OwinContext.Set<string>("as:clientRefreshTokenLifeTime", authorizedClient.RefreshTokenLifeTime.ToString());

            context.Validated();
            return Task.FromResult<object>(null);
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {

            //var allowedOrigin = context.OwinContext.Get<string>("as:clientAllowedOrigin") ?? "*";

            // context.OwinContext.Response.Headers.Add("Access-Control-Allow-Origin", new[] { allowedOrigin });

            //    AppUser user = _authService.FindUser(context.UserName, context.Password);
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            AppUser user = new AppUser();

            using (AuthRepository _repo = new AuthRepository())
            {
                user = _repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                user.UserRoles = _repo.GetUserRoles(user.Id);


                if (user.Enabled == false)
                {
                    context.SetError("invalid_grant", "The account is disabled.");
                    return;
                }


            }

            identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            identity.AddClaim(new Claim("sub", context.UserName));
            foreach (string role in user.UserRoles)
            {
                identity.AddClaim(new Claim(ClaimTypes.Role, role));
            }




            var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    { 
                        "as:client_id", context.ClientId ?? string.Empty
                    },
                    { 
                        "displayName", user.Firstname + ' ' + user.Lastname
                    },
                    {
                        "userName", user.UserName
                    },
                    {
                        "userRoles", string.Join(",",identity.Claims.Where(c=> c.Type == ClaimTypes.Role).Select(c => c.Value).ToArray())
                    }
                });

            var ticket = new AuthenticationTicket(identity, props);
            context.Validated(ticket);

        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        public override Task GrantRefreshToken(OAuthGrantRefreshTokenContext context)
        {
            var originalClient = context.Ticket.Properties.Dictionary["as:client_id"];
            var currentClient = context.ClientId;

            if (originalClient != currentClient)
            {
                context.SetError("invalid_clientId", "Refresh token is issued to a different clientId.");
                return Task.FromResult<object>(null);
            }

            var newIdentity = new ClaimsIdentity(context.Ticket.Identity);
            newIdentity.AddClaim(new Claim("newClaim", "newValue"));

            var newTicket = new AuthenticationTicket(newIdentity, context.Ticket.Properties);
            context.Validated(newTicket);

            return Task.FromResult<object>(null);
        }
    }
}