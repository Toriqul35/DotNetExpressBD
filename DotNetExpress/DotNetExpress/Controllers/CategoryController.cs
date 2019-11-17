using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using System.Web.Mvc;
using DotNetExpress.Model;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;
using DotNetExpress.DatabaseDbContext.DatabaseDbContext;

namespace DotNetExpress.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _CategoryManager = new CategoryManager();
        ProjectDbContext _dbContext = new ProjectDbContext();

        public ActionResult CheckExist(string code, string name, int? Id)
        {
            var validateName = _dbContext.categories.FirstOrDefault
                                (x => x.Code == code && x.Id != Id || x.Name == name && x.Id != Id);
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
            CategoryViewModel _categoryViewModel = new CategoryViewModel();
            _categoryViewModel.Categories = _CategoryManager.GetAll();
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
            categoryViewModel.Categories = _CategoryManager.GetAll();
            return View(categoryViewModel);
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

            var category = _CategoryManager.GetById(id);
            CategoryViewModel categoryViewModel = Mapper.Map<CategoryViewModel>(category);
            categoryViewModel.Categories = _CategoryManager.GetAll();

            return View(categoryViewModel);
            
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
            categoryViewModel.Categories = _CategoryManager.GetAll();
            return View(categoryViewModel);
        }

        public ActionResult Delete(int id)
        {
            try
            {
                CategoryManager categoryManager = new CategoryManager();
                if (categoryManager.Delete(id))
                {
                    ViewBag.AlertMsg = "Deleted Successfully";
                }
                return RedirectToAction("GetAll");
            }
            catch
            {
                return View();
            }

        }
 
        [HttpGet]
        public ActionResult Search(string searching)
        {
            var category = from s in _dbContext.categories
                           select s;
            if (!String.IsNullOrEmpty(searching))
            {
                category = category.Where(s => s.Code.Contains(searching)||s.Name.Contains(searching));
            }

            return View(category.ToList());
        }
        
    }
}