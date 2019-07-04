using Serviser.DAL.Context;
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
            ServiserDbContext db = new ServiserDbContext(); 
            List<VehicleProblem> bikeproblems = db.VehicleProblems.Where(x=>x.VehicleType.Name=="Bike").ToList();
            List<VehicleProblem> carproblems = db.VehicleProblems.Where(x => x.VehicleType.Name == "Car").ToList();

            Problems problemsModel = new Problems();
            problemsModel.BikeProblems = bikeproblems;
            problemsModel.CarProblems = carproblems;

            return View(problemsModel);
        }

    }
}