using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetExpress.Model;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;
using AutoMapper;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Controllers
{
    public class CustomerController : Controller
    {
        CustomerManager _customerManager = new CustomerManager();
        ProjectDbContext _dbContext = new ProjectDbContext();

        public ActionResult CheckExist(string code, string contact,string email,int? Id)
        {
            var validateName = _dbContext.Customers.FirstOrDefault
                                (x => x.Code == code && x.Id != Id ||x.Contact==contact && x.Id!=Id || x.Email == email && x.Id != Id);
            if (validateName != null)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(true, JsonRequestBehavior.AllowGet);
            }
        }

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
            customerViewModel.Customers = _customerManager.GetAll();

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
            customerViewModel.Customers = _customerManager.GetAll();
            return View(customerViewModel);
        }
        [HttpGet]
        public ActionResult Search(string searching)
        {
            var customer = from s in _dbContext.Customers
                           select s;
            if (!String.IsNullOrEmpty(searching))
            {
                customer = customer.Where(s => s.Contact.Contains(searching) || s.Name.Contains(searching) || s.Email.Contains(searching) || s.Code.Contains(searching));
            }

            return View(customer.ToList());
        }
    }
}