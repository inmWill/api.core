using System;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Lookup;

namespace API.Core.Domain.Models.Clients
{
    /// <summary>
    /// Employee's Dependents EF Model
    /// Exclusions are handled on a per dependent level at the moment
    /// </summary>
    public class EmployeeDependent : BaseEntity
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }       
        public string LastSSN { get; set; }
        public DateTime DateOfBirth { get; set; }
        public bool Excluded { get; set; }
        public string WorkPhone { get; set; }
        public string HomePhone { get; set; }
        public string CellPhone { get; set; }
        public bool Spouse { get; set; }

        //public Plan Plan { get; set; }

        public DependentType DependentType { get; set; }
        public State State { get; set; }
    }
}
