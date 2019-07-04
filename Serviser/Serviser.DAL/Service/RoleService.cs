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
    public static class RoleService
    {
        public const string MECHANIC = "Mechanic"; 
        public const string BASIC_USER = "BasicUser"; 
        public const string ADMIN = "Admin";

        public static ServiserDbContext ServiserDbContext { get; set; } = new ServiserDbContext(); 

        public static IdentityRole GetRoleByName(string name)
        {
            return ServiserDbContext.Roles.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
