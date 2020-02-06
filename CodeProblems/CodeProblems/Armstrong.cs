using System;

namespace CodeProblems
{
	class Armstrong
	{
		/*	Before going to write the C# program to check whether the number is Armstrong or not, let's understand what is Armstrong number.

	Armstrong number is a number that is equal to the sum of cubes of its digits.For example 0, 1, 153, 370, 371 and 407 are the Armstrong numbers.

	Let's try to understand why 371 is an Armstrong number.

	371 = (3*3*3)+(7*7*7)+(1*1*1)
	where:
	(3*3*3)=27
	(7*7*7)=343
	(1*1*1)=1
	So:
	27+343+1=371
	Let's see the C# program to check Armstrong Number.

				Enter the Number= 371
	Armstrong Number.
	Enter the Number= 342
	Not Armstrong Number.
		*/

		public static void Main1()
		{
			int n, r, sum = 0, temp;
			Console.Write("Enter the Number= ");
			n = int.Parse(Console.ReadLine());
			temp = n;
			while (n > 0)
			{
				r = n % 10;
				sum = sum + (r * r * r);
				n = n / 10;
			}
			if (temp == sum)
				Console.Write("Armstrong Number.");
			else
				Console.Write("Not Armstrong Number.");
		}
	}
}