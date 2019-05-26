using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Serviser.Web.Controllers
{
    public class VehicleController : Controller
    {
        // GET: Vehicle
        public ActionResult ViewAllVehicles()
        {
            return View();
        }

        public ActionResult AddVehicle()
        {
            return View();
        }

        public ActionResult DeleteVehicle()
        {
            return View();
        }
    }
}