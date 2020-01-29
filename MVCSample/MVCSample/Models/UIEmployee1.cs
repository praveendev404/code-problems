using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class UIEmployee1
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "Enter First Name")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Enter Last Name")]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Enter Mobile No")]
        public string MobileNO { get; set; }
        [Required(ErrorMessage = "Enter EmailId ")]
        public string EmailId { get; set; }
        [Required(ErrorMessage = "Enter Address ")]
        public string Address { get; set; }

        [Required(ErrorMessage = "Select Gender")]
        public UIGender Gender { get; set; }
        [Required(ErrorMessage = "Select Country")]
        public UICountry Country { get; set; }
        [Required(ErrorMessage = "Select State")]
        public UIState State { get; set; }

        public ICollection<UICountry> lstCountry { get; set; }
        public ICollection<UIState> lstState { get; set; }
        
    }
}