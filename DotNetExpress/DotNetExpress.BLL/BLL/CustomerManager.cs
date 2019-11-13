using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DotNetExpress.Repository.Repository;
using DotNetExpress.Model.Model;

namespace DotNetExpress.BLL.BLL
{
    public class CustomerManager
    {

        CustomerRepository _customerRepository = new CustomerRepository();
        public bool Add(Customer customer)
        {
            return _customerRepository.Add(customer);
        }
        public List<Customer>GetAll()
        {
            return _customerRepository.GetAll();
        }
    }
}
