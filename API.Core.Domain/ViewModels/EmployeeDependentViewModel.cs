using System;
using API.Core.Domain.Models.Lookup;

namespace API.Core.Domain.ViewModels
{
    public class EmployeeDependentViewModel
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
    }
}