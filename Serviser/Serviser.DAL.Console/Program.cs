using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Serviser.DAL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiserDbContext db = new ServiserDbContext();
            VehicleType vt = new VehicleType();
            vt.Name = "Test";
            db.VehicleTypes.Add(vt);
            db.SaveChanges();
        }
    }
}
