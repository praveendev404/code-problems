using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElmahDemo.Infrastructure;

namespace ElmahDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            try
            {
                int t = 0;
                double d = 4 / t;

            }
            catch (Exception ex)
            {
                ErrorLogger.LogError(ex);
               // throw;
            }
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}