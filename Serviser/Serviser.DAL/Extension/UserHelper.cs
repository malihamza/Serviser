using Microsoft.AspNet.Identity;
using Serviser.DAL.Context;
using Serviser.DAL.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Serviser.DAL.Extension
{
    public static class UserHelper
    {
        public static User GetUser(this IIdentity user, Boolean eagerLoad = false)
        {
            string id = user.GetUserId();
            ServiserDbContext db = new ServiserDbContext();

            User u = eagerLoad ?
                db.Users.Where(x => x.Id == id)
                .Include(x => x.MechanicProfile)
                .Include(x => x.CustomerProfile)
                .Include(x => x.Roles)
                .FirstOrDefault()
                :
                db.Users.Where(x => x.Id == id).FirstOrDefault();

            return u;
        }
    }
}
