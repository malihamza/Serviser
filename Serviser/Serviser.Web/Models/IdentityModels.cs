﻿//using System.Data.Entity;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;

//namespace Serviser.Web.Models
//{
//    // You can add profile data for the user by adding more properties to your User class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
//    public class User : IdentityUser
//    {
//        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }
//    }

//    public class ServiserDbContext : IdentityDbContext<User>
//    {
//        public ServiserDbContext()
//            : base("DefaultConnection", throwIfV1Schema: false)
//        {
//        }

//        public static ServiserDbContext Create()
//        {
//            return new ServiserDbContext();
//        }
//    }
//}