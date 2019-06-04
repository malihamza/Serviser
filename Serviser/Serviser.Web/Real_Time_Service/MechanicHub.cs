using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;
using Serviser.DAL.Entity;
using Serviser.Web.Models;

namespace Serviser.Web.Real_Time_Service
{
    public class MechanicHub : Hub
    {
        public void Hello()
        {
            Clients.All.hello();
        }
        public void GetMechnaics(Location loc)
        {
            List<MechanicProfile> lis = new List<MechanicProfile>();
            MechanicProfile profile = new MechanicProfile();
            profile.Latitude = loc.Latitude + (float)1 / 1000;
            profile.Longitude = loc.Longitude + (float)1 / 1000;
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
            profile.Longitude = loc.Longitude - (float)2 / 1000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude - (float)2 / 1000;
            profile.Longitude = loc.Longitude + (float)1 / 1000;
            lis.Add(profile);

            profile = new MechanicProfile();
            profile.Latitude = loc.Latitude + (float)3 / 1000;
            profile.Longitude = loc.Longitude + (float)3 / 1000;
            lis.Add(profile);

            Clients.All.UpdateMechanics(lis);
        }

    }
}