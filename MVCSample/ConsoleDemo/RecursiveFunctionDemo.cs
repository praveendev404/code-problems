using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class RecursiveFunctionDemo
    {
       
        static void Main(string[] args)
        {

            
            int n = 5;
            long fact = Factorial(n);


        }

        public static long Factorial(int n)
        {
            long fact = 0;
            if (n == 0)
                return 1;

            return n * Factorial(n - 1);
        }
    }
}
