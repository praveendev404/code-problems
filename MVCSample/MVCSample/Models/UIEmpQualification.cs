using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    public class UIEmpQualification
    {
        public int EmpQualificationId { get; set; }
        public int QualificationId { get; set; }
        public int YearOfPassing { get; set; }
        public decimal Aggrigate { get; set; }
        public int EmployeeId { get; set; }
        public List<UIQualification> lstQualification { get; set; }
        public List<int> lstYear { get; set; }
    }
}