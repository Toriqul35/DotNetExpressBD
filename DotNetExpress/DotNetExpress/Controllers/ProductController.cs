using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetExpress.Model.Model;
using DotNetExpress.BLL.BLL;


using DotNetExpress.Model;
using AutoMapper;

namespace DotNetExpress.Controllers
{
    public class ProductController : Controller
    {
        ProductManager _productManager = new ProductManager();
        CategoryManager _categoryManager = new CategoryManager();
        [HttpGet]
        public ActionResult Add()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                                                         .GetAll()
                                                         .Select(c => new SelectListItem()
                                                         {
                                                             Value = c.Id.ToString(),
                                                             Text = c.Name
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
                    ModelState.Clear();
                }
                else
                {
                    message = "Not Saved";
                }
            }
            else
            {
                message = "ModelState is invalied!";
            }




            ViewBag.Message = message;
            productViewModel.products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(productViewModel);
        }


        public ActionResult Search()
        {
            ProductViewModel productViewModel = new ProductViewModel();

            productViewModel.products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();


            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Search(ProductViewModel productViewModel)
        {

            var Products = _productManager.GetAll();

            if (productViewModel.Code != null)
            {
                Products = Products.Where(c => c.Code.Contains(productViewModel.Code)).ToList();
            }
            if (productViewModel.Name != null)
            {
                Products = Products.Where(c => c.Name.ToLower().Contains(productViewModel.Name.ToLower())).ToList();
            }

            productViewModel.products = Products;
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();


            return View(productViewModel);
        }

        public ActionResult Edit(int id)
        {
            var product = _productManager.GetById(id);
            ProductViewModel productViewModel = Mapper.Map<ProductViewModel>(product);

            productViewModel.products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                                                         .GetAll()
                                                         .Select(c => new SelectListItem()
                                                         {
                                                             Value = c.Id.ToString(),
                                                             Text = c.Name
                                                         }).ToList();


            return View(productViewModel);
        }

        [HttpPost]
        public ActionResult Edit(ProductViewModel productViewModel)
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
                message = "ModelState is invalied!";
            }




            ViewBag.Message = message;
            productViewModel.products = _productManager.GetAll();
            productViewModel.CategorySelectListItems = _categoryManager
                .GetAll()
                .Select(c => new SelectListItem()
                {
                    Value = c.Id.ToString(),
                    Text = c.Name
                }).ToList();
            return View(productViewModel);
        }
    }
}