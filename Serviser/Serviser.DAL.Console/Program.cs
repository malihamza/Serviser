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


            //List<User> mechanics = new ServiserDbContext().Users
            //   .Where(x=>x.CustomerProfile.Id==null ).ToList();

            //foreach(User u in mechanics)
            //{
            //    System.Console.WriteLine(u.FirstName+"   "+u.MechanicProfile.Id);
            //}
            //System.Console.WriteLine("Seeding...");
            ServiserDbContext db = new ServiserDbContext();
            List<User> user = db.Users.Where(x=>x.Longitude>=74.1&&x.Latitude>=31 &&x.MechanicProfile.Id!=null).ToList();
            foreach(User user1 in user)
            {
                System.Console.WriteLine(user1.FirstName);
            }
            
            //System.Console.WriteLine((DateTime.Now-user.RegisterationDateTime).TotalSeconds);

         
            //    while (db.Database.Exists())
            //  {
            //      System.Console.WriteLine("Database Already Exists. Manually Delete the database and hit Enter.");
            //    System.Console.ReadLine();
            // }

             //new ServiserDbInitialSeed().Run();

             //  System.Console.WriteLine("Seeding Done.");
            //System.Console.ReadLine();
        }
    }
}
