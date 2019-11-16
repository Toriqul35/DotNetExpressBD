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
        public bool Add(Product product)
        {
            _dbContext.Products.Add(product);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Delete(int id)
        {
            Product aproduct = _dbContext.Products.FirstOrDefault((c => c.Id == id));
            _dbContext.Products.Remove(aproduct);
            return _dbContext.SaveChanges() > 0;
        }
        public bool Update(Product product)
        {
            Product aproduct = _dbContext.Products.FirstOrDefault(c => c.Id == product.Id);
            if (aproduct != null)
            {
                aproduct.Code = product.Code;
                aproduct.Name = product.Name;
                aproduct.Reorder_lavel = product.Reorder_lavel;
                aproduct.Description = product.Description;
            }

            return _dbContext.SaveChanges() > 0;
        }

        public List<Product> GetAll()
        {
            return _dbContext.Products.ToList();
        }
        public Product GetById(int id)
        {

            return _dbContext.Products.FirstOrDefault((c => c.Id == id));
        }
    }
}
