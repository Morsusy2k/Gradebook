using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.PresentationLayer.WebApplication.Models.BasicModels;
using Gradebook.PresentationLayer.WebApplication.Models.ComplexModels;
using Gradebook.PresentationLayer.WebApplication.Security;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using static Gradebook.Utilities.Common.Constants;
using Membership = Gradebook.PresentationLayer.WebApplication.Security.CustomMembershipProvider;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class PcpController : Controller
    {
        private readonly IPupilManager _pupilManager = new PupilManager();
        private readonly ISubjectManager _subjectManager = new SubjectManager();
        private readonly IGradebookManager _gradebookManager = new GradebookManager();
        private readonly IMarksManager _marksManager = new MarksManager();
        private readonly IMarkManager _markManager = new MarkManager();
        private readonly IUserManager _userManager = new UserManager();
        private readonly IPClassManager _classManager = new PClassManager();
        private readonly ISubjectLessonManager _lessonManager = new SubjectLessonManager();

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        public ActionResult AddPupil()
        {
            return View();
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPupil(PupilModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("PupilError", "Oops, Something went wrong.");
                return View(model);
            }

            PupilModel newModel = _pupilManager.Add(model);
            GbookModel gbook = _gradebookManager.GetByClassId(newModel.PClassId);

            return RedirectToAction("Class", "Gradebook", new { id = gbook.Id });
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        public ActionResult ManageMarks(int? subject, int? pupil)
        {
            if (!subject.HasValue && !pupil.HasValue)
            {
                return RedirectToAction("Index", "Home");
            }

            int subjectId = (int)subject;
            int pupilId = (int)pupil;

            IEnumerable<SubjectModel> allSubjects = _subjectManager.GetAll().Select(x => (SubjectModel)x);
            if (!allSubjects.Any(x => x.Id == subjectId)) return RedirectToAction("Index", "Home");
            IEnumerable<PupilModel> allPupils = _pupilManager.GetAll().Select(x => (PupilModel)x);
            if (!allPupils.Any(x => x.Id == pupilId)) return RedirectToAction("Index", "Home");

            SubjectModel subjectModel = _subjectManager.GetById(subjectId);
            PupilModel pupilModel = _pupilManager.GetById(pupilId);

            IEnumerable<MarksModel> allMarks = _marksManager.GetAll().Select(x => (MarksModel)x);
            MarksDetailsModel model = new MarksDetailsModel();
            if (!allMarks.Any(x => x.PupilId == pupilModel.Id && x.SubjectId == subjectModel.Id))
            {
                MarksModel marksModel = new MarksModel(pupilModel.Id, subjectModel.Id, Membership.CurrentUser().Id, DateTime.Now, null);
                marksModel = _marksManager.Add(marksModel);
                model.Marks = marksModel;
            }
            else
            {
                MarksModel marksModel = _marksManager.GetByPupilIdAndSubjectId(pupilModel.Id, subjectModel.Id);
                model.Marks = marksModel;
            }
            model.Professor = _userManager.GetById(subjectModel.UserId);
            model.Subject = subjectModel;
            model.Pupil = pupilModel;
            model.PClass = _classManager.GetById(pupilModel.PClassId);

            return View(model);
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddMark(MarkModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CreatedBy = Membership.CurrentUser().Id;
            model.CreatedDate = DateTime.Now;

            MarkModel newModel = _markManager.Add(model);
            MarksModel marksModel = _marksManager.GetById(newModel.MarksId);

            return RedirectToAction("ManageMarks", "Pcp", new { subject = marksModel.SubjectId, pupil = marksModel.PupilId });
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFinalGrade(MarksModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.ModifiedBy = Membership.CurrentUser().Id;
            model.ModifiedDate = DateTime.Now;

            _marksManager.Save(model);
            return RedirectToAction("ManageMarks", "Pcp", new { subject = model.SubjectId, pupil = model.PupilId });
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        public ActionResult ManageLessons(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<SubjectLessonModel> models = _lessonManager.GetAll().Select(x => (SubjectLessonModel)x);
            PagedList<SubjectLessonModel> modelsList = new PagedList<SubjectLessonModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveLesson(SubjectLessonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.ModifiedBy = Membership.CurrentUser().Id;
            model.ModifiedDate = DateTime.Now;

            _lessonManager.Save(model);
            return RedirectToAction("ManageLessons", "Pcp");
        }

        [CustomAuthorize(Roles.Professor, Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddLesson(SubjectLessonModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            model.CreatedBy = Membership.CurrentUser().Id;
            model.CreatedDate = DateTime.Now;

            _lessonManager.Add(model);

            return RedirectToAction("ManageLessons", "Pcp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeleteLesson(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("ManageLessons", "Pcp");
            }

            int id = (int)pid;
            IEnumerable<SubjectLessonModel> allSubjects = _lessonManager.GetAll().Select(x => (SubjectLessonModel)x);
            if (!allSubjects.Any(x => x.Id == id)) return RedirectToAction("ManageLessons", "Pcp");

            SubjectLessonModel lesson = _lessonManager.GetById(id);

            _lessonManager.Remove(lesson);

            return RedirectToAction("ManageLessons", "Pcp");
        }
    }
}