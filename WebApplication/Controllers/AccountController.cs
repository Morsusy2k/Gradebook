using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using WebApplication.Models;
using WebApplication.Providers;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public static readonly MembershipProvider _membership = new CustomMembershipProvider();
        [AllowAnonymous]
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginModel());
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginModel model, string returnUrl)
        {
            model.ErrorMessage = string.Empty;
            if (ModelState.IsValid)
            {
                if (_membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    model.ErrorMessage = "The user name or password provided is incorrect.";
                }
            }

            return View(model);
        }

        [AllowAnonymous]
        public ActionResult LogOff()
        {
            FormsAuthentication.SignOut();

            return RedirectToAction("Login", "Account");
        }
    }
}