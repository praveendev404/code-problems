using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    class AbstractClasses
    {
        static void Main1(string[] args)
        {
            Dog dog = new Dog();
            Console.WriteLine(dog.Describe());
            Console.WriteLine(dog.TestOverride());
            Console.ReadKey();
        }
    }

    abstract class FourLeggedAnimal
    {
        public virtual string Describe()
        {
            return "Not much is known about this four legged animal!";
        }
        public abstract string TestOverride();
    }

    class Dog : FourLeggedAnimal
    {
		
		//public virtual string Describe()
		//{
		//    return "This animal has four legs.";
		//}

		public override string Describe()
        {
            return "This four legged animal is a Dog!";
        }

        //public override string Describe()
        //{
        //    string result = base.Describe();
        //    result += " In fact, it's a dog!";
        //    return result;
        //}

        public override string TestOverride()
        {
            return "TestOverride() method is overridden from derived class";
        }
    }
}
