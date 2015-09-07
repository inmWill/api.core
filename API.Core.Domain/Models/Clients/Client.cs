using System.Collections.Generic;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.SurveyBuilder;
using API.Core.Domain.Models.UserIdentity;

namespace API.Core.Domain.Models.Clients
{
    /// <summary>
    /// Customer Client information
    /// </summary>
    public class Client : BaseEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Contact { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Website { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<AppUser> Employees { get; set; } 
        public virtual ICollection<Survey> Surveys { get; set; }

    }
}
