using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Serviser.DAL.Entity;
using Serviser.DAL.Context;

namespace Serviser.Web.Controllers
{
    public class ServiceApiController : ApiController
    {
        [HttpPost]
        public IHttpActionResult FindMechanic([FromBody]User user,VehicleType vehicle,List<VehicleProblem> vehicleProblems,float longitude,float latitude)
        {

            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult CallMechanic([FromBody]User user, float logitude, float latitude)
        {

            return NotFound();
        }
        [HttpPost]
        public IHttpActionResult MakeBill([FromBody]List<VehicleProblem> vehicleProblems,float userLongitude, float userLatitude, float mechLongitude, float mechLatitude)
        {

            return NotFound();
        }

    }
}
