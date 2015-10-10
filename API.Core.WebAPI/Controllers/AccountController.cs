using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using API.Core.Domain.Enums;
using API.Core.Domain.InputModels;
using API.Core.Domain.Models.UserIdentity;
using API.Core.Service.Interfaces;
using API.Core.Domain.ViewModels;
using Microsoft.AspNet.Identity;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAuthService _authService;
        private readonly IClientEmployeeService _clientEmployeeService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public AccountController(IAuthService authService, IClientEmployeeService clientEmployeeService)
        {
            if (authService == null || clientEmployeeService == null)
            {
                throw new ArgumentNullException("dependency");
            }
            //   _authRepository = authRepository;
            _authService = authService;
            _clientEmployeeService = clientEmployeeService;
        }


        // GET api/Account/GetCurrentUser
        public IHttpActionResult GetCurrentUser()
        {
            try
            {
                var user = new UserAccountViewModel
                {
                    UserId = 1,
                    UserName = "Admin",
                    FirstName = "Ellen",
                    LastName = "Ripley",
                    Email = "eripley@weylandYutani.com",
                    IsAuthorized = true,
                    Roles = new string[1] { "Admin" }
                };

                return Ok(user);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving current user account: {0}", ex.Message);
                return BadRequest();
            }
        }

        // GET api/Account/GetActiveUserAccount
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public AppUser GetActiveUserAccount()
        {
            try
            {
                var identity = User.Identity;
                var userAccount = _authService.FindActiveUserProfile(identity.GetUserName());
                return userAccount;
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving active user account: {0}", ex.Message);
                return null;
            }
        }


        [API.Core.Rest.WebAPI.Attributes.Authorize(Roles = "Admin")]
        public IHttpActionResult GetAllUserAccounts()
        {
            try
            {
                var users = _authService.FindAllUsers();

                return BuildViewModel<IQueryable<AppUser>>(Request, users);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving all user accounts: {0}", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Updates the active, authenticated user's profile including client employee and dependent information received from AppUserEditModel.
        /// Route: api/Account/UpdateActiveUserProfile
        /// </summary>
        /// <param name="record"></param>
        /// <returns></returns>
        [HttpPut]
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult UpdateActiveUserProfile([FromBody] AppUserEditModel record)
        {
            try
            {
                var identity = User.Identity;
                var userAccount = _authService.FindActiveUserProfile(identity.GetUserName());

                if (userAccount == null)
                    return BadRequest();

                userAccount.ClientEmployee.FirstName = record.FirstName;
                userAccount.ClientEmployee.LastName = record.LastName;
                userAccount.ClientEmployee.CompanyEmail = record.CompanyEmail;
                userAccount.ClientEmployee.PreferredEmail = record.PreferredEmail;
                userAccount.ClientEmployee.Street = record.Street;
                userAccount.ClientEmployee.Unit = record.Unit;
                userAccount.ClientEmployee.Region = record.Region;
                userAccount.ClientEmployee.Postal = record.Postal;
                userAccount.ClientEmployee.Country = record.Country;
                userAccount.ClientEmployee.DateOfBirth = record.DateOfBirth;
                userAccount.ClientEmployee.WorkPhone = record.WorkPhone;
                userAccount.ClientEmployee.HomePhone = record.HomePhone;
                userAccount.ClientEmployee.CellPhone = record.CellPhone;
                userAccount.ClientEmployee.State = State.Modified;
                userAccount.ClientEmployee.HipaaAuthorizationGiven = record.HipaaAuthorizationGiven;
                if (userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true) != null)
                {
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).FirstName = record.SpouseFirstName;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).LastName = record.SpouseLastName;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).DateOfBirth = record.SpouseDateOfBirth;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).CellPhone = record.SpouseCellPhone;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).HomePhone = record.SpouseHomePhone;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).WorkPhone = record.SpouseWorkPhone;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).LastSSN = record.SpouseSSN;
                    userAccount.ClientEmployee.Dependents.Single(r => r.Spouse == true).State = State.Modified;
                }
                var result = _clientEmployeeService.Put(userAccount.ClientEmployee);
                if (result > 0)
                    return Ok();
                return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating active user account: {0}", ex.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        [API.Core.Rest.WebAPI.Attributes.Authorize(Roles = "Admin")]
        public IHttpActionResult DisableUserAccount([FromBody] AppUser record)
        {
            try
            {
                var result = _authService.DisableUser(record);

                if (result)
                    return Ok();

                return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.Error("Error disabling user account: {0}", ex.Message);
                return BadRequest();
            }
        }

        [HttpPut]
        [API.Core.Rest.WebAPI.Attributes.Authorize(Roles = "Admin")]
        public IHttpActionResult EnableUserAccount([FromBody] AppUser record)
        {
            try
            {
                var result = _authService.EnableUser(record);

                if (result)
                    return Ok();
                return BadRequest();

            }
            catch (Exception ex)
            {
                Logger.Error("Error enabling user account: {0}", ex.Message);
                return BadRequest();
            }
        }

        // POST api/Account/RegisterWithService
        [AllowAnonymous]
        public IHttpActionResult Register(AppUser appUserModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _authService.RegisterUser(appUserModel);

            if (result)
                return Ok();

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpGet]
        public IHttpActionResult CheckUsernameAvailability(string username)
        {
            var result = _authService.CheckUsernameAvailability(username);

            if (result)
                return Ok();

            return BadRequest();
        }

        [AllowAnonymous]
        [HttpPost]
        public IHttpActionResult RegisterClientEmployee(AppUserRegistrationModel appUserRegistrationModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var userInfo = getActiveUserAgentInfo(Request);
            appUserRegistrationModel.IpAddress = userInfo.IP;

            var result = _authService.RegisterClientEEUser(appUserRegistrationModel);

            if (result)
                return Ok();

            return BadRequest();
        }

        private UserAgentDetails getActiveUserAgentInfo(HttpRequestMessage request = null)
        {
            if (request == null)
                return null;

            UserAgentDetails details = new UserAgentDetails();

            details.IP = HttpContext.Current.Request.UserHostAddress;
            details.Hostname = HttpContext.Current.Request.UserHostName;
            var userAgent = HttpContext.Current.Request.UserAgent;
            var userBrowser = new HttpBrowserCapabilities { Capabilities = new Hashtable { { string.Empty, userAgent } } };
            var factory = new BrowserCapabilitiesFactory();
            factory.ConfigureBrowserCapabilities(new NameValueCollection(), userBrowser);

            details.BrowserBrand = userBrowser.Browser;
            details.BrowserVersion = userBrowser.Version;

            return details;
        }      
    }
}