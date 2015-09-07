using System;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;

namespace API.Core.Repository.Models.Identity
{
    public class RefreshToken: IObjectWithState
    {
        [Key]
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Subject { get; set; }

        [Required]
        [MaxLength(50)]
        public string ClientId { get; set; }

        public DateTime IssuedUtc { get; set; }
        public DateTime ExpiresUtc { get; set; }

        [Required]
        public string ProtectedTicket { get; set; }

        public State State { get; set; }
    }
}
