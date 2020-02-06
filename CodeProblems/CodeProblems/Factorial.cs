using System;

namespace CodeProblems
{
	internal class Factorial
	{
		/*  Factorial Program in C#: Factorial of n is the product of all positive descending integers. Factorial of n is denoted by n!. For example:

  4! = 4*3*2*1 = 24
  6! = 6*5*4*3*2*1 = 720
  Here, 4! is pronounced as "4 factorial", it is also called "4 bang" or "4 shriek".

  The factorial is normally used in Combinations and Permutations(mathematics).

  Let? s see the factorial program in C# using for loop.

   Enter any Number: 6
  Factorial of 6 is: 720
               */

		public static void Main1()
		{
			int i, fact = 1, number;
			Console.Write("Enter any Number: ");
			number = int.Parse(Console.ReadLine());
			for (i = 1; i <= number; i++)
			{
				fact = fact * i;
			}
			Console.Write("Factorial of " + number + " is: " + fact);
		}
	}
}