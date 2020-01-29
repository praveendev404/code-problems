using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
   public class LinqExamples
    {
        
        static void Main()
        {
            int[] numbers = {  };
            dynamic d;
             d = numbers.DefaultIfEmpty(10);
            int? result = null;
            foreach (int i in numbers)
            {
                if(!result.HasValue||i<result)
                {
                    result = i;
                }
            }
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
