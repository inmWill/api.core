using System;

namespace API.Core.Domain.InputModels
{
    public class AppUserRegistrationModel
    {
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SSN { get; set; }
        public string Email { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string IpAddress { get; set; }
    }
}