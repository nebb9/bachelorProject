using ProjectManagementApp.Entities;
using ProjectManagementApp.Models;
using ProjectManagementApp.Models.Users;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using static ProjectManagementApp.DataAccess.ModelConfiguration;

namespace ProjectManagementApp.Context
{
    public class DataContext : DbContext
    {
        public DataContext() :base("Data Source=.\\SQLEXPRESS;Initial Catalog=timetracker1;Integrated Security=True")
        {        
        }

        public DbSet<User> UserContext { get; set; }
        public DbSet<Role> RoleContext { get; set; }
        public DbSet<Project> ProjectContext { get; set; }
        public DbSet<Tasks> TasksContext { get; set; }
        public DbSet<Skills> SkillsContext { get; set; }
        public DbSet<Assignment> AssignmentContext { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new UserConfiguration());
            modelBuilder.Configurations.Add(new RoleConfiguration());
            modelBuilder.Configurations.Add(new ProjectConfiguration());
            modelBuilder.Configurations.Add(new TasksConfiguration());
            modelBuilder.Configurations.Add(new SkillsConfiguration());

        }
    }
}