using System;
using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;
using API.Core.Repository.Models.Lookup;

namespace API.Core.Repository.Models.Client
{
    /// <summary>
    /// Employee's Dependents EF Model
    /// Exclusions are handled on a per dependent level at the moment
    /// </summary>
    public class EmployeeDependent : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(150)]
        public string LastName { get; set; }       

        [Required]
        [MaxLength(4)]
        public string LastSSN { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string WorkPhone { get; set; }

        public string HomePhone { get; set; }

        public string CellPhone { get; set; }

        public bool Spouse { get; set; }

        public bool Excluded { get; set; }

        public Plan Plan {get; set; }

        public DependentType DependentType { get; set; }

    //    public int ClientEmployee_Id { get; set; }

        public ClientEmployee ClientEmployee { get; set; }

        public State State { get; set; }
    }
}
