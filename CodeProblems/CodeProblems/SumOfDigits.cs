using System;

namespace CodeProblems
{
	internal class SumOfDigits
	{
		/*
		 Sum of digits program in C#
We can write the sum of digits program in C# language by the help of loop and mathematical operation only.

Sum of digits algorithm
To get sum of each digit by C# program, use the following algorithm:

Step 1: Get number by user
Step 2: Get the modulus/remainder of the number
Step 3: sum the remainder of the number
Step 4: Divide the number by 10
Step 5: Repeat the step 2 while number is greater than 0.
Let's see the sum of digits program in C#.
Enter a number: 23
Sum is= 5
		 */

		public static void Main1()
		{
			int n, sum = 0, m;
			Console.Write("Enter a number: ");
			n = int.Parse(Console.ReadLine());
			while (n > 0)
			{
				m = n % 10;
				sum = sum + m;
				n = n / 10;
			}
			Console.Write("Sum is= " + sum);
		}
	}
}