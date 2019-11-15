using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Repository.Repository
{
   public class ProductRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();
        
        public bool Add (Product product)
        {
            _dbContext.products.Add(product);
            return _dbContext.SaveChanges() > 0;

        }

       
        public bool Delete(int id)
        {
            Product aproduct = _dbContext.products.FirstOrDefault(c => c.Id == id);
            _dbContext.products.Remove(aproduct);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Product product)
        {
            Product aproduct = _dbContext.products.FirstOrDefault(c => c.Id == product.Id);

            if (aproduct != null)
            {                
                aproduct.Code = aproduct.Code;
                aproduct.Name = aproduct.Name;
                aproduct.ReorderLevel = aproduct.ReorderLevel;
                aproduct.Description = aproduct.Description;
                               
            }


            return _dbContext.SaveChanges() > 0;
        }
        public List<Product> GetAll()
        {
            return _dbContext.products.ToList();
        }
        public Product GetById(int id)
        {
            return _dbContext.products.FirstOrDefault(c => c.Id == id);
        }

    }
}
