using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DotNetExpress.BLL.BLL;
using DotNetExpress.Model.Model;

namespace DotNetExpress.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Home()
        {
            return View();
        }


    }
}