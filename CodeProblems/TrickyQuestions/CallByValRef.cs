using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    public class CallByValRef
    {
        public class employee

        {

            public void display(int a, String b)

            {
                b = b + "eretyuiokujyhgrfedswefrgthyuj";
                Console.WriteLine("Integer value is" + " " + a);

                Console.WriteLine(" String value is" + " " + b);

                //Console.ReadLine();

            }



        }

        public class student

        {

            public void show(ref String str)

            {

                Console.WriteLine("Enter the value");

                string s = Console.ReadLine();

                str = str + s;

                Console.WriteLine("value in str variable is" + " " + str);

                Console.ReadLine();

            }



        }

        //all class member is called through main method.



        static void Main1(string[] args)

        {

            //creating the object of employee class first and implementing the call by value concept.

            String m = "Praveen";

            employee emp = new employee();

            emp.display(200, m);

            Console.WriteLine("value in variable m is" + " " + m);

            Console.ReadLine();



            //creating the object of employee class first and implementing the call by Reference concept

            string msg = "Hello";

            student st = new student();

            st.show(ref msg);

            Console.WriteLine("value in msg is" + " " + msg);//value at address msg will  be print,becausehereaddress is copy not value thatswhy at same address value will be print

            Console.ReadLine();

        }

    }

}

