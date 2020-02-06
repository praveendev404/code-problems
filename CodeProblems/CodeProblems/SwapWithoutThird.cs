using System;

namespace CodeProblems
{
	internal class SwapWithoutThird
	{
		/*
         next →← prev
C# Program to swap two numbers without third variable
We can swap two numbers without using third variable. There are two common ways to swap two numbers without using third variable:

By + and -
By * and /
Program 1: Using ∗ and /
Let's see a simple C# example to swap two numbers without using third variable.

			Before swap a= 5 b= 10
After swap a= 10 b= 5
             */

		public static void UsingStartSlash()
		{
			int a = 5, b = 10;
			Console.WriteLine("Before swap a= " + a + " b= " + b);
			a = a * b; //a=50 (5*10)
			b = a / b; //b=5 (50/10)
			a = a / b; //a=10 (50/5)
			Console.Write("After swap a= " + a + " b= " + b);
		}

		public static void UsingPlusMinus()
		{
			int a = 5, b = 10;
			Console.WriteLine("Before swap a= " + a + " b= " + b);
			a = a * b; //a=50 (5*10)
			b = a / b; //b=5 (50/10)
			a = a / b; //a=10 (50/5)
			Console.Write("After swap a= " + a + " b= " + b);
		}
	}
}