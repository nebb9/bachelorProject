using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Entities
{
    public class Assignment
    {
        [Key]
        public int AssignmentID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
    }
}