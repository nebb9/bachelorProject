using ProjectManagementApp.Context;
using ProjectManagementApp.Entities;
using ProjectManagementApp.Models;
using ProjectManagementApp.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjectManagementApp.Controllers
{
    public class UserController : Controller
    {
        private DataContext context = new DataContext();

        // GET: User
        public ActionResult ManageUsers()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");

            };
            List<User> users = new List<User>();
            List<UserDetailsViewModel> userDetails = new List<UserDetailsViewModel>();
            users = context.UserContext.ToList();
            for (int i = 0; i < users.Count(); i++)
            {
                var details = new UserDetailsViewModel();
                details.FirstName = users[i].FirstName;
                details.LastName = users[i].LastName;
                details.Country = users[i].Country;
                details.Industry = users[i].Industry;
                details.Education = users[i].Education;
                userDetails.Add(details);
            }
            return View(userDetails.ToList());
        }

        public ActionResult AddUser()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");

            };
            return View();
        }

    }
}