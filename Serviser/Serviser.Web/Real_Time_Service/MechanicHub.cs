using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Serviser.DAL.Entity;
using Serviser.Web.Models;
using Serviser.DAL.Context;
using Serviser.DAL.Extension;
namespace Serviser.Web.Real_Time_Service
{
    public class MechanicHub : Hub
    {
        private ServiserDbContext serviserDb = new ServiserDbContext();
        public void Hello()
        {
            Clients.All.hello();
        }


        public void saveMyLocationAndTime(Location location,string userId)
        {

            User customer = serviserDb.Users.Find(userId);
            customer.Longitude = location.Longitude;
            customer.Latitude = location.Latitude;
            customer.LastOnlineTime = DateTime.Now;
            serviserDb.SaveChanges();
        }

        public void UpdateLocationOfMechanic(Location location)
        {
          //  Clients.Users()
            Clients.Caller.ShowLocation(location);
        }
        public void GetMechanics(Location loc)
        {
            List<User> lis = new List<User>();
            User profile = new User();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
            profile.Longitude = loc.Longitude + (float)1 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude - (float)8 / 10000;
            profile.Longitude = loc.Longitude - (float)8 / 10000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)2 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
            profile.Longitude = loc.Longitude - (float)2 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)1 / 1000;
            lis.Add(profile);

            profile = new User();
            profile.Latitude = loc.Latitude + (float)3 / 1000;
            profile.Longitude = loc.Longitude + (float)3 / 1000;
            lis.Add(profile);

            Clients.All.UpdateMechanics(lis);
        }

    }
}