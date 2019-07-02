using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;

namespace Serviser.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin")]
    public class VehicleProblemsController : Controller
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: Adminx/VehicleProblems
        public ActionResult Index()
        {
            var vehicleProblems = db.VehicleProblems.Include(v => v.VehicleType);
            return View(vehicleProblems.ToList());
        }

        // GET: Adminx/VehicleProblems/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleProblem vehicleProblem = db.VehicleProblems.Find(id);
            if (vehicleProblem == null)
            {
                return HttpNotFound();
            }
            return View(vehicleProblem);
        }

        // GET: Adminx/VehicleProblems/Create
        public ActionResult Create()
        {
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name");
            return View();
        }

        // POST: Adminx/VehicleProblems/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name,Description,EstimatedPrice,VehicleTypeId",Exclude ="VehicleType")] VehicleProblem vehicleProblem)
        {
            if (ModelState.IsValid)
            {
                db.VehicleProblems.Add(vehicleProblem);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name", vehicleProblem.VehicleTypeId);
            return View(vehicleProblem);
        }

        // GET: Adminx/VehicleProblems/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleProblem vehicleProblem = db.VehicleProblems.Find(id);
            if (vehicleProblem == null)
            {
                return HttpNotFound();
            }
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name", vehicleProblem.VehicleTypeId);
            return View(vehicleProblem);
        }

        // POST: Adminx/VehicleProblems/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,EstimatedPrice,VehicleTypeId")] VehicleProblem vehicleProblem)
        {
            if (ModelState.IsValid)
            {
                db.Entry(vehicleProblem).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.VehicleTypeId = new SelectList(db.VehicleTypes, "Id", "Name", vehicleProblem.VehicleTypeId);
            return View(vehicleProblem);
        }

        // GET: Adminx/VehicleProblems/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            VehicleProblem vehicleProblem = db.VehicleProblems.Find(id);
            if (vehicleProblem == null)
            {
                return HttpNotFound();
            }
            return View(vehicleProblem);
        }

        // POST: Adminx/VehicleProblems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            VehicleProblem vehicleProblem = db.VehicleProblems.Find(id);
            db.VehicleProblems.Remove(vehicleProblem);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
