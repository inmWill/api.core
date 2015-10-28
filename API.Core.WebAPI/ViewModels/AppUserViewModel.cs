using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace API.Core.Rest.WebAPI.ViewModels
{
    public class AppUserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsAuthorized { get; set; }
        public string[] Roles { get; set; }

    }
}