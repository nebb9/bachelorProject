using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models.Users
{
    public class UserDetailsViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Education { get; set; }
    }
}