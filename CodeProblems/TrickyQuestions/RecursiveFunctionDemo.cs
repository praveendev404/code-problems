using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    class RecursiveFunctionDemo
    {
       
        static void Main1(string[] args)
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
