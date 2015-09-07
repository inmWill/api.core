using System.ComponentModel.DataAnnotations;
using API.Core.Domain.Enums;
using API.Core.Repository.Interfaces;
using State = API.Core.Repository.Interfaces.State;

namespace API.Core.Repository.Models.Identity
{
    public class AuthorizedClient: IObjectWithState
    {
        [Key]
        public string Id { get; set; }
        [Required]
        public string Secret { get; set; }
        [Required]
        [MaxLength(100)]
        public string Name { get; set; }
        public ApplicationTypes ApplicationType { get; set; }
        public bool Active { get; set; }
        public int RefreshTokenLifeTime { get; set; }
        [MaxLength(100)]
        public string AllowedOrigin { get; set; }
        public State State { get; set; }
    }
}
