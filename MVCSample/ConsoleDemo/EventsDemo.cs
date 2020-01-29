using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class EventsDemo
    {
        public event EventHandler TestEvent
        {
            add
            {
                Console.WriteLine("add operation");
            }
            remove
            {
                Console.WriteLine("remove operation");
            }
        }
        static void Main()
        {
            EventsDemo obj = new EventsDemo();
            obj.TestEvent += new EventHandler(obj.SayHellow);


        }
        public void SayHellow(object sender,EventArgs e)
        {
            Console.WriteLine("Hello praveen");

        }
    }
}
