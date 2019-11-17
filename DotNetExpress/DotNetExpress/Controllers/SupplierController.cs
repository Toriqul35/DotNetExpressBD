using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetExpress.Model;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;
using AutoMapper;

namespace DotNetExpress.Controllers
{
    public class SupplierController : Controller
    {
        SupplierManager _supplierManager = new SupplierManager();
        ProjectDbContext db = new ProjectDbContext();
        // GET: Supplier
        public ActionResult CheckExist( string code,int? Id, string contact,string email)
        {
                var validateName = db.Suppliers.FirstOrDefault
                                    (x => x.Code == code && x.Id != Id ||x.Contact== contact && x.Id!=Id || x.Email == email && x.Id != Id);
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

            SupplierViewModel supplierViewModel = new SupplierViewModel();
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpPost]
        public ActionResult Add(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier suppler = Mapper.Map<Supplier>(supplierViewModel);

                if (_supplierManager.Add(suppler))
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
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);


        }
        public ActionResult ViewSupplier(Supplier supplier)
        {
            SupplierManager _supplierManager = new SupplierManager();
            ModelState.Clear();
            return View(_supplierManager.GetAll());
        }
        public ActionResult Delete(int id)
        {
            try
            {
                SupplierManager _supplierManager = new SupplierManager();
                if (_supplierManager.Delete(id))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("ViewSupplier");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            var supplier = _supplierManager.GetById(id);
            SupplierViewModel supplierViewModel = Mapper.Map<SupplierViewModel>(supplier);
            supplierViewModel.Suppliers = _supplierManager.GetAll();

            return View(supplierViewModel);

        }
        [HttpPost]
        public ActionResult Update(SupplierViewModel supplierViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Supplier supplier = Mapper.Map<Supplier>(supplierViewModel);
             
                if (_supplierManager.Update(supplier))
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
            supplierViewModel.Suppliers = _supplierManager.GetAll();
            return View(supplierViewModel);
        }

        [HttpGet]
        public ActionResult Search(string searching)
        {
            string message = "";

            var supplier = from s in db.Suppliers
                           select s;
            if (!String.IsNullOrEmpty(searching))
            {
                supplier = supplier.Where(s => s.Email.Contains(searching) || s.Name.Contains(searching) || s.Contact.Contains(searching));
            }
            else
            {
                message = "Not Search";
            }
            ViewBag.Message = message;
            return View(supplier.ToList());
           
        }
    }
    }
