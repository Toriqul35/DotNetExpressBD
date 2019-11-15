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
    public class CategoryController : Controller
    {
        CategoryManager _CategoryManager = new CategoryManager();


        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel _categoryViewModel = new CategoryViewModel();
            _categoryViewModel.Categories = _CategoryManager.Add();
            return View(_categoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(CategoryViewModel categoryViewModel)
        {
            string message = " ";
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
                message = "Create Failed";
            }
            ViewBag.Message = message;
            categoryViewModel.Categories = _CategoryManager.Add();
            return View(categoryViewModel);
        }

        public ActionResult GetAll(Category category)
        {
            CategoryManager categoryManager = new CategoryManager();
            ModelState.Clear();
            return View(categoryManager.Add());
        }

        [HttpGet]
        public ActionResult Update(int id)
        {

            var category = _CategoryManager.GetById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            categoryViewModel.Categories = _CategoryManager.Add();

            return View(categoryViewModel);
            //CategoryManager categoryManager = new CategoryManager();
            //return View(categoryManager.Add().Find(smodel => smodel.Id == id));
        }
        // POST: Student/Edit/5	
        [HttpPost]
        public ActionResult Update(CategoryViewModel categoryViewModel)
        {
            string message = "";


            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);

                if (_CategoryManager.Update(category))
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
            categoryViewModel.Categories = _CategoryManager.Add();
            return View(categoryViewModel);
        }

        //try
        //{
        //    CategoryManager categoryManager = new CategoryManager();
        //    categoryManager.Update(smodel);
        //    return RedirectToAction("GetAll");
        //}
        //catch
        //{
        //    return View();
        //}
        //  }
        public ActionResult Delete(int id)
        {
            try
            {
                CategoryManager categoryManager = new CategoryManager();
                if (categoryManager.Delete(id))
                {
                    ViewBag.AlertMsg = "Student Deleted Successfully";
                }
                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }

        }
        [HttpGet]
        public ActionResult Search()
        {
            
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _CategoryManager.Add();

            return View(categoryViewModel);
        }
        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {
            var category = _CategoryManager.Add();

            if(categoryViewModel.Code != null)
            {
                category = category.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();

            }
             if (categoryViewModel.Name != null)
             {
                category = category.Where(c => c.Name.ToLower().Contains(categoryViewModel.Name.ToLower())).ToList();
             }

              categoryViewModel.Categories = category;

            return View(categoryViewModel);

        }

    }
}