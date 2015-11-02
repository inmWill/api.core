using System.ComponentModel.DataAnnotations;

namespace API.Core.Rest.WebAPI.EditModels
{
    public class AppUserRegModel
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password{ get; set; }
        [Required]
        public string Firstname { get; set; }
        [Required]
        public string Lastname { get; set; }
        [Required]
        public string Email { get; set; }
    }
}

