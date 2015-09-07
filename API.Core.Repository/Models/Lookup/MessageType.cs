using System.ComponentModel.DataAnnotations;
using API.Core.Repository.Interfaces;

namespace API.Core.Repository.Models.Lookup
{
    public class MessageType : IIdentifier, IObjectWithState
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Description { get; set; }

        public State State { get; set; }
    }
}
