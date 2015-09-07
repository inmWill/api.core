using System;
using System.Collections.Generic;
using API.Core.Domain.Enums;
using API.Core.Domain.Models.Base;
using API.Core.Domain.Models.Communications;
using API.Core.Domain.Models.Event;

namespace API.Core.Domain.Models.Clients
{
    /// <summary>
    /// App Clients' Employees EF Model
    /// Includes collection of ClientDependents
    /// </summary>
    public class AppUserInfo : BaseEntity
    {

        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyEmail { get; set; }
        public string PreferredEmail { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public string LastSSN { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public bool HipaaAuthorizationGiven { get; set; }

        public int Client_Id { get; set; } 

        public DateTime DateOfBirth { get; set; }

        public ICollection<EmployeeEvent> Events { get; set; } 

        public ICollection<EmployeeDependent> Dependents { get; set; }

        public ICollection<Notification> Notifications { get; set; }

        public State State { get; set; }
    }
}
