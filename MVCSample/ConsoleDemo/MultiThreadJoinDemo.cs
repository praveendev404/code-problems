using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class MultiThreadJoinDemo
    {
        static void Test1()
        {
            Console.WriteLine("Child test1 started");
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Value is : " + i);
            }
            Console.WriteLine("Child test1 ended");
        }
        static void Test2()
        {
            Console.WriteLine("Child test2 started");
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                    Thread.Sleep(10000);
                Console.WriteLine("Value is : " + i);
            }
            Console.WriteLine("Child test2 ended");
        }
        static void Test3(object num)
        {
            int maxNum = Convert.ToInt32(num);
            for (int i = 0; i < maxNum; i++)
            {
                //if (i == 2)
                //    Thread.Sleep(10000);
                Console.WriteLine("Value is : " + i);
            }
        }

        static void Main()
        {
            Console.WriteLine("Main thread started");
            Thread t1 = new Thread(() => Test1());
            t1.Start();
            t1.Join();         
            Thread t2 = new Thread(() => Test2());
            t2.Start();
            t2.Join();
            Console.WriteLine("Main thread ended");
            Console.ReadLine();
        }
    }
}
