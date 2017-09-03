using ProjectManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Models.Users
{
    public class DropdownUsersViewModel
    {

        public int UserID { get; set; }
        public String FirstName { get; set; }
        public IEnumerable<User> Users { get; set; }
    }
}