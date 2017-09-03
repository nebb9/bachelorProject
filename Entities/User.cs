using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ProjectManagementApp.Enums.GlobalEnums;

namespace ProjectManagementApp.Entities
{
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public UserRoles Role { get; set; }
        public int ManagerID { get; set; }
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }
        [Display(Name ="Username")]
        [Required(ErrorMessage = "Username is required")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Last Name is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Country { get; set; }
        public string Industry { get; set; }
        public string Education { get; set; }
        public string Summary { get; set; }
        public byte[] UserImage { get; set; }
    }
}