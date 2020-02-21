using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    public delegate void RectDelegate(double width, double height);
    class MulticastDelegateDemo
    {
        public void GetArea(double width,double hiight)
        {
            Console.WriteLine(width*hiight);
        }
        public void GetPerimeter(double width, double hiight)
        {
            Console.WriteLine(2*(width + hiight));
        }
        static void Main1(string[] args)
        {
            MulticastDelegateDemo obj = new MulticastDelegateDemo();
            RectDelegate del = obj.GetArea;
            del += obj.GetPerimeter;
            del.Invoke(2,3);
        }
    }
}
