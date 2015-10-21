using System.Collections.Generic;
using API.Core.Domain.Models.Base;

namespace API.Core.Domain.Models.UserIdentity
{
    public partial class AppUser : BaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Enabled { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
        public IEnumerable<string> Roles { get; set; } 
    }
}
