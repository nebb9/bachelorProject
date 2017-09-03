using ProjectManagementApp.Context;
using ProjectManagementApp.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.DataAccess
{


    public class InitialiseSeedData
    {
        public class InitializeTimeTrackerSeedData : DropCreateDatabaseAlways<DataContext>
        {
            protected override void Seed(DataContext context)
            {
                var users = new List<User>
                {
                    new User
                    {
                        FirstName = "Nebojsa",
                        LastName = "Stankovic",
                        Role = Enums.GlobalEnums.UserRoles.SuperUser,
                        Country = "Novi Sad, Serbia",
                        Education = "Faculty of Sciences, University of Novi Sad",
                        Industry = "Computer Software - IT",
                        Username = "admin",
                        Password = "admin",
                        Summary = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                    },
                    new User
                     {
                         FirstName = "Stefan",
                         LastName = "Ridjosic",
                         Role = Enums.GlobalEnums.UserRoles.ProjectManager,
                         Country = "Novi Sad, Serbia",
                         Education = "Faculty of Sciences, University of Novi Sad",
                         Industry = "Computer Software - IT",
                         Username = "ridjis",
                         Password = "ridjis",
                         Summary = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                     },
                    new User
                     {
                         FirstName = "Stefan",
                         LastName = "Nenadovic",
                         ManagerID = 2,
                         Role = Enums.GlobalEnums.UserRoles.Emoloyee,
                         Country = "Novi Sad, Serbia",
                         Education = "Faculty of Sciences, University of Novi Sad",
                         Industry = "Computer Software - IT",
                         Username = "diler",
                         Password = "diler",
                         Summary = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur. Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum."
                     }
                };

                users.ForEach(u => context.UserContext.Add(u));
                context.SaveChanges();

                var roles = new List<Role>
                {
                    new Role
                    {
                        Name = "Administrator"
                    },
                    new Role
                    {
                        Name = "Project Manager"
                    },
                    new Role
                    {
                        Name = "Worker"
                    }
                };

                roles.ForEach(r => context.RoleContext.Add(r));
                context.SaveChanges();

                var projects = new List<Project>
                {
                    new Project
                    {
                        Name = "Test Project",
                        Description = "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo",
                        Project_Owner = 1,
                        Status = Enums.GlobalEnums.Status.ToDo,
                        StartDate =  DateTime.ParseExact("2017-05-02","yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        EndDate =  DateTime.ParseExact("2017-07-02","yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    },
                    new Project
                    {
                        Name = "Test Project2 ",
                        Description = "Proin ut rhoncus felis. Fusce auctor eros vitae quam fermentum ultrices. Integer dapibus laoreet elit nec dignissim. Aliquam maximus elit ut ante cursus, ac posuere est malesuada. Nam at cursus mauris. Morbi semper massa in faucibus vulputate. Donec quis commodo nisl. Nullam augue leo, iaculis nec neque vitae, porta ultricies leo. Suspendisse ac massa sed eros commodo sagittis a in justo. Sed tempus, urna et ornare auctor, felis turpis condimentum justo, ac pharetra justo mi vel ex.",
                        Project_Owner = 1,
                        Status = Enums.GlobalEnums.Status.Done,
                        StartDate =  DateTime.ParseExact("2017-01-02","yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                        EndDate =  DateTime.ParseExact("2017-10-08","yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    }
                };

                projects.ForEach(p => context.ProjectContext.Add(p));
                context.SaveChanges();

                var tasks = new List<Tasks>
                {
                    new Tasks
                    {
                        ProjectID = 2,
                        UserID = 1,
                        Name = "T203: Prepare for commit",
                        Description = "Proin ut rhoncus felis. Fusce auctor eros vitae quam fermentum ultrices. Integer dapibus laoreet elit nec dignissim. Aliquam maximus elit ut ante cursus, ac posuere est malesuada. Nam at cursus mauris. Morbi semper massa in faucibus vulputate. Donec quis commodo nisl. Nullam augue leo, iaculis nec neque vitae, porta ultricies leo. Suspendisse ac massa sed eros commodo sagittis a in justo. Sed tempus, urna et ornare auctor, felis turpis condimentum justo, ac pharetra justo mi vel ex.",
                        HoursEstimation = 20,
                        Status = Enums.GlobalEnums.Status.ToDo,
                        EndDate =  DateTime.ParseExact("2017-06-08","yyyy-MM-dd", System.Globalization.CultureInfo.InvariantCulture),
                    }
                };
                tasks.ForEach(t => context.TasksContext.Add(t));
                context.SaveChanges();

                var skills = new List<Skills>
                {
                    new Skills
                    {
                        Name = "Java",
                        UserID = 1,
                        Level = 7
                    },
                       new Skills
                    {
                        Name = "C#",
                        UserID = 1,
                        Level = 3
                    }
                };

                skills.ForEach(s => context.SkillsContext.Add(s));
                context.SaveChanges();
            }
        }
    }
}