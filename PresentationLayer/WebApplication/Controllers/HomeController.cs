using Gradebook.PresentationLayer.WebApplication.Security;
using Roles = Gradebook.Utilities.Common.Constants.Roles;
using System.Web.Mvc;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        //[CustomAuthorize(Roles.Admin,Roles.Professor)]
        public ActionResult Index()
        {
            return View();
        }

        [CustomAuthorize]
        public ActionResult Admin()
        {
            return View();
        }
        [CustomAuthorize]
        public ActionResult Moderator()
        {
            return View();
        }
    }
}