using System;

namespace CodeProblems
{
	internal class Palindrome
	{
		/*	Palindrome number algorithm
	Get the number from user
	Hold the number in temporary variable
	Reverse the number
	Compare the temporary number with reversed number
	If both numbers are same, print palindrome number
	Else print not palindrome number
	Let's see the palindrome program in C#. In this program, we will get an input from the user and check whether number is palindrome or not.
	Enter the Number=121
	Number is Palindrome.
	Enter the number=113
	Number is not Palindrome.
	*/

		public static void Main()
		{
			int n, r, sum = 0, temp;
			Console.Write("Enter the Number: ");
			n = int.Parse(Console.ReadLine());
			temp = n;
			while (n > 0)
			{
				r = n % 10;
				sum = (sum * 10) + r;
				n = n / 10;
			}
			if (temp == sum)
				Console.Write("Number is Palindrome.");
			else
				Console.Write("Number is not Palindrome");
		}
	}
}