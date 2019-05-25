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
    public class RoleService
    {
        private ServiserDbContext _dbContext;
        private ServiserDbContext DbContext {
            get
            {
                return _dbContext ?? (_dbContext = new ServiserDbContext());
            }
        }

        public RoleService()
        { }

        public RoleService(ServiserDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IdentityRole GetRoleByName(string name)
        {
            return DbContext.Roles.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
