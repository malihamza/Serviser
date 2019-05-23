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
    public class MechanicNotificationsController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/MechanicNotifications
        public IQueryable<MechanicNotification> GetMechanicNotifications()
        {
            return db.MechanicNotifications;
        }

        // GET: api/MechanicNotifications/5
        [ResponseType(typeof(MechanicNotification))]
        public IHttpActionResult GetMechanicNotification(int id)
        {
            MechanicNotification mechanicNotification = db.MechanicNotifications.Find(id);
            if (mechanicNotification == null)
            {
                return NotFound();
            }

            return Ok(mechanicNotification);
        }

        // PUT: api/MechanicNotifications/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMechanicNotification(int id, MechanicNotification mechanicNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mechanicNotification.Id)
            {
                return BadRequest();
            }

            db.Entry(mechanicNotification).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechanicNotificationExists(id))
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

        // POST: api/MechanicNotifications
        [ResponseType(typeof(MechanicNotification))]
        public IHttpActionResult PostMechanicNotification(MechanicNotification mechanicNotification)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MechanicNotifications.Add(mechanicNotification);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mechanicNotification.Id }, mechanicNotification);
        }

        // DELETE: api/MechanicNotifications/5
        [ResponseType(typeof(MechanicNotification))]
        public IHttpActionResult DeleteMechanicNotification(int id)
        {
            MechanicNotification mechanicNotification = db.MechanicNotifications.Find(id);
            if (mechanicNotification == null)
            {
                return NotFound();
            }

            db.MechanicNotifications.Remove(mechanicNotification);
            db.SaveChanges();

            return Ok(mechanicNotification);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MechanicNotificationExists(int id)
        {
            return db.MechanicNotifications.Count(e => e.Id == id) > 0;
        }
    }
}