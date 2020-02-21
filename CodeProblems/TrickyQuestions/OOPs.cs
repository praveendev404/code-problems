using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    class OOPs : iface
    {

        public void m1() 
        {
        }
        public static void Main1(string[] args)
        {
            // absClass a = new absClass();
            iface o = new OOPs();
            
        }
    }

    abstract class absClass
    {
        public absClass()
        {

        }
    }
    public interface iface
    {
        void m1();
    }


    class program1
    {
        abstract class animal
        {
            public abstract void eat();
            public void sound()
            {
                Console.WriteLine("dog can sound");
            }
        }
        class dog : animal
        {
            public override void eat() { Console.WriteLine("dog can eat"); }
        }
        static void Main1(string[] args)
        {
            dog mydog = new dog();
            animal thePet = mydog;
            thePet.sound();//.eat();
            mydog.sound();
        }
    }
}
