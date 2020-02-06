using System;

namespace CodeProblems
{
	internal class ReverseNumber
	{
		/*
		We can reverse a number in C# using loop and arithmetic operators. In this program, we are getting number as input from the user and reversing that number.

Let's see a simple C# example to reverse a given number.
Enter a number: 234
Reversed Number: 432

		*/

		public static void Main()
		{
			int n, reverse = 0, rem;
			Console.Write("Enter a number: ");
			n = int.Parse(Console.ReadLine());
			while (n != 0)
			{
				rem = n % 10;
				reverse = reverse * 10 + rem;
				n /= 10;
			}
			Console.Write("Reversed Number: " + reverse);
		}
	}
}