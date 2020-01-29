using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class UIEmployee
    {
        public Employee Employee { get; set; }
        public List<Gender> lstGender { get; set; }
        public List<Country> lstCountry { get; set; }
        public List<State> lstState { get; set; }
    }
}