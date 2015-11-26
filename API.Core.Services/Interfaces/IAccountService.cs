using System.Collections.Generic;
using API.Core.Domain.Models.EditModels;
using API.Core.Domain.Models.UserIdentity;
using Microsoft.AspNet.Identity;

namespace API.Core.Service.Interfaces
{
    public interface IAccountService
    {
        IdentityResult RegisterUser(AppUser user);
        bool CheckUsernameAvailability(string username);
        bool DisableUser(AppUser user);
        bool EnableUser(AppUser user);
        IEnumerable<AppUser> FindAllUsers();
        AppUser FindUser(string userName, string password);
        AppUser FindUser(string userName);
        AuthorizedClient FindAuthorizedClient(string authorizedClientId);
        bool AddRefreshToken(RefreshToken token);
        bool RemoveRefreshToken(string refreshTokenId);
        RefreshToken FindRefreshToken(string refreshTokenId);
        AppUser UpdateUser(AppUserEditModel record, string userName);
    }
}
