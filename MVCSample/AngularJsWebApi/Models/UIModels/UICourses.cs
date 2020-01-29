using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AngularJsWebApi.Models
{
    public class UICourses
    {
        public int CourseId { get; set; }
        public string Name { get; set; }
        public int EmployeeId { get; set; }
        public bool IsChecked { get; set; }
    }
}