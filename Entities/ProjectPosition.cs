using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Entities
{
    public class ProjectPosition
    {
        public int positionID { get; set; }
        public int userID { get; set; }
        public int projectID { get; set; }
        public string name { get; set; }
    }
}