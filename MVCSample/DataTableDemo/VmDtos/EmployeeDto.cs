using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DataTableDemo.VmDtos
{

    public class EmployeeListDto
    {
        public IList<EmployeeDto> EmployeeList { get; set; }
        public int TotalEmployee { get; set; }
        public int FilteredEmployees { get; set; }
        public EmployeeListDto()
        {
            EmployeeList = new List<EmployeeDto>();
        }
    }
    public class EmployeeDto
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
    }
}