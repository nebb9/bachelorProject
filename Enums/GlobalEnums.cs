using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.Enums
{
    public class GlobalEnums
    {

        public enum Status
        {
            ToDo,
            InProgress,
            Done
        }

        public enum UserRoles
        {
            Emoloyee = 1,
            ProjectManager = 2,
            SuperUser = 3 
        }
    }
}