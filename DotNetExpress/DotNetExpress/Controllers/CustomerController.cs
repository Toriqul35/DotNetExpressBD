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

            return View(customerViewModel);


        }


        public ActionResult AllCustomer(Customer customer)
        {
            CustomerManager _customerManager = new CustomerManager();
            ModelState.Clear();
            return View(_customerManager.GetAll());
        }

        public ActionResult Delete(int id)
        {
            try
            {
                CustomerManager _customerManager = new CustomerManager();
                if (_customerManager.Delete(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("AllCustomer");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var customer = _customerManager.GetById(id);
            CustomerViewModel customerViewModel = Mapper.Map<CustomerViewModel>(customer);
            customerViewModel.Customers = _customerManager.Add();

            return View(customerViewModel);
            
        }
        [HttpPost]
        public ActionResult Update(CustomerViewModel customerViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Customer customer = Mapper.Map<Customer>(customerViewModel);

                if (_customerManager.Update(customer))
                {
                    message = "Updated";
                }
                else
                {
                    message = "Not Updated";
                }
            }
            else
            {
                message = "Update Failed";
            }

            ViewBag.Message = message;
            customerViewModel.Customers = _customerManager.Add();
            return View(customerViewModel);
        }
        [HttpGet]
        public ActionResult Search()
        {

            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.Customers = _customerManager.Add();

            return View(customerViewModel);
        }
        [HttpPost]
        public ActionResult Search(CustomerViewModel customerViewModel)
        {
            var customer = _customerManager.Add();

            if (customerViewModel.Code != null)
            {
                customer = customer.Where(c => c.Code.Contains(customerViewModel.Code)).ToList();

            }
            if (customerViewModel.Name != null)
            {
                customer = customer.Where(c => c.Name.ToLower().Contains(customerViewModel.Name.ToLower())).ToList();
            }
            if (customerViewModel.Email != null)
            {
                customer = customer.Where(c => c.Email.ToLower().Contains(customerViewModel.Email.ToLower())).ToList();
            }
            if (customerViewModel.Contact != null)
            {
                customer = customer.Where(c => c.Contact.ToLower().Contains(customerViewModel.Contact.ToLower())).ToList();
            }

            customerViewModel.Customers = customer;

            return View(customerViewModel);

        }
    }
}