using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static ProjectManagementApp.Enums.GlobalEnums;

namespace ProjectManagementApp.Entities
{
    public class Tasks
    {
        [Key]
        public int TaskID { get; set; }
        public int ProjectID { get; set; }
        public int UserID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HoursEstimation { get; set; }
        public Status Status { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy}")]
        public DateTime EndDate { get; set; }
    }
}