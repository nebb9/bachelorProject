using ProjectManagementApp.Entities;
using ProjectManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Web;

namespace ProjectManagementApp.DataAccess
{
    public class ModelConfiguration
    {

        public class UserConfiguration : EntityTypeConfiguration<User>
        {
            public UserConfiguration()
            {
                Property(p => p.FirstName);
                Property(p => p.Role);
                Property(p => p.LastName);
                Property(p => p.Username).IsRequired();
                Property(p => p.Password).IsRequired();
                Property(p => p.Country);
                Property(p => p.Industry);
                Property(p => p.Summary);
            }
        }

        public class RoleConfiguration : EntityTypeConfiguration<Role>
        {
            public RoleConfiguration()
            {
                Property(p => p.Name);
            }
        }

        public class ProjectConfiguration : EntityTypeConfiguration<Project>
        {
            public ProjectConfiguration()
            {
                Property(p => p.Name);
                Property(p => p.Description);
                Property(p => p.Project_Owner);
                Property(p => p.Status);
                Property(p => p.StartDate);
                Property(p => p.EndDate);
            }
        }

        public class TasksConfiguration : EntityTypeConfiguration<Tasks>
        {
            public TasksConfiguration()
            {
                Property(p => p.Name);
                Property(p => p.UserID);
                Property(p => p.ProjectID);
                Property(p => p.EndDate);
                Property(p => p.Status);
                Property(p => p.HoursEstimation);
                Property(p => p.Description);
            }
        }
        public class SkillsConfiguration : EntityTypeConfiguration<Skills>
        {
            public SkillsConfiguration()
            {
                Property(p => p.Name);
                Property(p => p.UserID);
                Property(p => p.Level);
            }
        }

        public class AssignmentConfiguration : EntityTypeConfiguration<Assignment>
        {
            public AssignmentConfiguration()
            {
                Property(p => p.ProjectID);
                Property(p => p.UserID);
            }
        }

    }
}