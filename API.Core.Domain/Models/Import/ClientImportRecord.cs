using System;
using API.Core.Domain.Models.Base;

namespace API.Core.Domain.Models.Import
{
    public class ClientImportRecord : BaseEntity
    {

        public int Id { get; set; }

        public int ClientId { get; set; }
        public string ClientEmployeeInternalId { get; set; }
        public string EmployeeSSN { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeMiddleName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string EmployeeSuffix { get; set; }
        public DateTime EmployeeDateOfBirth { get; set; }
        public string EmployeeGender { get; set; }
        public string EmployeeStreetAddress1 { get; set; }
        public string EmployeeStreetAddress2 { get; set; }
        public string EmployeeCity { get; set; }
        public string EmployeeState { get; set; }
        public string EmployeeZipCode { get; set; }
        public string EmployeeHomePhone { get; set; }
        public string EmployeeWorkPhone { get; set; }
        public string DependentSSN { get; set; }
        public string DependentLastName { get; set; }
        public string DependentMiddleName { get; set; }
        public string DependentFirstName { get; set; }
        public string DependentSuffix { get; set; }
        public DateTime DependentDateOfBirth { get; set; }
        public string DependentGender { get; set; }
        public string RelationshipCode { get; set; }
        public bool Vip { get; set; }
        public bool QMCSO { get; set; }
        public bool Disabled { get; set; }
        public bool Surcharge { get; set; }
        public string MedicalPlan { get; set; }
        public string DentalPlan { get; set; }
        public string VisionPlan { get; set; }
        public bool ExistingEmployee { get; set; }
    }
}
