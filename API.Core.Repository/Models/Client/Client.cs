using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;


namespace API.Core.Repository.Models.Client
{
    /// <summary>
    /// Clients EF Model
    /// Includes collection of Employees and Surveys
    /// </summary>
    public class Client : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [MaxLength(250)]
        public string Description { get; set; }

        [MaxLength(150)]
        public string Contact { get; set; }

        [Required]
        [MaxLength(150)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string Phone { get; set; }

        [MaxLength(150)]
        public string Website { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<ClientEmployee> Employees { get; set; } 
        public virtual ICollection<Survey.Survey> Surveys { get; set; }

        public virtual ICollection<Audit> Audits { get; set; }

        public State State { get; set; }
    }
}
