using API.Core.Service.Interfaces;
using ConSova.Utils.Communications.SendGrid;
using NLog;

namespace API.Core.Service.Services
{
    //TODO remove 
    public class UserNotificationServiceService : IUserNotificationService
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        public CoreEmail CoreEmail;

        public bool SendSuccessEmail()
        {
            CoreEmail = new CoreEmail();
            return CoreEmail.Send();
        }

        public bool SendFailureEmail()
        {
            return CoreEmail.Send();
        }


    }
}
