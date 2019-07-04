using Serviser.DAL.Context;
using Serviser.DAL.Service;
using Serviser.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serviser.Web.Controllers
{
    [Authorize(Roles = RoleService.MECHANIC)]
    public class MechanicController : Controller
    {
        // GET: Mechanic
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Profile()
        {
            return View();
        }

        public ActionResult GenerateBill()
        {
            ServiserDbContext db = new ServiserDbContext();
            Problems problemsModel = new Problems();
            problemsModel.BikeProblems = db.VehicleProblems
                .Where(x => x.VehicleType.Name == VehicleTypeService.BIKE)
                .ToList();
            problemsModel.CarProblems = db.VehicleProblems
                .Where(x => x.VehicleType.Name == VehicleTypeService.CAR)
                .ToList();
            return View(problemsModel);
        }


    }
}