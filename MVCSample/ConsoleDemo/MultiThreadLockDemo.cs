using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class MultiThreadLockDemo
    {
        public void Display()
        {
            lock(this)
            {
                Console.Write("Hi");
                Thread.Sleep(5000);
                Console.WriteLine("Prave");
            }
           
        }

        static void Main()
        {
            MultiThreadLockDemo locking = new MultiThreadLockDemo();
            Thread t1 = new Thread(locking.Display);
            t1.Start();
            Thread t2 = new Thread(locking.Display);
            t2.Start();
            Console.ReadLine();
        }
    }
}
