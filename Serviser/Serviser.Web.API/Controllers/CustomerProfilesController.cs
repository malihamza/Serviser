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
    public class CustomerProfilesController : ApiController
    {
        private ServiserDbContext db = new ServiserDbContext();

        // GET: api/CustomerProfiles
        public IQueryable<CustomerProfile> GetCustomerProfiles()
        {
            return db.CustomerProfiles;
        }

        // GET: api/CustomerProfiles/5
        [ResponseType(typeof(CustomerProfile))]
        public IHttpActionResult GetCustomerProfile(int id)
        {
            CustomerProfile customerProfile = db.CustomerProfiles.Find(id);
            if (customerProfile == null)
            {
                return NotFound();
            }

            return Ok(customerProfile);
        }

        // PUT: api/CustomerProfiles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCustomerProfile(int id, CustomerProfile customerProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customerProfile.Id)
            {
                return BadRequest();
            }

            db.Entry(customerProfile).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerProfileExists(id))
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

        // POST: api/CustomerProfiles
        [ResponseType(typeof(CustomerProfile))]
        public IHttpActionResult PostCustomerProfile(CustomerProfile customerProfile)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CustomerProfiles.Add(customerProfile);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = customerProfile.Id }, customerProfile);
        }

        // DELETE: api/CustomerProfiles/5
        [ResponseType(typeof(CustomerProfile))]
        public IHttpActionResult DeleteCustomerProfile(int id)
        {
            CustomerProfile customerProfile = db.CustomerProfiles.Find(id);
            if (customerProfile == null)
            {
                return NotFound();
            }

            db.CustomerProfiles.Remove(customerProfile);
            db.SaveChanges();

            return Ok(customerProfile);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomerProfileExists(int id)
        {
            return db.CustomerProfiles.Count(e => e.Id == id) > 0;
        }
    }
}