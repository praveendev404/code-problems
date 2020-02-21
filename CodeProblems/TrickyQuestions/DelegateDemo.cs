using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    public delegate void AddDelegate(int x, int y);
    class DelegateDemo
    {
        delegate void operation();

        public static void AddNums(int x,int y)
        {
            Console.WriteLine(x+y);
        }
        static void Main1(string[] args)
        {


            AddDelegate del = new AddDelegate(AddNums);
            del.Invoke(1,2);

            // Delegate instantiation   ann method
            operation obj = delegate
            {
                Console.WriteLine("Anonymous method");
            };
            obj();

            Console.ReadLine();
        }

    }
}
