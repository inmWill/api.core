using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Core.Domain.Enums;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Client;
using State = API.Core.Repository.Interfaces.State;

namespace API.Core.Repository.Models.Communications
{
    public class Notification : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }
        public NotificationType Type { get; set; }


        public int Template_Id { get; set; }

        [ForeignKey("Template_Id")]
        public Template Template { get; set; }

        public int ClientEmployee_Id { get; set; }

        [ForeignKey("ClientEmployee_Id")]
        public ClientEmployee ClientEmployee { get; set; }

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
