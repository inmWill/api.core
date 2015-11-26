using System.Collections.Generic;
using API.Core.Repository.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;

namespace API.Core.Repository.Models.Identity
{
    /// <summary>
    /// App User account
    /// Requires ClientEmployee Record
    /// </summary>
    public class AppUser : IdentityUser, IObjectWithState
    {
        public bool Enabled { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string SecondaryEmail { get; set; }
        public IEnumerable<string> UserRoles { get; set; }
        public State State { get; set; }
    }
}
