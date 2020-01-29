using ActionFiltersDemo.Models;
using FiltersDemo.Controllers.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace ActionFiltersDemo.Controllers
{
    [CustomAuthorization]
    [CustomAction]
    [CustomResultAttribute]
    [CustomExceptionAttribute]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        [OutputCache(Duration = 10)]
        public string Index1()
        {
            return DateTime.Now.ToString("T");
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


        public ActionResult TestActionFilter()
		{
			throw new Exception("Dummy Exception");
			try
			{
				
				int I = 2;
                int K = 0;
                int L = I / K;
                ViewBag.Message = "TestActionFilter Action of Home controller is being called.";
			}
			catch (Exception)
			{

				//throw;
			}
			return View();
        }

		[Authorize]
        public ActionResult TestPost(TestModel model)
        {
            try
            {
                int k = 0;
              //  int y = 10 / k;
                var result = new { Result = "This is jquery test post method.....", Success = true };
                return Json(new { result }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception)
            {
                //Response.StatusCode = (int)HttpStatusCode.BadRequest;
                //var result = new { Result = "This is jquery test post method.....", Success = false };
                //return Json(new { result }, JsonRequestBehavior.AllowGet);.
                Response.StatusCode = (int)HttpStatusCode.OK;
                return Json(Response.StatusCode, JsonRequestBehavior.AllowGet);

            }
        }
    }
}