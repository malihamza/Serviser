using Microsoft.AspNet.Identity.EntityFramework;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviser.DAL.Service
{
    public static class VehicleTypeService
    {
        public const string CAR = "Car";
        public const string BIKE = "Bike";

        public static ServiserDbContext ServiserDbContext { get; set; } = new ServiserDbContext();

        public static VehicleType GetVehicleTypeByName(string name)
        {
            return ServiserDbContext.VehicleTypes.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
