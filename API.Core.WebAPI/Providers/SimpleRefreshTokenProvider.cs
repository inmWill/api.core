using System;
using System.Threading.Tasks;
using API.Core.Repository.Models.Identity;
using API.Core.Repository.Repositories;
using API.Core.Utils.Cryptography;
using Microsoft.Owin.Security.Infrastructure;
using NLog;

namespace API.Core.Rest.WebAPI.Providers
{
    public class SimpleRefreshTokenProvider : IAuthenticationTokenProvider
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public void Create(AuthenticationTokenCreateContext context)
        {
            throw new NotImplementedException();
        }

        public async Task CreateAsync(AuthenticationTokenCreateContext context)
        {
            try
            {
                var clientid = context.Ticket.Properties.Dictionary["as:client_id"];

                if (string.IsNullOrEmpty(clientid))
                {
                    return;
                }

                var refreshTokenId = Guid.NewGuid().ToString("n");
                var refreshTokenLifeTime = context.OwinContext.Get<string>("as:clientRefreshTokenLifeTime");

                var token = new RefreshToken()
                {
                    Id = HashHelper.GetHash(refreshTokenId),
                    ClientId = clientid,
                    Subject = context.Ticket.Identity.Name,
                    IssuedUtc = DateTime.UtcNow,
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(Convert.ToDouble(refreshTokenLifeTime))
                };

                context.Ticket.Properties.IssuedUtc = token.IssuedUtc;
                context.Ticket.Properties.ExpiresUtc = token.ExpiresUtc;

                token.ProtectedTicket = context.SerializeTicket();

                bool result;
                using (AuthRepository authService = new AuthRepository())
                {
                    result = authService.AddRefreshToken(token);
                }



                if (result)
                {
                    context.SetToken(refreshTokenId);
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error creating token: " + ex.InnerException);
            }
        }

        public void Receive(AuthenticationTokenReceiveContext context)
        {
            throw new NotImplementedException();
        }

        public async Task ReceiveAsync(AuthenticationTokenReceiveContext context)
        {
            try
            {

                var hashedTokenId = HashHelper.GetHash(context.Token);


                using (AuthRepository authService = new AuthRepository())
                {
                    var refreshToken = authService.FindRefreshToken(hashedTokenId);                   

                    if (refreshToken != null)
                    {
                        //Get protectedTicket from refreshToken class
                        context.DeserializeTicket(refreshToken.ProtectedTicket);
                        //remove token from db 
                        var result = authService.RemoveRefreshToken(hashedTokenId);
                    }
                }

            }
            catch (Exception ex)
            {
                Logger.Error("Error receiving token: " + ex.InnerException);
            }
        }
    }
}