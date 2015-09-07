using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Client
{
    public class SpouseEmployer : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    { 
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Name { get; set; }

        [Required]
        [MaxLength(250)]
        public string HRContactEmail { get; set; }

        [Required]
        [MaxLength(250)]
        public string Position { get; set; }

        public Plan Plan { get; set; }
        public State State { get; set; }
    }
}
