using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.PresentationLayer.WebApplication.Models.ViewModels;
using Membership = Gradebook.PresentationLayer.WebApplication.Security.CustomMembershipProvider;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(new LoginViewModel());
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel model, string returnUrl = "")
        {
            if (ModelState.IsValid)
            {
                if (Membership.ValidateUser(model.Username, model.Password))
                {
                    FormsAuthentication.SetAuthCookie(model.Username, model.RememberMe);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("IncorrectCredentials", "Incorrect username and/or password");
                }
            }

            return View(model);
    }

    [AllowAnonymous]
    public ActionResult LogOut()
    {
        FormsAuthentication.SignOut();
        return RedirectToAction("Login", "Account", null);
    }
}
}