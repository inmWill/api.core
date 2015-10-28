using System;
using System.Collections;
using System.Collections.Specialized;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Configuration;
using System.Web.Http;
using API.Core.Domain.Models.UserIdentity;
using API.Core.Service.Interfaces;
using API.Core.Domain.Models.EditModels;
using API.Core.Rest.WebAPI.ViewModels;
using Microsoft.AspNet.Identity;
using NLog;


namespace API.Core.Rest.WebAPI.Controllers
{
    public class AccountController : BaseController
    {
        private readonly IAccountService _authService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        /// <summary>
        /// Contains CRUD endpoints for user accounts
        /// TODO: Use different end points and view models for different access levels (admin, staff, user, etc...)
        /// </summary>
        /// <param name="authService"></param>
        /// <param name="clientEmployeeService"></param>
        public AccountController(IAccountService authService)
        {
            if (authService == null)
            {
                throw new ArgumentNullException("dependency");
            }
            //   _authRepository = authRepository;
            _authService = authService;
        }


        // GET api/Account/GetCurrentUser
        [API.Core.Rest.WebAPI.Attributes.Authorize]
        public IHttpActionResult GetCurrentUser()
        {
            try
            {
                var identity = User.Identity;
                var userAccount = _authService.FindUser(identity.GetUserName());
                return Ok(userAccount);
            }
            catch (Exception ex)
            {
                Logger.Error("Error retrieving active user account: {0}", ex.Message);
                return BadRequest(ex.Message);
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
        public IHttpActionResult UpdateUserAccount([FromBody] AppUserEditModel record)
        {
            try
            {
                var identity = User.Identity;

                var result = _authService.UpdateUser(record, identity.GetUserName());

                if (result != null)
                    return Ok(result);
                else
                    return BadRequest();
            }
            catch (Exception ex)
            {
                Logger.Error("Error updating active user account: {0}", ex.Message);
                return BadRequest(ex.Message);
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

        //[AllowAnonymous]
        //[HttpPost]
        //public IHttpActionResult RegisterClientEmployee(AppUserRegistrationModel appUserRegistrationModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var userInfo = getActiveUserAgentInfo(Request);
        //    appUserRegistrationModel.IpAddress = userInfo.IP;

        //    var result = _authService.RegisterUserAccount(appUserRegistrationModel);

        //    if (result)
        //        return Ok();

        //    return BadRequest();
        //}

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