using ProjectManagementApp.Models.Home;
using ProjectManagementApp.Models.Users;
using ProjectManagementApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace ProjectManagementApp.Controllers
{
    public class HomeController : Controller
    {
        //private DataContext db = new DataContext();
        private UserService userService = new UserService();

        public async Task<ActionResult> Index()
        {
            if (Session["UserID"] == null)
            {
                return RedirectToAction("Login", "Account");
            };
            var username = (string)Session["Username"];
            var userInformation = await userService.GetUser(username);
            HomeViewModel homeModel = new HomeViewModel();
            homeModel.FirstName = userInformation.FirstName;
            homeModel.LastName = userInformation.LastName;
            homeModel.Education = userInformation.Education;
            homeModel.Industry = userInformation.Industry;
            homeModel.Summary = userInformation.Summary;
            homeModel.Country = userInformation.Country;
            return View(homeModel);
        }

        public ActionResult ModalPopUp()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}