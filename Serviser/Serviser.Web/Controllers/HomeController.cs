using Serviser.DAL.Entity;
using Serviser.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serviser.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Register()
        {

            return View();
        }
        public ActionResult RegisterAsUser()
        {

            return View();
        }
        public ActionResult Booking()
        {

            return View();
        }
        public ActionResult Login()
        {

            return View();
        }
        public ActionResult Pricing()
        {
            Problems problemsModel = new Problems();
            List<VehicleProblem> problems = new List<VehicleProblem>();
            VehicleProblem problem = new VehicleProblem();
            ServiserDbEntities db = new ServiserDbEntities();
            problems = db.Database.SqlQuery<VehicleProblem>("exec all_problems").ToList();
            List<VehicleProblem> bikeproblems = new List<VehicleProblem>();
            List<VehicleProblem> carproblems = new List<VehicleProblem>();
            foreach (var a in problems)
            {
                if (a.VehicleType.Id == 1)
                {
                    bikeproblems.Add(a);
                }
                else
                {
                    carproblems.Add(a);
                }
            }

            problemsModel.bikeProblems = bikeproblems;
            problemsModel.carProblems = carproblems;

            return View(problemsModel);
        }

    }
}