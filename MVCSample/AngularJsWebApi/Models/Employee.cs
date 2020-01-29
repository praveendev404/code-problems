//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AngularJsWebApi.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Employee
    {
        public Employee()
        {
            this.EmployeeCourses = new HashSet<EmployeeCours>();
        }
    
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public Nullable<int> GenderId { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string MobileNo { get; set; }
        public string Address { get; set; }
        public Nullable<int> StateId { get; set; }
        public Nullable<int> CountryId { get; set; }
        public string ZipCode { get; set; }
        public byte StatusTypeId { get; set; }
    
        public virtual Country Country { get; set; }
        public virtual State State { get; set; }
        public virtual ICollection<EmployeeCours> EmployeeCourses { get; set; }
    }
}
