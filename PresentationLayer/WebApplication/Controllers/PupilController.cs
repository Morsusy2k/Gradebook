using Gradebook.BusinessLogicLayer.Interfaces;
using Gradebook.BusinessLogicLayer.Managers;
using Gradebook.PresentationLayer.WebApplication.Models;
using System;
using System.Web.Mvc;

namespace Gradebook.PresentationLayer.WebApplication.Controllers
{
    public class PupilController : Controller
    {
        // GET: Pupil
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Details(int id)
        {
            try
            {
                IPupilManager _pupilManager = new PupilManager();
                PupilModel model = _pupilManager.GetById(id);

                if(model == null)
                {
                    throw new Exception();
                }

                return View(model);
            }
            catch
            {
                return RedirectToAction("Index","Home");
            }
            
        }
    }
}