using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using Trial.Models;
using System.Web.Security;
using Microsoft.VisualStudio.Services.Account;

namespace Trial.Controllers
{
 
    [AllowAnonymous]
    public class AccountController : Controller
    {
        Employee_ManagementEntities db = new Employee_ManagementEntities();
        [Route("")]
        [Route("~/Account/Login")]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(User user)
        {           
                bool isValid = db.Users.Any(x => x.Email == user.Email && x.Password == user.Password);
                if (isValid)
                {

                    FormsAuthentication.SetAuthCookie(user.Email, false);
                    return RedirectToAction("Index", "Students");
                }
            ModelState.AddModelError("", "Invalid Email and Password");
            return View();
        }
        [Route("Account/Signup")]
        public ActionResult Signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Signup(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
            return RedirectToAction("login");
        }
        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("login");
        }

    }
}