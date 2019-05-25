using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Serviser.DAL.Entity;
namespace Serviser.Web.Controllers
{
    public class ServicesController : Controller
    {
        // GET: Services
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult getMechanics(Location loc)
        {
            List<MechanicProfile> lis = new List<MechanicProfile>();
            MechanicProfile profile = new MechanicProfile();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
            profile.Longitude = loc.Longitude+ (float)1 / 1000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude - (float)8 / 10000;
            profile.Longitude = loc.Longitude - (float)8 / 10000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)2 / 1000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
            profile.Longitude = loc.Longitude - (float) 2/ 1000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)1 / 1000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude + (float)3 / 1000;
            profile.Longitude = loc.Longitude + (float)3 / 1000;
            lis.Add(profile);

            return Json(lis);
        }
    }
}