using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DotNetExpress.Model.Model;
using DotNetExpress.Repository.Repository;
using System.Threading.Tasks;

namespace DotNetExpress.BLL.BLL
{
    public class PurchaseManager
    {
        PurchaseRepository _purchaseRepository = new PurchaseRepository();

        public bool Add(Purchase purchase)
        {
            return _purchaseRepository.Add(purchase);
        }

        public bool Delete(int id)
        {
            return _purchaseRepository.Delete(id);
        }
        public List<Purchase> GetAll()
        {
            return _purchaseRepository.GetAll();
        }
        public Purchase GetById(int id)
        {
            return _purchaseRepository.GetById(id);
        }

    }
}
