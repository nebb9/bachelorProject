using ProjectManagementApp.Models.Account;
using ProjectManagementApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using ProjectManagementApp.Services;
using ProjectManagementApp.Context;
using System.Net;
using System.Web.Security;

namespace ProjectManagementApp.Controllers
{
    public class AccountController : Controller
    {
        private DataContext context = new DataContext();
        private UserService userService = new UserService();

        // GET: Account
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(UserLoginViewModel userLoginViewModel)
        {
            if (userLoginViewModel != null && ModelState.IsValid)
            {
                var isValidateCredentials = await userService.ValidateUserCredentials(userLoginViewModel.Username, userLoginViewModel.Password);
                if (isValidateCredentials)
                {
                    var loggedInUser = await userService.GetUser(userLoginViewModel.Username);
                    Session["Username"] = loggedInUser.Username;
                    Session["FirstName"] = loggedInUser.FirstName;
                    Session["UserID"] = loggedInUser.UserID;
                    Session["Role"] = loggedInUser.Role;
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }

        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            Session.Abandon();
            return View("Login");
        }
    }
}