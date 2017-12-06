using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.PresentationLayer.WebApplication.Models;
using Gradebook.PresentationLayer.WebApplication.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Gradebook.Utilities.Common.Constants;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class GradebookController : Controller
    {
        private readonly IGradebookManager _gbookManager = new GradebookManager();

        [CustomAuthorize(Roles.Professor)]
        public ActionResult Index()
        {
            IEnumerable<GbookModel> models = _gbookManager.GetAll().Select(x => (GbookModel)x);
            return View(models);
        }
    }
}