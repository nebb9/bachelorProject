using ProjectManagementApp.Context;
using ProjectManagementApp.Entities;
using ProjectManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace ProjectManagementApp.Services
{
    public class UserService
    {
        // does username exists
        //private DataContext context = new DataContext();


        public async Task<bool> ValidateUserCredentials(string username, string password)
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    var user = ctx.UserContext.Where(u => u.Username == username && u.Password == password).FirstOrDefault();

                    if (user != null)
                    {
                        return await Task.FromResult(true);
                    }
                    return await Task.FromResult(false);
                }
            }
            catch (Exception e)
            {
                e.GetBaseException();
                throw;
            }
        }

        public async Task<User> GetUser(string username)
        {
            try
            {
                using (var ctx = new DataContext())
                {
                    var user = ctx.UserContext.FirstOrDefault(u => u.Username == username);
                    return await Task.FromResult(user);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}