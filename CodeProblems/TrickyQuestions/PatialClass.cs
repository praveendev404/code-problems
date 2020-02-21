using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
     class PatialClass
    {
        static void Main1(string[] args)
        {
            partialclass1 obj = new partialclass1();
            obj.EnterValue();
            obj.DisplayValue();
            obj.employeeid = "123456";
            
        }
       
    }

    public partial class partialclass1
    {
      public  string employeeid;
        public void EnterValue()
        {
            Console.WriteLine("This is EnterValue method ");
        }
        partial class NestedClass { }

      
    }

    public partial class partialclass1
    {
        public void DisplayValue()
        {
            Console.WriteLine("This is DisplayValue method ");
        }

        partial class NestedClass { }
    }

    partial class ClassWithNestedClass
    {
        partial class NestedClass { }
        partial class NestedClass { }
        partial class NestedClass { }
    }

    partial class ClassWithNestedClass
    {
        partial class NestedClass { }
    }
}
