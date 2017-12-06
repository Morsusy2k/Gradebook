using Gradebook.PresentationLayer.WebApplication.Models.ViewModels;
using Membership = Gradebook.PresentationLayer.WebApplication.Security.CustomMembershipProvider;
using System.Web.Mvc;
using System.Web.Security;
using Gradebook.PresentationLayer.WebApplication.Models;
using Gradebook.Utilities.Common.Helpers;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.BusinessLogicLayer.Interfaces;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserManager _userManager = new UserManager();

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
                if (Membership.ValidateUser(model.Username,model.Password))
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

        
        public ActionResult Register()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Home", null);
            }
            return View();
        }

        [HttpPost]
        public ActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                UserModel newUser = new UserModel() {
                    Name = model.Name,
                    Surname = model.Surname,
                    Username = model.Username,
                    Password = Helpers.GetMD5Hash(model.Password),
                    Email = model.Email
                };
                _userManager.Add(newUser);
                return RedirectToAction("Login", "Account", null);
            }
            return View(model);
        }
    }
}