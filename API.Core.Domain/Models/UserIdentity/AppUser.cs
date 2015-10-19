using System.Collections.Generic;
using API.Core.Domain.Models.Base;

namespace API.Core.Domain.Models.UserIdentity
{
    public partial class AppUser : BaseEntity
    {
        public string UserName { get; set; }
        public bool Enabled { get; set; }
        public string Password { get; set; }
        public IEnumerable<string> UserRoles { get; set; } 
    }
}
