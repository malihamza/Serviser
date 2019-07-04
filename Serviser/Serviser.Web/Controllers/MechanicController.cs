using Serviser.DAL.Service;
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
            return View();
        }


    }
}