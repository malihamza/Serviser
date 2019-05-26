using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serviser.Web.Controllers
{
    public class ProblemsController : Controller
    {
        // GET: Problems
        public ActionResult ViewAllProblems()
        {
            return View();
        }

        public ActionResult AddProblem()
        {
            return View();
        }

        public ActionResult DeleteProblem()
        {
            return View();
        }
    }
}