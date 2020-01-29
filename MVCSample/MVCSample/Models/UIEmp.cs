using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class UIEmp
    {
        public int EmployeeId { get; set; }
      //  [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
      //  [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
       // [Required(ErrorMessage = "Enter Mobile No")]
        public string MobileNo { get; set; }
      //  [Required(ErrorMessage = "Enter EmailId ")]
        public string EmailId { get; set; }
      //  [Required(ErrorMessage = "Enter Address ")]
        public string Address { get; set; }
       // [Required(ErrorMessage = "Enter Zip code ")]
        public string ZipCode { get; set; }

        //[Required(ErrorMessage = "Select Gender")]
        public UIGender Gender { get; set; }
        //[Required(ErrorMessage = "Select Country")]
        public UICountry Country { get; set; }
        //[Required(ErrorMessage = "Select State")]
        public UIState State { get; set; }

        public string DateofBirth { get; set; }
        public UIProfilePic ProfilePic { get; set; }

        public List<UIGender> lstGender { get; set; }
        public List<UICountry> lstCountry { get; set; }
        public List<UIState> lstState { get; set; }

        public UIEmpQualification empQualification { get; set; }
        public List<UIEmpQualification> lstEmpQualification { get; set; }
        public UIQualification Qualification { get; set; }
        public List<UIQualification> lstQualification { get; set; }
        public List<PassYear> lstYear { get; set; }
    }
    public class PassYear
    {
        public int YearOfPassing { get; set; }
        public int Passyear { get; set; }
    }
}