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
    public class MechanicProfilesController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/MechanicProfiles
        public IQueryable<MechanicProfile> GetMechanicProfiles()
        {
            return db.MechanicProfiles;
        }

        // GET: api/MechanicProfiles/5
        [ResponseType(typeof(MechanicProfile))]
        public IHttpActionResult GetMechanicProfile(int id)
        {
            MechanicProfile mechanicProfile = db.MechanicProfiles.Find(id);
            if (mechanicProfile == null)
            {
                return NotFound();
            }

            return Ok(mechanicProfile);
        }

        // PUT: api/MechanicProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMechanicProfile(int id, MechanicProfile mechanicProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mechanicProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(mechanicProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechanicProfileExists(id))
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

        // POST: api/MechanicProfiles
        [ResponseType(typeof(MechanicProfile))]
        public IHttpActionResult PostMechanicProfile(MechanicProfile mechanicProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MechanicProfiles.Add(mechanicProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mechanicProfile.Id }, mechanicProfile);
        }

        // DELETE: api/MechanicProfiles/5
        [ResponseType(typeof(MechanicProfile))]
        public IHttpActionResult DeleteMechanicProfile(int id)
        {
            MechanicProfile mechanicProfile = db.MechanicProfiles.Find(id);
            if (mechanicProfile == null)
            {
                return NotFound();
            }

            db.MechanicProfiles.Remove(mechanicProfile);
            db.SaveChanges();

            return Ok(mechanicProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MechanicProfileExists(int id)
        {
            return db.MechanicProfiles.Count(e => e.Id == id) > 0;
        }
    }
}