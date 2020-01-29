using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
    public   class c1
    {
        public static int MyProperty { get; set; }

       public static void M1()
        {

        }     
    }
    class Class1
    {
       
        static void Main(string args)
        {
            DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);
            DateTime dutc = DateTime.UtcNow;
            DateTime dnow = DateTime.Now;
            TimeZoneInfo localZone = TimeZoneInfo.Local;
            var lst = TimeZoneInfo.GetSystemTimeZones();
            var tzi = TimeZoneInfo.FindSystemTimeZoneById(localZone.Id);
            var aussieTime = TimeZoneInfo.ConvertTimeFromUtc(dutc, tzi);
            DateTime date = aussieTime;
          
            Console.Read();
            // c1.M1();
            c1 c = new c1();   
           
        }
        
    }
 
}
