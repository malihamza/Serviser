using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serviser.Web.Controllers
{
    public class AdminxController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Home()
        {
            return View();
        }

        public ActionResult ViewAllMechanics()
        {
            return View();
        }

        public ActionResult AddNewMechanic()
        {
            return View();
        }

        public ActionResult DeleteMechanic()
        {
            return View();
        }

        public ActionResult PendingRequests()
        {
            return View();
        }

        public ActionResult RejectedRequests()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult AddAdmin()
        {
            return View();
        }

        public ActionResult ForgotPassword()
        {
            return View();
        }
    }
}