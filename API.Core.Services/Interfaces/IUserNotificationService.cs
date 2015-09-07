namespace API.Core.Service.Interfaces
{
    public interface IUserNotificationService
    {
        bool SendSuccessEmail();
        bool SendFailureEmail();
    }
}