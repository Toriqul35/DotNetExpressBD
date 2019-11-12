using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;

namespace DotNetExpress.Controllers
{
    public class CategoryController : Controller
    {
        CategoryManager _CategoryManager = new CategoryManager();
        //public string Add(string rollNo, string name, string address, int? age, int? departmentId)


        [HttpGet]
        public ActionResult Add()
        {
            Category category = new Category();

            return View(category);
        }

        [HttpPost]
        public ActionResult Add(Category category)
        {
            string message = "<h3>Category Information </h3><br / > ";

            //message += "Roll No:" + student.RollNo;
            //message += "<br / > Name:" + student.Name;
            //message += "<br / > Address:" + student.Address;
            //message += "<br / > Age:" + student.Age;
            //message += "<br / > Department:" + student.DepartmentId;



            if (_CategoryManager.Add(category))
            {
                message = "Saved";
            }
            else
            {
                message = "Not Saved";
            }

            ViewBag.Message = message;

            return RedirectToAction("Index", "Home");
        }

        public ActionResult GetAll(Category category)
        {
            CategoryManager categoryManager = new CategoryManager();
            ModelState.Clear();
            return View(categoryManager.Add());
        }


        public ActionResult Update(int id)
        {
            CategoryManager categoryManager = new CategoryManager();
            return View(categoryManager.Add().Find(smodel => smodel.Id == id));
        }
        // POST: Student/Edit/5	
        [HttpPost]
        public ActionResult Update(int id, Category smodel)
        {
            try
            {
                CategoryManager categoryManager = new CategoryManager();
                categoryManager.Update(smodel);
                return RedirectToAction("Add");
            }
            catch
            {
                return View();
            }
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
            return RedirectToAction("Add");
        }

    }
}