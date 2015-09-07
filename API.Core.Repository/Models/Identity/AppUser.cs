using System.Collections.Generic;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Client;
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
        public IEnumerable<string> UserRoles { get; set; }
        public ClientEmployee ClientEmployee { get; set; }
        public State State { get; set; }
    }
}
