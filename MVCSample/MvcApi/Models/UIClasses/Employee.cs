using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApi.Models.UIClasses
{
    public class UIEmployee
    {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int GenderId { get; set; }
        public int CountryId { get; set; }
        public int StateId { get; set; }
        public string Address { get; set; }
        public string ZipCode { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
        public int StatusTypeId { get; set; }

        public virtual Country Country { get; set; }
        public virtual Gender Gender { get; set; }
        public virtual State State { get; set; }

    }
}