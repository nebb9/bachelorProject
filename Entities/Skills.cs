using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Entities
{
    public class Skills
    {
        [Key]
        public int SkillID { get; set; }
        public int UserID { get; set; }
        public String Name { get; set; }
        public int Level { get; set; }
    }
}