using DataTableDemo.VmDtos;
using DataTables.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DataTableDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
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

        [HttpPost]
        public JsonResult Test()
        {
            ViewBag.Message = "Your contact page.";

            return Json("hi", JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public JsonResult EmployeeList([ModelBinder(typeof(DataTablesBinder))] IDataTablesRequest requestModel)
        {

            EmployeeDto emp1 = new EmployeeDto() { EmployeeId = 1001, FirstName = "Praveen1", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp2 = new EmployeeDto() { EmployeeId = 1002, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp3 = new EmployeeDto() { EmployeeId = 1003, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp4 = new EmployeeDto() { EmployeeId = 1004, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp5 = new EmployeeDto() { EmployeeId = 1005, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp6 = new EmployeeDto() { EmployeeId = 1006, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp7 = new EmployeeDto() { EmployeeId = 1007, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp8 = new EmployeeDto() { EmployeeId = 1008, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp9 = new EmployeeDto() { EmployeeId = 1009, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp10 = new EmployeeDto() { EmployeeId = 10010, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp11 = new EmployeeDto() { EmployeeId = 10011, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };
            EmployeeDto emp12 = new EmployeeDto() { EmployeeId = 10012, FirstName = "Praveen", LastName = "Kumar", Address = "Hyderabad", EmailId = "Praveen@gmail.com", ZipCode = "500082" };


            List<EmployeeDto> lstEmp = new List<EmployeeDto>();

            EmployeeListDto lstEmployee = new EmployeeListDto();
            lstEmp.Add(emp1);
            lstEmp.Add(emp2);
            lstEmp.Add(emp3);
            lstEmp.Add(emp4);
            lstEmp.Add(emp5);
            lstEmp.Add(emp6);
            lstEmp.Add(emp7);
            lstEmp.Add(emp8);
            lstEmp.Add(emp9);
            lstEmp.Add(emp10);
            lstEmp.Add(emp11);
            lstEmp.Add(emp12);

            //   var model1 = lstEmployee.EmployeeList.Skip(requestModel.Start).Take(requestModel.Length).ToList();
            lstEmp = lstEmp.Where(o => o.FirstName.ToLower().Contains(requestModel.Search.Value.ToLower())).ToList();
            lstEmployee.EmployeeList = lstEmp.Skip(requestModel.Start).Take(requestModel.Length).ToList();
            var model = lstEmployee;

            model.TotalEmployee = lstEmp.Count();
            var jsonresult = Json(new DataTablesResponse<EmployeeDto>(
               requestModel.Draw,
               model.EmployeeList,
               model.TotalEmployee,
               model.TotalEmployee
           ), JsonRequestBehavior.AllowGet);
            return jsonresult;
            //var jsonresult = Json(data: "ssr");
            //return jsonresult;
        }
    }
}







