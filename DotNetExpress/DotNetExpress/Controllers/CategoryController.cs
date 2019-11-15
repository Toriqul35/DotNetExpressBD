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
    public class CategoryController : Controller
    {
        CategoryManager _CategoryManager = new CategoryManager();
             

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);

                if (_CategoryManager.Add(category))
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
                message = "ModelState is invalied!";
            }




            ViewBag.Message = message;
            categoryViewModel.categories = _CategoryManager.GetAll();           
            return View(categoryViewModel);
        }


        public ActionResult Search()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();

            categoryViewModel.categories = _CategoryManager.GetAll();
           


            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {

            var categories = _CategoryManager.GetAll();

            if (categoryViewModel.Code != null)
            {
                categories = categories.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();
            }
            if (categoryViewModel.Name != null)
            {
                categories = categories.Where(c => c.Name.ToLower().Contains(categoryViewModel.Name.ToLower())).ToList();
            }

            categoryViewModel.categories = categories;
           
            return View(categoryViewModel);
        }

        public ActionResult Edit(int id)
        {
            var category = _CategoryManager.GetById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);

            categoryViewModel.categories = _CategoryManager.GetAll();
          
            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Edit(CategoryViewModel categoryViewModel)
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Category category  = Mapper.Map<Category>(categoryViewModel);

                if (_CategoryManager.Update(category))
                {
                    message = " Updated";
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
            categoryViewModel.categories = _CategoryManager.GetAll();
           
            return View(categoryViewModel);
        }

    }
}