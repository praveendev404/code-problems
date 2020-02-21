using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
	public class PrimeNumber
	{
		static void Main1()
		{
			int num = 29;
			int count = 0;
			for (int i = 1; i <= num; i++)
			{
				if (num % i == 0)
				{
					count++;
				}
			}
			if (count == 2)
			{
				Console.WriteLine($"{num} is a prime number");
			}
			Console.ReadLine();
		}
	}
}
