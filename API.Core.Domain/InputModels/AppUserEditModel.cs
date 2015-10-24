using System;

namespace API.Core.Domain.InputModels
{
    /// <summary>
    /// Edit Model for AppUsers includes dependent information.
    /// Format expected by ngUI
    /// </summary>
    public class AppUserEditModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Email { get; set; }
    }
}