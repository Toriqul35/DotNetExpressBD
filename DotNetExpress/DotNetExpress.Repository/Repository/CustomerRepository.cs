using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Repository.Repository
{
    public class CustomerRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Customer customer)
        {
            _dbContext.Customers.Add(customer);
            return _dbContext.SaveChanges() > 0;
        }
        public List<Customer> GetAll()
        {
            return _dbContext.Customers.ToList();
        }
    }
}
