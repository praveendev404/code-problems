using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsWebApi.Models.UIModels
{
    public class UIEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DOB { get; set; }
        public string strDOB { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public int? StateId { get; set; }
        public int? CountryId { get; set; }
        public int? GenderId { get; set; }
        public bool StatusTypeId { get; set; }
        public HttpPostedFileBase File { get; set; }
        public UICountry Country1 { get; set; }
        public UIStates State1 { get; set; }
        public UICourses Courses { get; set; }
        public UICountry country { get; set; }
        public List<UICountry> LstCountrys { get; set; }
        public List<UIStates> LstStates { get; set; }
        public List<UICourses> LstCourses { get; set; }
        public List<UIEmployeeCourses> SelectedEmpCourses { get; set; }
        //public List<int> SelectedCourses { get; set; }

    }
}