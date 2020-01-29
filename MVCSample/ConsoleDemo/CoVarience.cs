using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{

	class Animal
	{
		public int NumberOfLegs = 4;
	}
	class Dog1 : Animal
	{
	}
	class CoVarience
	{
		static void Main()
		{
			Animal a1 = new Animal();
			Animal a2 = new Dog1();
			Console.WriteLine("Number of Dog1 legs: {0}", a2.NumberOfLegs);
		}
	}
}
