using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    public class PivotSample
    {
        static void Main1(string[] args)
        {
            Console.WriteLine("hi");
            List<Employee> lstEmpDate = new List<Employee>() { 
            new Employee{EmployeeId=1,Name="Praveen1",Sal1=1000,Sal2=2000,Sal3=3000,Date=Convert.ToDateTime("01/02/2010")},
            new Employee{EmployeeId=2,Name="Praveen2",Sal1=4000,Sal2=5000,Sal3=6000,Date=Convert.ToDateTime("01/02/2010")},
            new Employee{EmployeeId=3,Name="Praveen3",Sal1=7000,Sal2=8000,Sal3=9000,Date=Convert.ToDateTime("01/02/2010")},
            new Employee{EmployeeId=4,Name="Praveen4",Sal1=10000,Sal2=11000,Sal3=22000,Date=Convert.ToDateTime("01/02/2010")},
            new Employee{EmployeeId=5,Name="Praveen5",Sal1=1400,Sal2=4500,Sal3=7800,Date=Convert.ToDateTime("01/02/2010")},
             new Employee{EmployeeId=1,Name="Praveen1",Sal1=1000,Sal2=2000,Sal3=3000,Date=Convert.ToDateTime("01/02/2011")},
            new Employee{EmployeeId=2,Name="Praveen2",Sal1=4000,Sal2=5000,Sal3=6000,Date=Convert.ToDateTime("01/02/2011")},
            new Employee{EmployeeId=3,Name="Praveen3",Sal1=7000,Sal2=8000,Sal3=9000,Date=Convert.ToDateTime("01/02/2011")},
            new Employee{EmployeeId=4,Name="Praveen4",Sal1=10000,Sal2=11000,Sal3=22000,Date=Convert.ToDateTime("01/02/2011")},
            new Employee{EmployeeId=5,Name="Praveen5",Sal1=1400,Sal2=4500,Sal3=7800,Date=Convert.ToDateTime("01/02/2011")},
            new Employee{EmployeeId=1,Name="Praveen1",Sal1=1000,Sal2=2000,Sal3=3000,Date=Convert.ToDateTime("01/02/2012")},
            new Employee{EmployeeId=2,Name="Praveen2",Sal1=4000,Sal2=5000,Sal3=6000,Date=Convert.ToDateTime("01/02/2012")},
            new Employee{EmployeeId=3,Name="Praveen3",Sal1=7000,Sal2=8000,Sal3=9000,Date=Convert.ToDateTime("01/02/2012")},
            new Employee{EmployeeId=4,Name="Praveen4",Sal1=10000,Sal2=11000,Sal3=22000,Date=Convert.ToDateTime("01/02/2012")},
            new Employee{EmployeeId=5,Name="Praveen5",Sal1=1400,Sal2=4500,Sal3=7800,Date=Convert.ToDateTime("01/02/2012")},
            };


            var query = from e in lstEmpDate
                        group e by e.Date into g
                        select new
                        {
                            Date = g.Key,
                            Praveen1 = g.Where(x => x.Name == "Praveen1").Sum(x => x.Sal1),
                            Praveen2 = g.Where(x => x.Name == "Praveen2").Sum(x => x.Sal1),
                            Praveen3 = g.Where(x => x.Name == "Praveen3").Sum(x => x.Sal1),
                            Praveen4 = g.Where(x => x.Name == "Praveen4").Sum(x => x.Sal1),
                            Praveen5 = g.Where(x => x.Name == "Praveen5").Sum(x => x.Sal1),


                        };
            int i = 0;
            List<Emp> lstEmp = new List<Emp>() { 
            new Emp{EmployeeId=1,FromDate=new DateTime(2010,04,01),ToDate=new DateTime(2010,04,05),Amount=1000,Name="Praveen1"},
            new Emp{EmployeeId=1,FromDate=new DateTime(2010,04,06),ToDate=new DateTime(2010,04,20),Amount=4000,Name="Praveen1"},
            new Emp{EmployeeId=1,FromDate=new DateTime(2010,04,23),ToDate=new DateTime(2010,04,29),Amount=7000,Name="Praveen1"},
            new Emp{EmployeeId=1,FromDate=new DateTime(2010,04,30),ToDate=new DateTime(2010,04,30),Amount=7000,Name="Praveen1"},
            new Emp{EmployeeId=2,FromDate=new DateTime(2010,04,01),ToDate=new DateTime(2010,04,05),Amount=1000,Name="Praveen2"},
            new Emp{EmployeeId=2,FromDate=new DateTime(2010,04,06),ToDate=new DateTime(2010,04,20),Amount=4000,Name="Praveen2"},
            new Emp{EmployeeId=2,FromDate=new DateTime(2010,04,23),ToDate=new DateTime(2010,04,29),Amount=7000,Name="Praveen2"},
            new Emp{EmployeeId=3,FromDate=new DateTime(2010,04,01),ToDate=new DateTime(2010,04,05),Amount=1000,Name="Praveen3"},
            new Emp{EmployeeId=3,FromDate=new DateTime(2010,04,06),ToDate=new DateTime(2010,04,20),Amount=4000,Name="Praveen2"},
            new Emp{EmployeeId=3,FromDate=new DateTime(2010,04,23),ToDate=new DateTime(2010,04,29),Amount=7000,Name="Praveen3"},  
            new Emp{EmployeeId=4,FromDate=new DateTime(2010,04,25),ToDate=new DateTime(2010,04,29),Amount=7000,Name="Praveen4"},  
            new Emp{EmployeeId=4,FromDate=new DateTime(2010,04,27),ToDate=new DateTime(2010,04,29),Amount=5000,Name="Praveen4"},  
          
            };
            var finalQuery = from e in lstEmp
                             group e by e.EmployeeId into g
                             select g
                             ;
            List<Emp> lstFinal = new List<Emp>();
            foreach (var item in finalQuery)
            {
                List<Emp> lstMatched = new List<Emp>();
                List<Emp> lst = new List<Emp>();
                lst = item.ToList();
                for (i = 0; i < lst.Count(); i++)
                {

                    Emp emp = new Emp();
                    emp.EmployeeId = lst[i].EmployeeId;
                    emp.Name = lst[i].Name;
                    emp.FromDate = lst[i].FromDate;
                    emp.ToDate = lst[i].ToDate;
                    emp.Amount = lst[i].Amount;
                    emp.IsMatched = false;
                    if (i + 1 != lst.Count())
                    {
                        if (lst[i].ToDate.AddDays(1) == lst[i + 1].FromDate)
                        {
                            emp.IsMatched = true;
                        }
                    }

                    lstMatched.Add(emp);
                }
                int amount = 0;
                bool isFirst = true;
                DateTime fromdate = new DateTime();
                DateTime toDate = new DateTime();
                foreach (var item1 in lstMatched)
                {
                    Emp empFinal = new Emp();
                    amount = amount + item1.Amount ?? 0;
                    if (isFirst)
                    {
                        fromdate = item1.FromDate;
                        isFirst = false;
                    }
                    if (item1.IsMatched == false)
                    {
                        isFirst = true;
                        empFinal.EmployeeId = item1.EmployeeId;
                        empFinal.Name = item1.Name;
                        empFinal.Amount = amount;
                        empFinal.FromDate = fromdate;
                        empFinal.ToDate = item1.ToDate;
                        amount = 0;
                        lstFinal.Add(empFinal);
                    }


                }

            }
            foreach (var item in lstFinal)
            {
                Console.WriteLine("EmployeeId : "+item.EmployeeId+", "+"Name : "+item.Name+", "+"From Date : "+item.FromDate.Date+", "+"To Date : "+item.ToDate.Date+",  "+"Amount : "+item.Amount);
            }

            Console.ReadLine();
        }
    }

    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int Sal1 { get; set; }
        public int Sal2 { get; set; }
        public int Sal3 { get; set; }
        public DateTime Date { get; set; }
    }
    public class Emp
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public int? Amount { get; set; }
        public DateTime FromDate { get; set; }
        public DateTime ToDate { get; set; }
        public bool IsMatched { get; set; }
    }
}



