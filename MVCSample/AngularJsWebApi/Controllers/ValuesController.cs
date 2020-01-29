using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Cors;
using AngularJsWebApi.Models.UIModels;
using AngularJsWebApi.Models;



namespace AngularJsWebApi.Controllers
{
    // [Authorize]
    public class ValuesController : ApiController
    {
        EmployeeEntities context = new EmployeeEntities();
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }

        public List<UIStates> GetStates(string id)
        {
            int countryId = Convert.ToInt32(id);
            List<UIStates> lstStates = new List<UIStates>();
            lstStates = (from item in context.States where (item.CountryId == countryId) select new UIStates { StateId = item.StateId, Name = item.Name,CountryId=item.CountryId??0}).ToList();
            return lstStates;
        }

    }
}
