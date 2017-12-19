using System.Web.Mvc;
using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using System.Collections.Generic;
using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using System.Linq;
using PagedList;
using static Gradebook.Utilities.Common.Constants;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private static readonly IPupilManager _pupilManager = new PupilManager();

        public ActionResult Index(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<PupilModel> models = _pupilManager.GetAll().Select(x => (PupilModel)x);

            PagedList<PupilModel> modelsList = new PagedList<PupilModel>(models, page, pageSize);
            return View(modelsList);
        }
    }
}