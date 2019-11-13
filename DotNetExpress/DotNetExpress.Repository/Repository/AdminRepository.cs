using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Repository.Repository
{
   public class AdminRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool AddminLogin(Admin_Login admin_Login)
        {
            _dbContext.Admin_Logins.Add(admin_Login);
            return _dbContext.SaveChanges() > 0;
        }
    }
}
