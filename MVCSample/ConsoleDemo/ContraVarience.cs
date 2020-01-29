using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
	class ContraVarience
	{
		delegate void Action1<in T>(T a);//in is the Keyword for contravariance
		static void ActOnAnimal(Animal a)
		{
			Console.WriteLine(a.NumberOfLegs);
			Console.ReadLine();
		}
		static void Main()
		{
			Action1<Animal> act1 = ActOnAnimal;
			Action1<Dog> dog1 = act1;
			dog1(new Dog());
		}
		class Animal
		{
			public int NumberOfLegs = 4;
		}
		class Dog : Animal { }
	}
	
}
