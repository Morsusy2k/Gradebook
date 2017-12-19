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
    public class AcpController : Controller
    {
        private readonly ISubjectManager _subjectManager = new SubjectManager();
        private readonly IFieldManager _fieldManager = new FieldManager();
        private readonly IPupilManager _pupilManager = new PupilManager();
        private readonly IPClassManager _classManager = new PClassManager();
        private readonly IGradebookManager _gradebookManager = new GradebookManager();
        private readonly IUserManager _userManager = new UserManager();
        private readonly IRoleManager _roleManager = new RoleManager();

        [CustomAuthorize(Roles.Admin)]
        public ActionResult ManageSubjects(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<SubjectModel> models = _subjectManager.GetAll().Select(x => (SubjectModel)x);
            PagedList<SubjectModel> modelsList = new PagedList<SubjectModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveSubject(SubjectModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("SubjectError", "Oops, Something went wrong.");
                return RedirectToAction("ManageSubjects", "Acp");
            }

            model.ModifiedBy = Membership.CurrentUser().Id;
            model.ModifiedDate = DateTime.Now;
            _subjectManager.Save(model);

            return RedirectToAction("ManageSubjects", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddSubject(SubjectModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("SubjectError", "Oops, Something went wrong.");
                return RedirectToAction("ManageSubjects", "Acp");
            }

            model.CreatedBy = Membership.CurrentUser().Id;
            model.CreatedDate = DateTime.Now;
            _subjectManager.Add(model);

            return RedirectToAction("ManageSubjects", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeleteSubject(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("ManageSubjects", "Acp");
            }

            int id = (int)pid;
            IEnumerable<SubjectModel> allSubjects = _subjectManager.GetAll().Select(x => (SubjectModel)x);
            if (!allSubjects.Any(x => x.Id == id)) return RedirectToAction("ManageSubjects", "Acp");

            SubjectModel subject = _subjectManager.GetById(id);

            _subjectManager.Remove(subject);

            return RedirectToAction("ManageSubjects", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult ManageFields(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<FieldModel> models = _fieldManager.GetAll().Select(x => (FieldModel)x);
            PagedList<FieldModel> modelsList = new PagedList<FieldModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddField(FieldModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("FieldError", "Oops, Something went wrong.");
                return RedirectToAction("ManageFields", "Acp");
            }

            model.CreatedBy = Membership.CurrentUser().Id;
            model.CreatedDate = DateTime.Now;
            _fieldManager.Add(model);

            return RedirectToAction("ManageFields", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveField(FieldModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("FieldError", "Oops, Something went wrong.");
                return RedirectToAction("ManageFields", "Acp");
            }

            model.ModifiedBy = Membership.CurrentUser().Id;
            model.ModifiedDate = DateTime.Now;
            _fieldManager.Save(model);

            return RedirectToAction("ManageFields", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeleteField(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("ManageFields", "Acp");
            }

            int id = (int)pid;
            IEnumerable<FieldModel> allSubjects = _fieldManager.GetAll().Select(x => (FieldModel)x);
            if (!allSubjects.Any(x => x.Id == id)) return RedirectToAction("ManageFields", "Acp");

            FieldModel field = _fieldManager.GetById(id);

            _fieldManager.Remove(field);

            return RedirectToAction("ManageFields", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult EditFieldSubjects(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("ManageFields", "Acp");
            }

            int id = (int)pid;
            IEnumerable<FieldModel> allFields = _fieldManager.GetAll().Select(x => (FieldModel)x);
            if (!allFields.Any(x => x.Id == id)) return RedirectToAction("ManageFields", "Acp");

            FieldModel model = _fieldManager.GetById(id);

            IEnumerable<SubjectModel> allSubjects = _subjectManager.GetAll().Select(x => (SubjectModel)x);
            IEnumerable<SubjectModel> fieldSubjects = _subjectManager.GetSubjectsByFieldId(id).Select(x => (SubjectModel)x);

            List<SubjectModel> tempSubs = new List<SubjectModel>();

            foreach (SubjectModel sub in allSubjects)
            {
                foreach (SubjectModel sub2 in fieldSubjects)
                {
                    if (sub2.Id == sub.Id)
                    {
                        sub.IsChecked = true;
                    }
                }
                tempSubs.Add(sub);
            }
            model.SubjectList = tempSubs;

            return View(model);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditFieldSubjects(FieldModel model)
        {
            IEnumerable<FieldModel> allFields = _fieldManager.GetAll().Select(x => (FieldModel)x);
            if (!allFields.Any(x => x.Id == model.Id)) return RedirectToAction("EditFieldSubjects", "Acp");

            FieldModel field = _fieldManager.GetById(model.Id);
            
            string subStr = model.SubjectString;

            if (subStr == "" || subStr == null)
            {
                return RedirectToAction("EditFieldSubjects", "Acp");
            }

            _fieldManager.RemoveFieldSubjects(field);

            string[] subs = subStr.Split('/');

            for (int i = 0; i < subs.Length - 1; i++)
            {
                Int32.TryParse(subs[i], out int x);
                SubjectModel subject = _subjectManager.GetById(x);
                _fieldManager.AddSubjectToField(field, subject, Membership.CurrentUser().Id);
            }

            return RedirectToAction("EditFieldSubjects", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult ManagePupils(int page = 1, int pageSize = Display.PageSize-2)
        {
            IEnumerable<PupilModel> models = _pupilManager.GetAll().Select(x => (PupilModel)x);
            PagedList<PupilModel> modelsList = new PagedList<PupilModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SavePupil(PupilModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("PupilError", "Oops, Something went wrong.");
                return RedirectToAction("ManagePupils", "Acp");
            }

            model.ModifiedBy = Membership.CurrentUser().Id;
            model.ModifiedDate = DateTime.Now;
            _pupilManager.Save(model);
            return RedirectToAction("ManagePupils", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddPupil(PupilModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("PupilError", "Oops, Something went wrong.");
                return RedirectToAction("ManagePupils", "Acp");
            }

            model.CreatedBy = Membership.CurrentUser().Id;
            model.CreatedDate = DateTime.Now;
            _pupilManager.Add(model);

            return RedirectToAction("ManagePupils", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeletePupil(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("ManagePupils", "Acp");
            }

            int id = (int)pid;
            IEnumerable<PupilModel> allSubjects = _pupilManager.GetAll().Select(x => (PupilModel)x);
            if (!allSubjects.Any(x => x.Id == id)) return RedirectToAction("ManagePupils", "Acp");

            PupilModel pupil = _pupilManager.GetById(id);

            _pupilManager.Remove(pupil);

            return RedirectToAction("ManagePupils", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult ManageClasses(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<PClassModel> models = _classManager.GetAll().Select(x => (PClassModel)x);
            PagedList<PClassModel> modelsList = new PagedList<PClassModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveClass(ClassGbookModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("ClassError", "Oops, Something went wrong.");
                return RedirectToAction("ManageClasses", "Acp");
            }

            model.PClass.ModifiedBy = Membership.CurrentUser().Id;
            model.PClass.ModifiedDate = DateTime.Now;

            model.Gradebook.PClassId = model.PClass.Id;
            model.Gradebook.ModifiedBy = Membership.CurrentUser().Id;
            model.Gradebook.ModifiedDate = DateTime.Now;

            _gradebookManager.Save(model.Gradebook);
            _classManager.Save(model.PClass);
            return RedirectToAction("ManageClasses", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddClass(ClassGbookModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData.Add("ClassError", "Oops, Something went wrong.");
                return RedirectToAction("ManageClasses", "Acp");
            }

            model.PClass.CreatedBy = Membership.CurrentUser().Id;
            model.PClass.CreatedDate = DateTime.Now;

            PClassModel pclass = _classManager.Add(model.PClass);

            model.Gradebook.PClassId = pclass.Id;
            model.Gradebook.CreatedBy = Membership.CurrentUser().Id;
            model.Gradebook.CreatedDate = DateTime.Now;

            _gradebookManager.Add(model.Gradebook);

            return RedirectToAction("ManageClasses", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult DeleteClass(int? pid)
        {
            if (!pid.HasValue)
            {
                return RedirectToAction("ManageClasses", "Acp");
            }

            int id = (int)pid;

            IEnumerable<PClassModel> allSubjects = _classManager.GetAll().Select(x => (PClassModel)x);
            if (!allSubjects.Any(x => x.Id == id)) return RedirectToAction("ManageClasses", "Acp");

            PClassModel pclass = _classManager.GetById(id);

            GbookModel gbook = _gradebookManager.GetByClassId(pclass.Id);

            _gradebookManager.Remove(gbook);

            _classManager.Remove(pclass);

            return RedirectToAction("ManageClasses", "Acp");
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult ManageUsers(int page = 1, int pageSize = Display.PageSize)
        {
            IEnumerable<UserModel> models = _userManager.GetAll().Select(x => (UserModel)x);
            PagedList<UserModel> modelsList = new PagedList<UserModel>(models, page, pageSize);
            return View(modelsList);
        }

        [CustomAuthorize(Roles.Admin)]
        public ActionResult EditUserRole(int? pid)
        {
            if(!pid.HasValue)
            {
                return RedirectToAction("ManageUsers", "Acp");
            }

            int id = (int)pid;
            IEnumerable<UserModel> allUsers = _userManager.GetAll().Select(x => (UserModel)x);
            if (!allUsers.Any(x => x.Id == id)) return RedirectToAction("ManageUsers", "Acp");

            UserModel model = _userManager.GetById(id);

            if (model.Id == Membership.CurrentUser().Id)
            {
                TempData.Add("UserError", "Oops, You can't change your own roles.");
                return RedirectToAction("ManageUsers", "Acp");
            }

            IEnumerable<RoleModel> allRoles = _roleManager.GetAll().Select(x => (RoleModel)x);
            IEnumerable<RoleModel> userRoles = _roleManager.GetAllRolesByUserId(id).Select(x => (RoleModel)x);

            List<RoleModel> tempRoles = new List<RoleModel>();

            foreach (RoleModel role in allRoles)
            {
                foreach (RoleModel role2 in userRoles)
                {
                    if (role.Id == role2.Id)
                    {
                        role.IsChecked = true;
                    }
                }
                tempRoles.Add(role);
            }
            model.Roles = tempRoles;

            return View(model);
        }

        [CustomAuthorize(Roles.Admin)]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditUserRole(UserModel model)
        {
            IEnumerable<UserModel> allUsers = _userManager.GetAll().Select(x => (UserModel)x);
            if (!allUsers.Any(x => x.Id == model.Id)) return RedirectToAction("EditUserRole", "Acp");

            UserModel user = _userManager.GetById(model.Id);
            
            string roleStr = model.RolesString;

            if (roleStr == "" || roleStr == null)
            {
                TempData.Add("RoleError", "No changes were made.");
                return RedirectToAction("EditUserRole", "Acp");
            }

            _roleManager.DeleteUserRolesByUser(user);

            string[] roles = roleStr.Split('/');

            for (int i = 0; i < roles.Length - 1; i++)
            {
                Int32.TryParse(roles[i], out int x);
                RoleModel role = _roleManager.GetById(x);
                _roleManager.AddUserRole(Membership.CurrentUser(), role, user);
            }

            TempData.Add("RoleSuccess", "Done, user roles saved! :)");
            return RedirectToAction("EditUserRole", "Acp");
        }
    }
}