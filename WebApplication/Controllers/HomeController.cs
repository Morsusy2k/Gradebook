using Gradebook.Utilities.Common;
using System.Web.Mvc;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        [Authorize(Roles = Constants.Admin)]
        public ActionResult Index()
        {

            return View();
        }
    }
}