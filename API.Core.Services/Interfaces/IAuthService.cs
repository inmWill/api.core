using System.Collections.Generic;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.UserIdentity;

namespace API.Core.Service.Interfaces
{
    public interface IAuthService
    {
        bool RegisterUser(AppUser user);
        bool CheckUsernameAvailability(string username);
        bool RegisterClientEEUser(AppUserRegistrationModel appUserRegistrationModel);
        bool DisableUser(AppUser user);
        bool EnableUser(AppUser user);
        IEnumerable<AppUser> FindAllUsers();
        AppUser FindUser(string userName, string password);
        AppUser FindActiveUserProfile(string userName);
        AuthorizedClient FindAuthorizedClient(string authorizedClientId);
        bool AddRefreshToken(RefreshToken token);
        bool RemoveRefreshToken(string refreshTokenId);
        RefreshToken FindRefreshToken(string refreshTokenId);
         
        
    }
}
