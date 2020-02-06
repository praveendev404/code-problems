using System;

namespace CodeProblems
{
	internal class PrimeNumber
	{
		/*    Prime number is a number that is greater than 1 and divided by 1 or itself.In other words, prime numbers can't be divided by other numbers than itself or 1. For example 2, 3, 5, 7, 11, 13, 17, 19, 23.... are the prime numbers.

    Let's see the prime number program in C#. In this C# program, we will take an input from the user and check whether the number is prime or not.

                Enter the Number to check Prime: 17
    Number is Prime.
    Enter the Number to check Prime: 57
    Number is not Prime.
        */

		public static void Main1()
		{
			int n, i, m = 0, flag = 0;
			Console.Write("Enter the Number to check Prime: ");
			n = int.Parse(Console.ReadLine());
			m = n / 2;
			for (i = 2; i <= m; i++)
			{
				if (n % i == 0)
				{
					Console.Write("Number is not Prime.");
					flag = 1;
					break;
				}
			}
			if (flag == 0)
				Console.Write("Number is Prime.");
		}
	}
}