using System.Web.Mvc;
namespace DotNetExpress.Controllers
{
    public class HomeController : Controller
    {
       // DatabaseDbContext DatabaseDbContext = new DatabaseDbContext();
        
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
        [HttpGet]
        public ActionResult AdminLogin()
        {
            return View();
        }

        //[HttpPost]
        //public ActionResult AdminLogin()
        //{

        //    var Addmin = _CategoryManager.
        //    return View();
        }
    }
