using System;
using System.Collections.Generic;

namespace API.Core.Domain.ViewModels
{
    public class ClientEmployeeViewModel
    {
        public int Id { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string CompanyEmail { get; set; }
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

        public DateTime DateOfBirth { get; set; }

        public virtual ICollection<EmployeeDependentViewModel> Dependents { get; set; }
        
    }
}