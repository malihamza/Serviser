using Microsoft.AspNet.Identity;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Serviser.DAL.Extension
{
    public static class UserHelper
    {
        public static User GetUser(this IIdentity user)
        {
            string id = user.GetUserId();
            ServiserDbContext db = new ServiserDbContext();
            return db.Users.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
