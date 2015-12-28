using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;
using API.Core.Repository.Models.Base;

namespace API.Core.Repository.Models.Widget
{
    public class Widget : BaseEntity, IIdentifier, IModifiedOn, ICreatedOn, IObjectWithState
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(150)]
        public string Name { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

       [MaxLength(250)]
        public string Manufacturer { get; set; }

        public State State { get; set; }
    }
}
