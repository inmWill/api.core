using System;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Clients;

namespace API.Core.Domain.Models.Communications
{
    public class Notification : BaseEntity
    {
        public int Id { get; set; }
        public NotificationType Type { get; set; }

        public int Template_Id { get; set; }
        public Template Template { get; set; }

        public int ClientEmployee_Id { get; set; }
        public AppUserInfo Receipient { get; set; }

        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Sent { get; set; }
        public bool Received { get; set; }
        public DateTime SentDate { get; set; }
        public DateTime ReceivedDate { get; set; }
        public NotificationStatus Status { get; set; }
        public State State { get; set; }
    }
}
