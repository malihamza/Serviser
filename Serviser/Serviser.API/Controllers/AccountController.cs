using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Serviser.DAL.Entity;
using Serviser.DAL.Context;

namespace Serviser.API.Controllers
{
    
    public class AccountController : ApiController
    {
        ServiserDbContext serviserDbContext = new ServiserDbContext();
        // GET: api/Account
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }
        public string Get(int user)
        {

            throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // For user to login
        [HttpGet]
        public string Login( int user)
        {

             throw new HttpResponseException(HttpStatusCode.NotFound);
        }

        // POST: api/Account
        public void Post([FromBody]string value)
        {

        }

        // PUT: api/Account/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Account/5
        public void Delete(int id)
        {
        }
    }
}
