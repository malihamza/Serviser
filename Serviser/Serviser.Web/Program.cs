using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Serviser.DAL.Console.DbInitializer;
using System.Data.Entity;
using System.Data.SqlClient;

namespace Serviser.DAL.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServiserDbContext db = new ServiserDbContext();
            List<VehicleProblem> lis = db.VehicleProblems.Include(v => v.VehicleType).ToList();
          //  List<VehicleProblem> lis = vehicleProblems.ToList();
            foreach (VehicleProblem d in lis)
            {
                System.Console.WriteLine(d.Name + "   " + d.EstimatedPrice + " ==> " + d.VehicleTypeId);
            }
            //System.Console.WriteLine("Seeding...");

            //ServiserDbContext db = new ServiserDbContext();

            //while (db.Database.Exists())
            //{
            //    System.Console.WriteLine("Database Already Exists. Manually Delete the database and hit Enter.");
            //    System.Console.ReadLine();
            //}

            //new ServiserDbInitialSeed().Run();

            //System.Console.WriteLine("Seeding Done.");
            //System.Console.ReadLine();
        }
    }
}
