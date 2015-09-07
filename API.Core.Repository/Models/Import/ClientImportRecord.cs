using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Import
{
    public class ClientImportRecord : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ClientId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ClientEmployeeInternalId { get; set; }

        [Required]
        [MaxLength(9)]
        [Index("IX_EmployeeSSN", 1, IsUnique = true)]
        public string EmployeeSSN { get; set; }

        [Required]
        [MaxLength(250)]
        public string EmployeeEmail { get; set; }

        [Required]
        [MaxLength(150)]
        public string EmployeeLastName { get; set; }

        [MaxLength(150)]
        public string EmployeeMiddleName { get; set; }

        [Required]
        [MaxLength(150)]
        public string EmployeeFirstName { get; set; }

        [MaxLength(50)]
        public string EmployeeSuffix { get; set; }

        [Required]
        public DateTime EmployeeDateOfBirth { get; set; }

        [MaxLength(25)]
        public string EmployeeGender { get; set; }

        [Required]
        [MaxLength(150)]
        public string EmployeeStreetAddress1 { get; set; }

        [Required]
        [MaxLength(150)]
        public string EmployeeStreetAddress2 { get; set; }

        [Required]
        [MaxLength(150)]
        public string EmployeeCity { get; set; }

        [Required]
        [MaxLength(100)]
        public string EmployeeState { get; set; }

        [Required]
        [MaxLength(25)]
        public string EmployeeZipCode { get; set; }

        [MaxLength(25)]
        public string EmployeeHomePhone { get; set; }

        [MaxLength(25)]
        public string EmployeeWorkPhone { get; set; }

        [MaxLength(9)]
        public string DependentSSN { get; set; }

        [Required]
        [MaxLength(150)]
        public string DependentLastName { get; set; }

        [MaxLength(150)]
        public string DependentMiddleName { get; set; }

        [Required]
        [MaxLength(150)]
        public string DependentFirstName { get; set; }

        [MaxLength(50)]
        public string DependentSuffix { get; set; }

        [Required]
        public DateTime DependentDateOfBirth { get; set; }

        [Required]
        [MaxLength(25)]
        public string DependentGender { get; set; }

        [Required]
        [MaxLength(25)]
        public string RelationshipCode { get; set; }

        public bool Vip { get; set; }

        public bool QMCSO { get; set; }

        public bool Disabled { get; set; }

        public bool Surcharge { get; set; }

        [Required]
        [MaxLength(150)]
        public string MedicalPlan { get; set; }

        [Required]
        [MaxLength(150)]
        public string DentalPlan { get; set; }

        [Required]
        [MaxLength(150)]
        public string VisionPlan { get; set; }

        public bool ExistingEmployee { get; set; }
    }
}
