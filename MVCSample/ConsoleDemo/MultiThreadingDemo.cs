using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class MultiThreadingDemo
    {
        static void Test1()
        {
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine("Value is : " + i);
            }
        }
        static void Test2()
        {
            for (int i = 0; i < 5; i++)
            {
                if (i == 2)
                    Thread.Sleep(10000);
                Console.WriteLine("Value is : " + i);
            }
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
            Thread t1 = new Thread(() => Test1());
            t1.Start();//or 
            ThreadStart ts = new ThreadStart(() => Test1());
            Thread t11 = new Thread(ts);//OR
            ThreadStart obj = () => Test1();
            t11.Start();
            Thread t2 = new Thread(() => Test2());
            t2.Start();
            ParameterizedThreadStart pt = new ParameterizedThreadStart(Test3);
            Thread th = new Thread(pt);
            th.Start(20);


            Console.ReadLine();
        }
    }
}
