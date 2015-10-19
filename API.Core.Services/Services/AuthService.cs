using System;
using System.Collections.Generic;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.UserIdentity;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Identity;
using API.Core.Repository.Repositories;
using API.Core.Service.Interfaces;
using AutoMapper;
using NLog;
using AppUser = API.Core.Repository.Models.Identity.AppUser;
using AuthorizedClient = API.Core.Domain.Models.UserIdentity.AuthorizedClient;
using RefreshToken = API.Core.Domain.Models.UserIdentity.RefreshToken;

namespace API.Core.Service.Services
{

    ///<summary>
    ///AuthService registers users and other auth duties
    /// Converts between Domain and Repository models.
    /// TODO: consider refactoring to split off token and auth client duties if those items need to scale or reside on a different server
    ///</summary>
    ///<remarks>
    ///This service uses a custom implementation different from the generic BaseServiceApi since we don't want to expose full crud on user identity accounts.
    ///</remarks>
    public class AuthService : IAuthService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly IAuthRepository _authRepository;

        public AuthService(AuthRepository authRepository)
        {
            _authRepository = authRepository;
        }

        public bool RegisterUser(Domain.Models.UserIdentity.AppUser user)
        {
            try
            {
                var appUser = Mapper.Map<AppUser>(user);
                var result = _authRepository.RegisterUser(appUser, user.Password);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                Logger.Error("Error registering user: " + ex.InnerException);
                throw;
            }

        }


        public bool DisableUser(Domain.Models.UserIdentity.AppUser user)
        {
            try
            {
                var status = ChangeUserStatus(user.UserName, false);
                var access = _authRepository.RevokeAccess(user.UserName);
                return status;
            }
            catch (Exception ex)
            {
                Logger.Error("Error deleting user: " + ex.InnerException);
                throw;
            }
        }

        public bool EnableUser(Domain.Models.UserIdentity.AppUser user)
        {
            try
            {
                return ChangeUserStatus(user.UserName, true);
            }
            catch (Exception ex)
            {
                Logger.Error("Error deleting user: " + ex.InnerException);
                throw;
            }
        }

        private bool ChangeUserStatus(string username, bool status)
        {
            var repoUser = _authRepository.FindUserByUsername(username);
            repoUser.Enabled = status;
            var result = _authRepository.UpdateUser(repoUser);
            return result;
        }

        public IEnumerable<Domain.Models.UserIdentity.AppUser> FindAllUsers()
        {
            try
            {
                var users = _authRepository.FindAllUsers();
                foreach (var user in users)
                {
                    user.UserRoles = _authRepository.GetUserRoles(user.Id);
                }

                var userDomain = Mapper.Map<IEnumerable<Domain.Models.UserIdentity.AppUser>>(users);
                
                return userDomain;
            }
            catch (Exception ex)
            {
                Logger.Error("Error finding all users: " + ex.InnerException);
                throw;
            }
        }

        public bool CheckUsernameAvailability(string username)
        {
            try
            {
                return _authRepository.CheckUsernameAvailability(username);
            }
            catch (Exception ex)
            {
                Logger.Error("Error checking username: " + ex.InnerException);
                throw;
            }
        }

        public bool RegisterClientEEUser(AppUserRegistrationModel appUserRegistrationModel)
        {
            try
            {
                var appUserModel = new Domain.Models.UserIdentity.AppUser
                {
                    Enabled = true
                    
                };
                var appUser = Mapper.Map<AppUser>(appUserModel);
                appUser.UserName = appUserRegistrationModel.Username;
                appUser.Email = appUserRegistrationModel.Email;
                var result = _authRepository.RegisterUser(appUser, appUserRegistrationModel.Password);
                return result.Succeeded;
            }
            catch (Exception ex)
            {
                Logger.Error("Error registering user: " + ex.InnerException);
                throw;
            }
        }

        public Domain.Models.UserIdentity.AppUser FindUser(string userName, string password)
        {
            try
            {
                var repoUser = _authRepository.FindUser(userName, password);
                if (repoUser != null)
                {
                    var appUser = Mapper.Map<Domain.Models.UserIdentity.AppUser>(repoUser);
                    appUser.UserRoles = _authRepository.GetUserRoles(repoUser.Id);
                    return appUser;
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                Logger.Error("Error finding user: " + ex.InnerException);
                throw;
            }

        }

        public Domain.Models.UserIdentity.AppUser FindActiveUserProfile(string userName)
        {
            try
            {
                var repoUser = _authRepository.FindUserByUsername(userName);
                var appUser = Mapper.Map<Domain.Models.UserIdentity.AppUser>(repoUser);
                appUser.UserRoles = _authRepository.GetUserRoles(repoUser.Id);
                return appUser;
            }
            catch (Exception ex)
            {
                Logger.Error("Error finding user: " + ex.InnerException);
                throw;
            }

        }

        public AuthorizedClient FindAuthorizedClient(string authorizedClientId)
        {
            try
            {
                var authorizedClient = _authRepository.FindAuthorizedClient(authorizedClientId);
                return Mapper.Map<AuthorizedClient>(authorizedClient);
            }
            catch (Exception ex)
            {
                Logger.Error("Error finding authorized client: " + ex.InnerException);
                throw;
            }
        }

        public bool AddRefreshToken(RefreshToken token)
        {
            try
            {
                var refreshToken = Mapper.Map<Repository.Models.Identity.RefreshToken>(token);
                return _authRepository.AddRefreshToken(refreshToken);
            }
            catch (Exception ex)
            {
                Logger.Error("Error creating refresh token: " + ex.InnerException);
                throw;
            }
        }

        public bool RemoveRefreshToken(string refreshTokenId)
        {
            try
            {
                return _authRepository.RemoveRefreshToken(refreshTokenId);
            }
            catch (Exception ex)
            {
                Logger.Error("Error removing refresh token: " + ex.InnerException);
                throw;
            }
        }

        public RefreshToken FindRefreshToken(string refreshTokenId)
        {
            try
            {
                var refreshToken = _authRepository.FindRefreshToken(refreshTokenId);
                return Mapper.Map<RefreshToken>(refreshToken);
            }
            catch (Exception ex)
            {
                Logger.Error("Error finding refresh token: " + ex.InnerException);
                throw;
            }
        }
    }
}