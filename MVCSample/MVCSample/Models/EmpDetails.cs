using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace MVCSample.Models
{
    [Table("EmpDetails")]
    public class EmpDetails
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Enter Name")]
        public string Name { get; set; }

       
        [Required(ErrorMessage = "Enter MobileNo")]
        public string MobileNo { get; set; }

        [Required(ErrorMessage = "Enter Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Enter Address")]
        public string Address { get; set; }
        //public string ZipCode { get; set; }
    }
    public class EmployeeContext :DbContext
    {
        public DbSet<EmpDetails> EmpDetailss { get; set; }
    }
}