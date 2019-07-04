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


        public void SaveMyLocationAndTime(Location location,string userId)
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
        public void GetMechanics(Location location)
        {
            List<User> lis = new List<User>();

            List<User> mechanics = serviserDb.Users.Where(
                                                        x => x.MechanicProfile.Id != null
                                                         && (x.Longitude <= (location.Longitude + 3 / 1000)
                                                   || x.Longitude >= (location.Longitude - 3 / 1000)
                                                   || x.Latitude <= (location.Latitude + 3 / 1000)
                                                   || x.Latitude >= (location.Latitude - 3 / 1000))).ToList();

            foreach(User user in mechanics)
            {
                if(user.Longitude!=null&& user.Latitude != null
                    &&(DateTime.Now-(DateTime)user.LastOnlineTime).TotalSeconds<10)
                {
                    lis.Add(user);
                }
            }
            Clients.Caller.UpdateMechanics(lis);
        }


        public void GetSingleMecahnic(string id)
        {
            User customer = serviserDb.Users.Find(id);
            User mechanic = serviserDb.Users.Where(x => x.MechanicProfile.Id != null
                                                    && (x.Longitude <= (customer.Longitude + 3 / 100)
                                                   || x.Longitude >= (customer.Longitude - 3 / 100)
                                                   || x.Latitude <= (customer.Latitude + 3 / 100)
                                                   || x.Latitude >= (customer.Latitude - 3 / 100))).FirstOrDefault();

            Clients.Caller.ShowMechanicInfo(mechanic);
        }


        public void PutRequestToMechanic(string userId,string mechanicId)
        {
            User customer = serviserDb.Users.Find(userId);
            Clients.User(mechanicId).ShowCustomerRequest(customer);
        }

    }
}