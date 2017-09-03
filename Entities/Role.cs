using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Entities
{
    public class Role
    {
        [Key]
        public int RoleID { get; set; }
        public string Name { get; set; }
    }
}