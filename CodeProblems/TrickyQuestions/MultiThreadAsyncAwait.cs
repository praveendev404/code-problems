using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    class MultiThreadAsyncAwait
    {

        static void Main1()
        {
            TestMehod();
            Console.WriteLine("Main Thread started");
        }

        static async void TestMehod()
        {
            Console.WriteLine("Test started");
            await Task.Run(new Action(LogTask));
        }

        static void LogTask()
        {
            Thread.Sleep(5000);
        }
    }
}
