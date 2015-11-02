using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using API.Core.Repository.DbContexts;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Identity;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;

namespace API.Core.Repository.Repositories
{
    /// <summary>
    /// AuthRepository interacts with 3 tables and kinda violates the SRP
    /// The tables and logic were so tightly coupled and small that I didn't see a point in splitting them into 3 different repos
    /// TODO: Convert fully to ASYNC
    /// </summary>
    public class AuthRepository : IAuthRepository
    {
        private readonly APICoreContext _dbContext;

        private readonly UserManager<AppUser> _userManager;

        public AuthRepository()
        {
            _dbContext = new APICoreContext();
            _dbContext.Configuration.ProxyCreationEnabled = false;
            _dbContext.Configuration.LazyLoadingEnabled = false;
            var store = new UserStore<AppUser>(_dbContext);
            _userManager = new UserManager<AppUser>(store);
        }

        public IdentityResult RegisterUser(AppUser appUser, string password)
        {
            appUser.Id = Guid.NewGuid().ToString();
            appUser.Enabled = true;
            var result = _userManager.Create(appUser, password);
            _userManager.AddToRole(appUser.Id, "User");
            return result;
        }

        public async Task<IdentityResult> RegisterUserAsync(AppUser appUser, string password)
        {
            appUser.Id = Guid.NewGuid().ToString();
            appUser.Enabled = true;
            var result = await _userManager.CreateAsync(appUser, password);
            _userManager.AddToRole(appUser.Id, "User");
            return result;
        }

        public AppUser FindUser(string userName, string password)
        {
            var user = _userManager.Find(userName, password);

            return user;
        }

        public IEnumerable<AppUser> FindAllUsers()
        {
            var users = _userManager.Users.ToList();
            return users;
        }

        public bool CheckUsernameAvailability(string userName)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.UserName == userName);

            if (user == null)
                return true;

            return false;
        }

        public AppUser FindUserByUsername(string userName)
        {
            var user = _userManager.FindByName(userName);
            return user;
        }

        public bool UpdateUser(AppUser user)
        {

            var result = _userManager.Update(user);
            return result.Succeeded;
        }

        public IEnumerable<string> GetUserRoles(string userId)
        {
            return _userManager.GetRoles(userId);
        }

        public async Task<AppUser> FindUserAsync(string userName, string password)
        {
            var user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public AuthorizedClient FindAuthorizedClient(string authorizedClientId)
        {
            var authorizedClient = _dbContext.AuthorizedClients.Find(authorizedClientId);

            return authorizedClient;
        }




        // TODO: Move tokens into their own repo


        public bool AddRefreshToken(RefreshToken token)
        {
            if (token != null)
            {
                var existingToken = _dbContext.RefreshTokens.SingleOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

                if (existingToken != null)
                {
                    RemoveRefreshToken(existingToken);
                }

                _dbContext.RefreshTokens.Add(token);

                return _dbContext.SaveChanges() > 0;
            }
            return false;
        }

        public async Task<bool> AddRefreshTokenAsync(RefreshToken token)
        {

            var existingToken = _dbContext.RefreshTokens.FirstOrDefault(r => r.Subject == token.Subject && r.ClientId == token.ClientId);

            if (existingToken != null)
            {
                await RemoveRefreshTokenAsync(existingToken);
            }

            _dbContext.RefreshTokens.Add(token);

            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool RevokeAccess(string userName)
        {
            var existingToken = _dbContext.RefreshTokens.FirstOrDefault(r => r.Subject == userName);

            return existingToken != null && RemoveRefreshToken(existingToken.Id);
        }

        public bool RemoveRefreshToken(string refreshTokenId)
        {
            var refreshToken = _dbContext.RefreshTokens.Find(refreshTokenId);

            if (refreshToken == null) return false;
            _dbContext.RefreshTokens.Remove(refreshToken);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> RemoveRefreshTokenAsync(string refreshTokenId)
        {
            var refreshToken = await _dbContext.RefreshTokens.FindAsync(refreshTokenId);

            if (refreshToken == null) return false;
            _dbContext.RefreshTokens.Remove(refreshToken);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public bool RemoveRefreshToken(RefreshToken refreshToken)
        {
            _dbContext.RefreshTokens.Remove(refreshToken);
            return _dbContext.SaveChanges() > 0;
        }

        public async Task<bool> RemoveRefreshTokenAsync(RefreshToken refreshToken)
        {
            _dbContext.RefreshTokens.Remove(refreshToken);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public RefreshToken FindRefreshToken(string refreshTokenId)
        {
            var refreshToken = _dbContext.RefreshTokens.Find(refreshTokenId);

            return refreshToken;
        }

        public async Task<RefreshToken> FindRefreshTokenAsync(string refreshTokenId)
        {
            var refreshToken = await _dbContext.RefreshTokens.FindAsync(refreshTokenId);

            return refreshToken;
        }

        public List<RefreshToken> GetAllRefreshTokens()
        {
            return _dbContext.RefreshTokens.ToList();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
            _userManager.Dispose();

        }
    }
}
