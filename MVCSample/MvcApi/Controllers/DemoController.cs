using MvcApi.Models;
using MvcApi.Models.UIClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApi.Controllers
{
    public class DemoController : ApiController
    {
        [HttpGet]
        public string HelpMe()
        {
            return "Help";
        }
        [HttpGet]
        public List<UIEmployee> GetEmployee()
        {
            MvcDemoEntities entities = new MvcDemoEntities();
            List<UIEmployee> lstEmployee = new List<UIEmployee>();
            lstEmployee = (from e in entities.Employees.Where(o => o.StatusTypeId == 1)
                           select new UIEmployee
                           {
                               EmployeeId = e.EmployeeId,
                               FirstName = e.FirstName,
                               GenderId = e.GenderId,
                               CountryId = e.CountryId,
                               StateId = e.StateId,
                               LastName = e.LastName,
                               MobileNo = e.MobileNo,
                               EmailId = e.EmailId,
                               ZipCode = e.ZipCode, 
                               Address = e.Address
                           }
                             ).ToList();
            return lstEmployee;
        }

        [HttpGet]
        public List<UIEmployee> GetEmployeeById(int id)
        {
            MvcDemoEntities entities = new MvcDemoEntities();
            List<UIEmployee> lstEmployee = new List<UIEmployee>();
            lstEmployee = (from e in entities.Employees.Where(o => o.StatusTypeId == 1 && o.EmployeeId == id)
                           select new UIEmployee
                           {
                               EmployeeId = e.EmployeeId,
                               FirstName = e.FirstName,
                               GenderId = e.GenderId,
                               CountryId = e.CountryId,
                               StateId = e.StateId,
                               LastName = e.LastName,
                               MobileNo = e.MobileNo,
                               EmailId = e.EmailId,
                               ZipCode = e.ZipCode,
                               Address = e.Address
                           }
                             ).ToList();
            return lstEmployee;
        }
        [HttpGet]
        [Route("api/Demo/DemoTest/{id?}/{option?}")]
        public string Simple(string id = "", string option = "")
        {
            return id + "" + option;
        }

        [HttpPost]
        public string ReturnString(string name)
        {
            return "Enterd name is : "+name;
        }
    }
}
