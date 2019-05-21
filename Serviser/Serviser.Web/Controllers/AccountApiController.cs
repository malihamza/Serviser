using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;
namespace Serviser.Web.Controllers
{
    public class AccountApiController : ApiController
    {
        ServiserDbContext ServiserDbContext = new ServiserDbContext();
        // GET: api/AccountApi
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/AccountApi/5
        public string Get(int id)
        {
            return "value";
        }
        [HttpPost]
        public IHttpActionResult LoginUser([FromBody] User user)
        {
            bool isExist = ServiserDbContext.Users.Any(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash);
            bool isUser = false;//To check wether he exist as user or not
            if (isExist)
            {
                isUser = true;
            }
            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult LoginMechanic([FromBody] User user)
        {
            bool isExist = ServiserDbContext.Users.Any(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash);
            bool isMechanic = false;//To check wether he exist as user or not
            if (isExist)
            {
                isMechanic = true;
            }
            return NotFound();
        }

        [HttpPost]
        public IHttpActionResult SignUpUser([FromBody] User user)
        {
            bool isExist = ServiserDbContext.Users.Any(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash);
            bool isUser = false;//To check wether he exist as user or not
            if (isExist)
            {
                isUser = true;
            }
            return Ok();
        }
        [HttpPost]
        public IHttpActionResult SignUpMechanic([FromBody] User user)
        {
            bool isExist = ServiserDbContext.Users.Any(x => x.Email == user.Email && x.PasswordHash == user.PasswordHash);
            bool isMechanic = false;//To check wether he exist as user or not
            if (isExist)
            {
                isMechanic = true;
            }
            return Ok() ;
        }

        // POST: api/AccountApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/AccountApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/AccountApi/5
        public void Delete(int id)
        {
        }
    }
}
