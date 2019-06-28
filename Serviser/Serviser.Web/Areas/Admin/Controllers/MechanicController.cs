using Microsoft.AspNet.Identity.EntityFramework;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using Serviser.DAL.Service;
using Serviser.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Serviser.Web.Areas.Admin.Controllers
{
    public class MechanicController : Controller
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: Admin/Mechanic
        public ActionResult Index()
        {
            IdentityRole role = RoleService.GetRoleByName("Mechanic");

            List<User> mechanics = new ServiserDbContext().Users
                .Where(x => x.Roles.Select(y => y.RoleId).Contains(role.Id)).ToList();
            return View(mechanics);
        }

        public ActionResult Register()
        {
            RegisterMechanicViewModel model = new RegisterMechanicViewModel();
            if (TempData["model"] != null)
                model = (RegisterMechanicViewModel)TempData["model"];
            if (TempData["modelStateErrors"] != null)
            {
                var errors = ((IEnumerable<ModelError>)TempData["modelStateErrors"]);
                foreach (var err in errors)
                {
                    ModelState.AddModelError("", err.ErrorMessage);
                }
            }

            model.RoleName = "Mechanic";
            return View(model);
        }

        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            User vehicleProblem = db.Users.Find(id);
            if (vehicleProblem == null)
            {
                return HttpNotFound();
            }
            return View(vehicleProblem);
        }
    }
}