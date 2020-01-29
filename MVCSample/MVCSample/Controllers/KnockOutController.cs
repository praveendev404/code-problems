using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
{
    public class KnockOutController : Controller
    {
        // GET: KnockOut
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AddEmployee()
        {
            return View();
        }
        [HttpPost]
        public JsonResult AddEmp(DateMonthYear dateMonthYear)
        {
            return Json(1, JsonRequestBehavior.AllowGet);
        }
        public JsonResult EditEmpById(string id)
        {
            DateMonthYear dayMonth = new DateMonthYear() { Day = "22", Month = "12", Year = "2012" };
            return Json(dayMonth, JsonRequestBehavior.AllowGet);
        }
        public ActionResult AddEmpDetails()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddEmpDetails(UIEmp emp)
        {
            return View();
        }
       
        public JsonResult AddEmpEdit(string id)
        {
            UIEmp emp = new UIEmp()
            {
                FirstName="Praveen",
                LastName="Kumar",
                DateofBirth="123654",
                Address="HYD"
            };
            return Json(emp, JsonRequestBehavior.AllowGet);
        }

     

    }
}