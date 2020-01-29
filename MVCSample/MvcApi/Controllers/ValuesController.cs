using MvcApi.Models;
using MvcApi.Models.UIClasses;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MvcApi.Controllers
{

    public class ValueController : ApiController
    {
        public class Model
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }

        private List<string> list = new List<string> { "Item1", "Item2", "Item3", "Item4", "Item5" };

        // GET api/value
        [HttpGet]
        public IEnumerable GetList()
        {
            return list;
        }

        // GET api/value/5
        public string GetItem(int id)
        {
            return list.Find(i => i.ToString().Contains(id.ToString()));
        }

        ////  [HttpPost]
        //[Route("api/value/{value}")]
        //// POST api/value/{value}
        //public string Post(string value)
        //{
        //    return "Value is : " + value;
        //}

        // PUT api/value/5
        public void Put(int id, string value)
        {

        }

        // DELETE api/value/5
        [Route("api/value/{id}")]
        public List<string> DeleteItem(int id)
        {
            list.Remove(list.Find((i => i.ToString().Contains(id.ToString()))));
            return list;
        }

        public string Test(int id)
        {
            int i = 0;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://192.168.1.24:8003/");
            return "Id is : " + id;
        }
        public string SaveMethod(Model mo)
        {
            return "Saved Successfully";
        }

        [HttpGet]
        [Route("api/value/GetEmployee/")]
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
        [Route("api/value/GetEmployeeById/{id}/")]
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
        [Route("api/value/DemoTest/{id?}/{option?}")]
        public string Simple(string id = "", string option = "")
        {
            return id + " " + option;
        }
    }

    


    //[Authorize]
    //public class ValuesController : ApiController
    //{
    //    // GET api/values
    //    public IEnumerable<string> Get()
    //    {
    //        return new string[] { "value1", "value2" };
    //    }

    //    // GET api/values/5
    //    public string Get(int id)
    //    {
    //        return "value";
    //    }

    //    // POST api/values
    //    public void Post([FromBody]string value)
    //    {
    //    }

    //    // PUT api/values/5
    //    public void Put(int id, [FromBody]string value)
    //    {
    //    }

    //    // DELETE api/values/5
    //    public void Delete(int id)
    //    {
    //    }
    //}
}
