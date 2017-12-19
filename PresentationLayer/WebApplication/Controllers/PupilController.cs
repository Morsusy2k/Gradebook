using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using Gradebook.PresentationLayer.WebApplication.Models.ComplexModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class PupilController : Controller
    {
        private readonly IPupilManager _pupilManager = new PupilManager();
        private readonly IMarksManager _marksManager = new MarksManager();
        private readonly IPClassManager _classManager = new PClassManager();
        private readonly ISubjectManager _subjectManager = new SubjectManager();
        private readonly IFieldManager _fieldManager = new FieldManager();

        public ActionResult Details(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            int id = (int)pid;
            IEnumerable<PupilModel> allPupil = _pupilManager.GetAll().Select(x => (PupilModel)x);
            if (!allPupil.Any(x => x.Id == id)) return RedirectToAction("Index", "Home");
            
            PupilModel pupil = _pupilManager.GetById(id);
            PClassModel pClass = _classManager.GetById(pupil.PClassId);
            IEnumerable<SubjectModel> subjectList = _subjectManager.GetSubjectsByFieldId(pClass.FieldOfStudyId).Select(x => (SubjectModel)x);
            FieldModel fieldOfStudy = _fieldManager.GetById(pClass.FieldOfStudyId);

            PupilDetailsModel details = new PupilDetailsModel
            {
                Subjects = subjectList,
                Pupil = pupil,
                Pclass = pClass,
                Field = fieldOfStudy
            };

            return View(details);
        }
    }
}