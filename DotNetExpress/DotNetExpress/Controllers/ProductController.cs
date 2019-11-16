using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using DotNetExpress.Model;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;

namespace DotNetExpress.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        // GET: Product
        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();

            productViewModel.CategorySelectListItems=_categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();

            
            return View(productViewModel);
        }
        [HttpPost]
        public ActionResult Add(ProductViewModel productViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Add(product))
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
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();
            return View(productViewModel);
        }
        public ActionResult ViewProduct(Product product)
        {
            ProductManager _productManager = new ProductManager();
            ModelState.Clear();
            return View(_productManager.GetAll());
        }




        [HttpGet]
        public ActionResult Update(int id)
        {

            var product = _productManager.GetById(id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);
            productViewModel.Products = _productManager.GetAll();

            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();

            return View(productViewModel);


        }
        // POST: Student/Edit/5	
        [HttpPost]
        public ActionResult Update(ProductViewModel productViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Product product = Mapper.Map<Product>(productViewModel);

                if (_productManager.Update(product))
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
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();
            return View(productViewModel);
        }
        public ActionResult Search()
        {


            ProductViewModel productViewModel = new ProductViewModel();
            productViewModel.Products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
               .GetAll().Select(c => new SelectListItem()
               {
                   Value = c.Id.ToString(),
                   Text = c.Code
               }).ToList();

            return View(productViewModel);

           
        }
        [HttpPost]
        public ActionResult Search(ProductViewModel productViewModel)
        {
            var product = _productManager.GetAll();

            if (productViewModel.Code != null)
            {
                product = product.Where(c => c.Code.Contains(productViewModel.Code)).ToList();

            }
            if (productViewModel.Name != null)
            {
                product = product.Where(c => c.Name.ToLower().Contains(productViewModel.Name.ToLower())).ToList();
            }
            if (productViewModel.Name != null)
            {
                product = product.Where(c => c.Name.ToLower().Contains(productViewModel.Name.ToLower())).ToList();
            }
         
            productViewModel.Products = product;
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll().Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Code
                }).ToList();

            return View(productViewModel);

        }
        public ActionResult Delete(int id)
        {
            try
            {
                ProductManager productManager  = new ProductManager();
                if (productManager.Delete(id))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("ViewProduct");
            }
            catch
            {
                return View();
            }

        }
    }
}