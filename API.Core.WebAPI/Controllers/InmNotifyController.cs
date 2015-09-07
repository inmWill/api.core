using System;
using System.Web.Http;
using API.Core.Service.Interfaces;
using NLog;

namespace API.Core.Rest.WebAPI.Controllers
{   
    [API.Core.Rest.WebAPI.Attributes.Authorize]
    public class InmNotifyController : BaseController
    {
        readonly IUserNotificationService _notifyService;
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();

        public InmNotifyController(IUserNotificationService notifyService)
        {
            _notifyService = notifyService;
        }

        public IHttpActionResult GetAuthAccountInfo()
        {
            var isAuth = User.Identity.IsAuthenticated;
            var userName = User.Identity.Name;

            return Ok("Is user authorized: " + isAuth + " Name: " + userName);

        }


        // GET api/clientetlsettings/Get/5
        public IHttpActionResult SendSuccessEmail()
        {
            try
            {
                if (_notifyService.SendSuccessEmail())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                Logger.Error("Error sending email: {0}", ex.Message);
                return BadRequest();
            }
        }
    }
}
