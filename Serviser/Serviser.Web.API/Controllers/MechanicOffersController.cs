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
    public class MechanicOffersController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/MechanicOffers
        public IQueryable<MechanicOffer> GetMechanicOffers()
        {
            return db.MechanicOffers;
        }

        // GET: api/MechanicOffers/5
        [ResponseType(typeof(MechanicOffer))]
        public IHttpActionResult GetMechanicOffer(int id)
        {
            MechanicOffer mechanicOffer = db.MechanicOffers.Find(id);
            if (mechanicOffer == null)
            {
                return NotFound();
            }

            return Ok(mechanicOffer);
        }

        // PUT: api/MechanicOffers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutMechanicOffer(int id, MechanicOffer mechanicOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != mechanicOffer.Id)
            {
                return BadRequest();
            }

            db.Entry(mechanicOffer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MechanicOfferExists(id))
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

        // POST: api/MechanicOffers
        [ResponseType(typeof(MechanicOffer))]
        public IHttpActionResult PostMechanicOffer(MechanicOffer mechanicOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.MechanicOffers.Add(mechanicOffer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = mechanicOffer.Id }, mechanicOffer);
        }

        // DELETE: api/MechanicOffers/5
        [ResponseType(typeof(MechanicOffer))]
        public IHttpActionResult DeleteMechanicOffer(int id)
        {
            MechanicOffer mechanicOffer = db.MechanicOffers.Find(id);
            if (mechanicOffer == null)
            {
                return NotFound();
            }

            db.MechanicOffers.Remove(mechanicOffer);
            db.SaveChanges();

            return Ok(mechanicOffer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool MechanicOfferExists(int id)
        {
            return db.MechanicOffers.Count(e => e.Id == id) > 0;
        }
    }
}