using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serviser.DAL.Entity;
using Serviser.Web.Models;
using Serviser.DAL.Context;
using System.Data.Entity;


namespace Serviser.Web.Controllers
{
    public class ServicesController : Controller
    {
        private ServiserDbContext db = new ServiserDbContext();
        List<int> bill = new List<int>();
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getMechanics(Location loc)
        {
            List<User> lis = new List<User>();
            User profile = new User();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
           profile.Longitude = loc.Longitude+ (float)1 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude - (float)8 / 10000;
            profile.Longitude = loc.Longitude - (float)8 / 10000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)2 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
            profile.Longitude = loc.Longitude - (float) 2/ 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)1 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude + (float)3 / 1000;
            profile.Longitude = loc.Longitude + (float)3 / 1000;
            lis.Add(profile);

            return Json(lis);
        }
        public ActionResult Booking()
        {
            Problems problemsModel            = new Problems();
            List<VehicleProblem> bikeProblems = new List<VehicleProblem>();
            List<VehicleProblem> carProblems  = new List<VehicleProblem>();
       

            List<VehicleProblem> problemsList = db.VehicleProblems.Include(v => v.VehicleType).ToList();


            foreach (VehicleProblem singleProblem in problemsList)
            {
                if(singleProblem.VehicleTypeId==1)
                {
                    carProblems.Add(singleProblem);
                }
                else
                {
                    bikeProblems.Add(singleProblem);
                }
            }

            problemsModel.bikeProblems        = bikeProblems;
            problemsModel.carProblems         = carProblems;

            return View(problemsModel);
        }


        public ActionResult MakeBill()
        {
            
           

           return  RedirectToAction("Booking");
        }
    }
}