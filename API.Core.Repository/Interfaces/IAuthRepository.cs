using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using API.Core.Repository.Models.Identity;
using Microsoft.AspNet.Identity;

namespace API.Core.Repository.Interfaces
{
    /// <summary>
    /// Auth repository uses a custom implementation that is different from the standard CRUD repository
    /// TODO: Embrace Async and convert prior implementation to loosly coupled version
    /// </summary>
    public interface IAuthRepository : IDisposable
    {
        IdentityResult RegisterUser(AppUser appUser, string password);
        AppUser FindUser(string userName, string password);

        IEnumerable<AppUser> FindAllUsers();

        bool UpdateUser(AppUser user);

        bool UpdateUserPassword(AppUser user, string oldPassword, string newPassword);

        AppUser FindUserByUsername(string userName);

        AppUser FindUserByUserId(string userId);

        bool CheckUsernameAvailability(string userName);

        IEnumerable<string> GetUserRoles(string userId);
        
        Task<IdentityResult> RegisterUserAsync(AppUser appUser, string password);
        Task<AppUser> FindUserAsync(string userName, string password);

        AuthorizedClient FindAuthorizedClient(string authorizedClientId);

        bool AddRefreshToken(RefreshToken token);
        bool RemoveRefreshToken(string refreshTokenId);
        bool RevokeAccess(string userName);
        RefreshToken FindRefreshToken(string refreshTokenId);

        Task<bool> AddRefreshTokenAsync(RefreshToken token);
        Task<bool> RemoveRefreshTokenAsync(string refreshTokenId);
        Task<RefreshToken> FindRefreshTokenAsync(string refreshTokenId);

        List<RefreshToken> GetAllRefreshTokens();
    }
}