using Gradebook.PresentationLayer.WebApplication.Security;
using System.Web.Mvc;
using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using System.Collections.Generic;
using Gradebook.PresentationLayer.WebApplication.Models;
using System.Linq;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IPupilManager _pupilManager = new PupilManager();

        //[CustomAuthorize(Roles.Admin,Roles.Professor)]
        public ActionResult Index()
        {
            IEnumerable<PupilModel> models = _pupilManager.GetAll().Select(x => (PupilModel)x);
            return View(models);
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