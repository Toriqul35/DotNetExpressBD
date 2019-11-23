using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using DotNetExpress.Model;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;

namespace DotNetExpress.Controllers
{
    public class PurchaseController : Controller
    {
        PurchaseManager _purchaseManager = new PurchaseManager();
        SupplierManager _supplierManager = new SupplierManager();
        ProductManager _productManager = new ProductManager();
        // GET: Purchase
        [HttpGet]
        public ActionResult Add()
        {
            PurchaseViewModel purchaseViewModel = new PurchaseViewModel();
            purchaseViewModel.Purchase = _purchaseManager.GetAll();

            purchaseViewModel.SupplierSelect = _supplierManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            purchaseViewModel.ProductSelect = _productManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();



            return View(purchaseViewModel);
        }
        [HttpPost]
        public ActionResult Add(PurchaseViewModel purchaseViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Purchase apurchase = Mapper.Map<Purchase>(purchaseViewModel);
                //Purchase purchase = Mapper.Map<Purchase>(PurchaseViewModel);
                ////Product product = Mapper.Map<Product>(productViewModel);

                if (_purchaseManager.Add(apurchase))
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
                message = "Create Failed";
            }

            ViewBag.Message = message;
            purchaseViewModel.Purchase = _purchaseManager.GetAll();
            purchaseViewModel.SupplierSelect = _supplierManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            purchaseViewModel.ProductSelect = _productManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();

            return View(purchaseViewModel);
        }
    }
}