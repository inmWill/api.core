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
        /// <summary>
        /// Called to validate that the origin of the request is a registered "client_id", and that the correct credentials for that client are
        ///             present on the request. If the web application accepts Basic authentication credentials, 
        ///             context.TryGetBasicCredentials(out clientId, out clientSecret) may be called to acquire those values if present in the request header. If the web 
        ///             application accepts "client_id" and "client_secret" as form encoded POST parameters, 
        ///             context.TryGetFormCredentials(out clientId, out clientSecret) may be called to acquire those values if present in the request body.
        ///             If context.Validated is not called the request will not proceed further. 
        /// </summary>
        /// <param name="context">The context of the event carries information in and results out.</param>
        /// <returns>
        /// Task to enable asynchronous execution
        /// </returns>
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
                context.SetError("invalid_clientId", "ClientId should be sent.");
                return Task.FromResult<object>(null);
            }

            using (var repo = new AuthRepository())
                authorizedClient = repo.FindAuthorizedClient(context.ClientId);

            if (authorizedClient == null)
            {
                context.SetError("invalid_clientId", string.Format("Client '{0}' is not registered in the system.", context.ClientId));
                return Task.FromResult<object>(null);
            }

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

        /// <summary>
        /// Called when a request to the Token endpoint arrives with a "grant_type" of "password". This occurs when the user has provided name and password
        ///             credentials directly into the client application's user interface, and the client application is using those to acquire an "access_token" and 
        ///             optional "refresh_token". If the web application supports the
        ///             resource owner credentials grant type it must validate the context.Username and context.Password as appropriate. To issue an
        ///             access token the context.Validated must be called with a new ticket containing the claims about the resource owner which should be associated
        ///             with the access token. The application should take appropriate measures to ensure that the endpoint isn’t abused by malicious callers.
        ///             The default behavior is to reject this grant type.
        ///             See also http://tools.ietf.org/html/rfc6749#section-4.3.2
        /// </summary>
        /// <param name="context">The context of the event carries information in and results out.</param>
        /// <returns>
        /// Task to enable asynchronous execution
        /// </returns>
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            AppUser user = new AppUser();

            using (AuthRepository repo = new AuthRepository())
            {
                user = repo.FindUser(context.UserName, context.Password);

                if (user == null)
                {
                    context.SetError("invalid_grant", "The user name or password is incorrect.");
                    return;
                }

                user.UserRoles = repo.GetUserRoles(user.Id);


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

        /// <summary>
        /// Called at the final stage of a successful Token endpoint request. An application may implement this call in order to do any final 
        ///             modification of the claims being used to issue access or refresh tokens. This call may also be used in order to add additional 
        ///             response parameters to the Token endpoint's json response body.
        /// </summary>
        /// <param name="context">The context of the event carries information in and results out.</param>
        /// <returns>
        /// Task to enable asynchronous execution
        /// </returns>
        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }

        /// <summary>
        /// Called when a request to the Token endpoint arrives with a "grant_type" of "refresh_token". This occurs if your application has issued a "refresh_token" 
        ///             along with the "access_token", and the client is attempting to use the "refresh_token" to acquire a new "access_token", and possibly a new "refresh_token".
        ///             To issue a refresh token the an Options.RefreshTokenProvider must be assigned to create the value which is returned. The claims and properties 
        ///             associated with the refresh token are present in the context.Ticket. The application must call context.Validated to instruct the 
        ///             Authorization Server middleware to issue an access token based on those claims and properties. The call to context.Validated may 
        ///             be given a different AuthenticationTicket or ClaimsIdentity in order to control which information flows from the refresh token to 
        ///             the access token. The default behavior when using the OAuthAuthorizationServerProvider is to flow information from the refresh token to 
        ///             the access token unmodified.
        ///             See also http://tools.ietf.org/html/rfc6749#section-6
        /// </summary>
        /// <param name="context">The context of the event carries information in and results out.</param>
        /// <returns>
        /// Task to enable asynchronous execution
        /// </returns>
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