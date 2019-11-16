using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Repository.Repository
{
   public  class SupplierRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        public bool Add(Supplier supplier)
        {
            _dbContext.Suppliers.Add(supplier);
            return _dbContext.SaveChanges() > 0;
        }
        public List<Supplier> GetAll()
        {
            return _dbContext.Suppliers.ToList();
        }
        public bool Delete(int id)
        {
            Supplier asupplier = _dbContext.Suppliers.FirstOrDefault((c => c.Id == id));
            _dbContext.Suppliers.Remove(asupplier);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Supplier supplier)
        {
            Supplier asupplier = _dbContext.Suppliers.FirstOrDefault(c => c.Id == supplier.Id);
            if (asupplier != null)
            {
                asupplier.Code = supplier.Code;
                asupplier.Name = supplier.Name;
                asupplier.Address = supplier.Address;
                asupplier.Email = supplier.Email;
                asupplier.Contact = supplier.Contact;
                asupplier.Contact_Person = supplier.Contact_Person;

            }

            return _dbContext.SaveChanges() > 0;
        }
        public Supplier GetById(int id)
        {
            return _dbContext.Suppliers.FirstOrDefault(c => c.Id == id);
        }
    }
}
