using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    class ExtensionMethods
    {
        static void Main(string[] args)
        {
            DateTime dt = DateTime.ParseExact("24/01/2013", "dd/MM/yyyy", CultureInfo.InvariantCulture);
            DateTime date31 = DateTime.ParseExact("15/07/2017", "mm/dd/yyyy", CultureInfo.InvariantCulture);

            ExtDemoClass ob = new ExtDemoClass();
            ob.Display();
            ob.Print();
            ob.NewMethod();
            Console.ReadKey();
        }
    }
    public static class XX
    {
        public static void NewMethod(this ExtDemoClass ob)
        {
            Console.WriteLine("Hello I m extended method");
        }
    }
    public class ExtDemoClass
    {
        public string Display()
        {
            return ("I m in Display");
        }

        public string Print()
        {
            return ("I m in Print");
        }
    }
}
