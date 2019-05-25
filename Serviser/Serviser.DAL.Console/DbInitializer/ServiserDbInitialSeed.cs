using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviser.DAL.Console.DbInitializer
{
    class ServiserDbInitialSeed
    {
        public ServiserDbContext DbContext { get; set; }
        public ServiserDbInitialSeed()
        {
            DbContext = new ServiserDbContext();
        }

        public void Run()
        {
            SeedRoles();
            SeedVehicleTypes();

            DbContext.SaveChanges();
        }

        private void SeedRoles()
        {
            DbContext.Roles.Add(new IdentityRole { Id = "1", Name = "BasicUser" });
            DbContext.Roles.Add(new IdentityRole { Id = "2", Name = "Mechanic" });
            DbContext.Roles.Add(new IdentityRole { Id = "3", Name = "Admin" });
        }

        private void SeedVehicleTypes()
        {
            DbContext.VehicleTypes.Add(new VehicleType { Name = "Car" });
            DbContext.VehicleTypes.Add(new VehicleType { Name = "Bike" });
        }
    }
}
