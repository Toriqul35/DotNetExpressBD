using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetExpress.Model;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;
using AutoMapper;

namespace DotNetExpress.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        
        [HttpGet]
        public ActionResult Add()
        {

            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }

        [HttpPost]
        public ActionResult Add(CustomerViewModel customerViewModel)
        {
            string message = "";

            //Customer customer = new Customer();
            //customer.Code = customerViewModel.Code;
            //customer.Name = customerViewModel.Name;
            //customer.Address = customerViewModel.Address;
            //customer.Email = customerViewModel.Email;
            //customer.Contact = customerViewModel.Contact;
            //customer.Loyolty_Point = customerViewModel.Code;
            if (ModelState.IsValid)
            {
                Customer customer = Mapper.Map<Customer>(customerViewModel);

              if (_customerManager.Add(customer))
                {
                    message = "Saved";
                }
                  else
                   {
                       message = "Not Saved";
                   }
            }
            else
            {
                message = "ModelState Failed";
            }
            
                ViewBag.Message = message;
                customerViewModel.Customers = _customerManager.GetAll();
               
                return RedirectToAction("Index", "Home");
        
        
        }


        public ActionResult AllCustomer(Customer customer )
        {

            CustomerViewModel customerViewModel = new CustomerViewModel();
            //customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
    }
}