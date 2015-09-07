using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Communications;
using API.Core.Repository.Models.Event;
using API.Core.Repository.Models.Identity;

namespace API.Core.Repository.Models.Client
{
    /// <summary>
    /// Clients' Employees EF Model
    /// Includes collection of ClientDependents
    /// </summary>
    public class ClientEmployee : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        public ClientEmployee()
        {
            this.Surveys = new HashSet<Survey.Survey>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }

        [Required]
        [MaxLength(250)]
        public string CompanyEmail { get; set; }

        [MaxLength(250)]
        public string PreferredEmail { get; set; }

        [Required]
        [MaxLength(150)]
        public string Street { get; set; }

        [MaxLength(150)]
        public string Unit { get; set; }

        [Required]
        [MaxLength(150)]
        public string City { get; set; }

        [Required]
        [MaxLength(150)]
        public string Region { get; set; }

        [Required]
        [MaxLength(50)]
        public string Postal { get; set; }
        
        [Required]
        [MaxLength(150)]
        public string Country { get; set; }

        [Required]
        [MaxLength(4)]
        public string LastSSN { get; set; }

        public bool HipaaAuthorizationGiven { get; set; }

        [MaxLength(150)]
        public string HomePhone { get; set; }

        [MaxLength(150)]
        public string WorkPhone { get; set; }

        [MaxLength(150)]
        public string CellPhone { get; set; }

        public DateTime DateOfBirth { get; set; }

        public int Client_Id { get; set; }

        [ForeignKey("Client_Id")]
        public API.Core.Repository.Models.Client.Client Client { get; set; }

        public virtual AppUser AppUser { get; set; }

        public virtual ICollection<EmployeeEvent> Events { get; set; }
       
        public virtual ICollection<EmployeeDependent> Dependents { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }

        public virtual ICollection<Survey.Survey> Surveys { get; set; }

        public State State { get; set; }
    }
}
