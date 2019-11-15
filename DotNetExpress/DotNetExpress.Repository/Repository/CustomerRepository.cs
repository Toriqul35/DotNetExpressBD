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
        public bool Delete(int id)
        {
            Customer acustomer = _dbContext.Customers.FirstOrDefault((c => c.Id == id));
            _dbContext.Customers.Remove(acustomer);
            return _dbContext.SaveChanges() > 0;
        }
       public bool Update(Customer customer)
       {
                Customer acustomer = _dbContext.Customers.FirstOrDefault(c => c.Id == customer.Id);
               if (acustomer != null)
                     {
                     acustomer.Code = customer.Code;
                     acustomer.Name = customer.Name;

               }

              return _dbContext.SaveChanges() > 0;
       }
       
    }
}
