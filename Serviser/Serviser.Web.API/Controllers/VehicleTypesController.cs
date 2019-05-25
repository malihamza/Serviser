using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;

namespace Serviser.Web.API.Controllers
{
    public class VehicleTypesController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/VehicleTypes
        public IQueryable<VehicleType> GetVehicleTypes()
        {
            return db.VehicleTypes;
        }

        // GET: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public async Task<IHttpActionResult> GetVehicleType(int id)
        {
            VehicleType vehicleType = await db.VehicleTypes.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            return Ok(vehicleType);
        }

        // PUT: api/VehicleTypes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVehicleType(int id, VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != vehicleType.Id)
            {
                return BadRequest();
            }

            db.Entry(vehicleType).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VehicleTypeExists(id))
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

        // POST: api/VehicleTypes
        [ResponseType(typeof(VehicleType))]
        public async Task<IHttpActionResult> PostVehicleType(VehicleType vehicleType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.VehicleTypes.Add(vehicleType);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = vehicleType.Id }, vehicleType);
        }

        // DELETE: api/VehicleTypes/5
        [ResponseType(typeof(VehicleType))]
        public async Task<IHttpActionResult> DeleteVehicleType(int id)
        {
            VehicleType vehicleType = await db.VehicleTypes.FindAsync(id);
            if (vehicleType == null)
            {
                return NotFound();
            }

            db.VehicleTypes.Remove(vehicleType);
            await db.SaveChangesAsync();

            return Ok(vehicleType);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VehicleTypeExists(int id)
        {
            return db.VehicleTypes.Count(e => e.Id == id) > 0;
        }
    }
}           