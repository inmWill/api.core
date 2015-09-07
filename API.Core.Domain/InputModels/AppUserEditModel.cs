using System;

namespace API.Core.Domain.InputModels
{
    /// <summary>
    /// Edit Model for AppUsers includes dependent information.
    /// Format expected by ngUI
    /// </summary>
    public class AppUserEditModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string CompanyEmail { get; set; }
        public string PreferredEmail { get; set; }
        public string SSN { get; set; }
        public string Street { get; set; }
        public string Unit { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
        public string Postal { get; set; }
        public string Country { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string HomePhone { get; set; }
        public string WorkPhone { get; set; }
        public string CellPhone { get; set; }
        public bool HipaaAuthorizationGiven { get; set; }

        public string SpouseFirstName { get; set; }
        public string SpouseLastName { get; set; }
        public string SpouseSSN { get; set; }
        public DateTime SpouseDateOfBirth { get; set; }
        public string SpouseHomePhone { get; set; }
        public string SpouseWorkPhone { get; set; }
        public string SpouseCellPhone { get; set; }
    }
}