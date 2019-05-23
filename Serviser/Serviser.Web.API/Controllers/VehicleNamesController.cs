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
    public class VehicleNamesController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/VehicleNames
        public IQueryable<VehicleName> GetVehicleNames()
        {
            return db.VehicleNames;
        }

        // GET: api/VehicleNames/5
        [ResponseType(typeof(VehicleName))]
        public IHttpActionResult GetVehicleName(int id)
        {
            VehicleName vehicleName = db.VehicleNames.Find(id);
            if (vehicleName == null)
            {
                return NotFound();
            }

            return Ok(vehicleName);
        }

        // PUT: api/VehicleNames/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutVehicleName(int id, VehicleName vehicleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleName.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicleName).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleNameExists(id))
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

        // POST: api/VehicleNames
        [ResponseType(typeof(VehicleName))]
        public IHttpActionResult PostVehicleName(VehicleName vehicleName)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleNames.Add(vehicleName);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = vehicleName.Id }, vehicleName);
        }

        // DELETE: api/VehicleNames/5
        [ResponseType(typeof(VehicleName))]
        public IHttpActionResult DeleteVehicleName(int id)
        {
            VehicleName vehicleName = db.VehicleNames.Find(id);
            if (vehicleName == null)
            {
                return NotFound();
            }

            db.VehicleNames.Remove(vehicleName);
            db.SaveChanges();

            return Ok(vehicleName);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleNameExists(int id)
        {
            return db.VehicleNames.Count(e => e.Id == id) > 0;
        }
    }
}