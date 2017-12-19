using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using Gradebook.PresentationLayer.WebApplication.Models.ComplexModels;
using Gradebook.PresentationLayer.WebApplication.Security;
using PagedList;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Gradebook.Utilities.Common.Constants;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class GradebookController : Controller
    {
        private readonly IGradebookManager _gbookManager = new GradebookManager();
        private readonly IPClassManager _classManager = new PClassManager();
        private readonly IFieldManager _fieldManager = new FieldManager();
        private readonly IPupilManager _pupilManager = new PupilManager();
        private readonly IUserManager _userManager = new UserManager();

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        public ActionResult Index(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<GbookModel> models = _gbookManager.GetAll().Select(x => (GbookModel)x);
            PagedList<GbookModel> modelsList = new PagedList<GbookModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        public ActionResult Class(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("Index", "Gradebook");
            }

            int id = (int)pid;
            IEnumerable<GbookModel> allGbooks = _gbookManager.GetAll().Select(x => (GbookModel)x);
            if (!allGbooks.Any(x => x.Id == id)) return RedirectToAction("Index", "Gradebook");

            ClassDetailsModel model = new ClassDetailsModel();
            model.ClassGradebook = _gbookManager.GetById(id);
            model.ClassClass = _classManager.GetById(model.ClassGradebook.PClassId);
            model.ClassField = _fieldManager.GetById(model.ClassClass.FieldOfStudyId);
            model.ClassPupils = _pupilManager.GetByClassId(model.ClassGradebook.PClassId).Select(x => (PupilModel)x);
            model.ClassProfessor = _userManager.GetById(model.ClassClass.UserId);

            return View(model);
        }
    }
}