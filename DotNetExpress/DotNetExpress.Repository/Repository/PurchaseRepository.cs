using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;
using DotNetExpress.Model.Model;
using System.Threading.Tasks;

namespace DotNetExpress.Repository.Repository
{
    public class PurchaseRepository
    {
        ProjectDbContext _dbContext = new ProjectDbContext();

        public bool Add(Purchase purchase)
        {
            _dbContext.Purchases.Add(purchase);
            return _dbContext.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            Purchase apurchase = _dbContext.Purchases.FirstOrDefault((c => c.Id == id));
            _dbContext.Purchases.Remove(apurchase);
            return _dbContext.SaveChanges() > 0;
        }

        public List<Purchase> GetAll()
        {
            return _dbContext.Purchases.ToList();

        }
        public Purchase GetById(int id)
        {

            return _dbContext.Purchases.FirstOrDefault((c => c.Id == id));
        }
    }
}