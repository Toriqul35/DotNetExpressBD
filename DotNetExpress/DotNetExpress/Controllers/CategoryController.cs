using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DotNetExpress.Model;
using System.Web.Mvc;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;
using AutoMapper;

namespace DotNetExpress.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _categoryManager = new CategoryManager();
       CategoryViewModel _categoryViewModel = new CategoryViewModel();

        [HttpGet]
        public ActionResult Add()
        {
            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            string message = "";

            //message += "Roll No:" + student.RollNo;
            //message += "<br / > Name:" + student.Name;
            //message += "<br / > Address:" + student.Address;
            //message += "<br / > Age:" + student.Age;
            //message += "<br / > Department:" + student.DepartmentId;

            if (ModelState.IsValid)
            {
                Category category1 = Mapper.Map<Category>(_categoryViewModel);


                if (_categoryManager.Add(category))
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
               _categoryViewModel.Categories = _categoryManager.GetAll();

                return RedirectToAction("Index", "Home");

            }
        
    public ActionResult GetAll(Category category)
        {
            CategoryManager categoryManager = new CategoryManager();
            ModelState.Clear();
            return View(categoryManager.GetAll());
        }

        [HttpGet]
        public ActionResult Update(int id)

        {
            var category = _categoryManager.GetAll();
            CategoryViewModel _categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            _categoryViewModel.Categories = _categoryManager.GetAll();

            return View(_categoryViewModel);
        }
        // POST: Category Update	
        [HttpPost]
        public ActionResult Update(CategoryViewModel categoryViewModel )
        {
            string message = "";

            if (ModelState.IsValid)
            {
                Category category = Mapper.Map<Category>(categoryViewModel);

                if (_categoryManager.Update(category))
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
            categoryViewModel.Categories = _categoryManager.GetAll();

            return View(categoryViewModel);
        }
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
            categoryViewModel.Categories = _categoryManager.GetAll();


            return View(categoryViewModel);

        }

        [HttpPost]
        public ActionResult Search(CategoryViewModel categoryViewModel)
        {
            var Categories = _categoryManager.GetAll();

            if (categoryViewModel.Code != null)
            {
                Categories = Categories.Where(c => c.Code.Contains(categoryViewModel.Code)).ToList();
            }
            if (categoryViewModel.Name != null)
            {
                Categories = Categories.Where(c => c.Name.ToLower().Contains(categoryViewModel.Name.ToLower())).ToList();
            }

            
            return View(categoryViewModel);
        }

    }
}

    