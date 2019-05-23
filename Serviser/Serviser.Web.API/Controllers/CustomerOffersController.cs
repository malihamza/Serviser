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
    public class CustomerOffersController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/CustomerOffers
        public IQueryable<CustomerOffer> GetBustomerOffers()
        {
            return db.BustomerOffers;
        }

        // GET: api/CustomerOffers/5
        [ResponseType(typeof(CustomerOffer))]
        public IHttpActionResult GetCustomerOffer(int id)
        {
            CustomerOffer customerOffer = db.BustomerOffers.Find(id);
            if (customerOffer == null)
            {
                return NotFound();
            }

            return Ok(customerOffer);
        }

        // PUT: api/CustomerOffers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerOffer(int id, CustomerOffer customerOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerOffer.Id)
            {
                return BadRequest();
            }

            db.Entry(customerOffer).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerOfferExists(id))
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

        // POST: api/CustomerOffers
        [ResponseType(typeof(CustomerOffer))]
        public IHttpActionResult PostCustomerOffer(CustomerOffer customerOffer)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BustomerOffers.Add(customerOffer);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerOffer.Id }, customerOffer);
        }

        // DELETE: api/CustomerOffers/5
        [ResponseType(typeof(CustomerOffer))]
        public IHttpActionResult DeleteCustomerOffer(int id)
        {
            CustomerOffer customerOffer = db.BustomerOffers.Find(id);
            if (customerOffer == null)
            {
                return NotFound();
            }

            db.BustomerOffers.Remove(customerOffer);
            db.SaveChanges();

            return Ok(customerOffer);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerOfferExists(int id)
        {
            return db.BustomerOffers.Count(e => e.Id == id) > 0;
        }
    }
}