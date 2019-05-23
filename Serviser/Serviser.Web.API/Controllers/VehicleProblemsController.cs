using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;

namespace Serviser.Web.API.Controllers
{
    public class VehicleProblemsController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/VehicleProblems
        public IQueryable<VehicleProblem> GetVehicleProblems()
        {
            return db.VehicleProblems;
        }

        // GET: api/VehicleProblems/5
        [ResponseType(typeof(VehicleProblem))]
        public IHttpActionResult GetVehicleProblem(int id)
        {
            VehicleProblem vehicleProblem = db.VehicleProblems.Find(id);
            if (vehicleProblem == null)
            {
                return NotFound();
            }

            return Ok(vehicleProblem);
        }

        // PUT: api/VehicleProblems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleProblem(int id, VehicleProblem vehicleProblem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleProblem.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicleProblem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleProblemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/VehicleProblems
        [ResponseType(typeof(VehicleProblem))]
        public IHttpActionResult PostVehicleProblem(VehicleProblem vehicleProblem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleProblems.Add(vehicleProblem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleProblem.Id }, vehicleProblem);
        }

        // DELETE: api/VehicleProblems/5
        [ResponseType(typeof(VehicleProblem))]
        public IHttpActionResult DeleteVehicleProblem(int id)
        {
            VehicleProblem vehicleProblem = db.VehicleProblems.Find(id);
            if (vehicleProblem == null)
            {
                return NotFound();
            }

            db.VehicleProblems.Remove(vehicleProblem);
            db.SaveChanges();

            return Ok(vehicleProblem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleProblemExists(int id)
        {
            return db.VehicleProblems.Count(e => e.Id == id) > 0;
        }
    }
}