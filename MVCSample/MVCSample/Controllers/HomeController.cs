using MVCSample.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCSample.Controllers
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
        MvcDemoEntities3 mvcDemoEntities = new MvcDemoEntities3();

        public ActionResult Test()
        {
            UIEmp uiEmp = new UIEmp();
            int year = DateTime.Now.Year;
            uiEmp.lstCountry = (from c in mvcDemoEntities.Countries select new UICountry { Name = c.Name, CountryId = c.CountryId }).ToList();
            uiEmp.lstGender = (from g in mvcDemoEntities.Genders select new UIGender { Name = g.Name, GenderId = g.GenderId }).ToList();
            //uiEmp.lstState.Add(new UIState()
            //{
            //    StateId = 1,
            //    Name = ""
            //});

            uiEmp.lstQualification = (from q in mvcDemoEntities.Qualifications select new UIQualification { QualificationId = q.QualificationID, Qualification = q.Qualification1 }).ToList();
            uiEmp.lstState = new List<UIState>();
            List<PassYear> years = new List<PassYear>();
          
            for (int i = year; i >= 2000; i--)
            {
                PassYear passYear = new PassYear();
                passYear.Passyear = i;
                passYear.YearOfPassing = i;
                years.Add(passYear);
            }
            uiEmp.lstYear = years;

            return View(uiEmp);
        }
        [HttpPost]
        public string AddEmpWithImage(UIEmp uiEmp)
        {
            HttpPostedFileBase imgFile = Request.Files["ProfilePic"];
            BinaryReader br = new BinaryReader(imgFile.InputStream);
            byte[] bytes = br.ReadBytes(Convert.ToInt32(imgFile.ContentLength));
            uiEmp.ProfilePic = new UIProfilePic();
            uiEmp.ProfilePic.ProfileImage = bytes;
            Employee employee = new Employee();
            employee.FirstName = uiEmp.FirstName;
            employee.LastName = uiEmp.LastName;
            employee.GenderId = uiEmp.Gender.GenderId;
            employee.MobileNo = uiEmp.MobileNo;
            employee.EmailId = uiEmp.EmailId;
            employee.CountryId = uiEmp.Country.CountryId; 
            employee.StateId = uiEmp.State.StateId;
            employee.Address = uiEmp.Address;
            employee.ZipCode = uiEmp.ZipCode;
            mvcDemoEntities.Employees.Add(employee);
            int status = mvcDemoEntities.SaveChanges();
            int empId = employee.EmployeeId;
            if (status > 0)
            {
                ProfilePic profilePic = new ProfilePic();
                profilePic.ProfileImage = uiEmp.ProfilePic.ProfileImage;
                profilePic.EmployeeId = empId;
                mvcDemoEntities.ProfilePics.Add(profilePic);
                int res = mvcDemoEntities.SaveChanges();

            }

            return "";
        }
        public string EmpEducation(UIEmp UiEmp)
        {
            
            return ""; 
        }
        public byte[] BinaryImage(HttpPostedFileBase imgFile)
        {

            BinaryReader br = new BinaryReader(imgFile.InputStream);
            byte[] bytes = br.ReadBytes(Convert.ToInt32(imgFile.ContentLength));
            return bytes;
        }

        public ActionResult JqBasics()
        {
            return View();
        }
    }
}