using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
	class Palindrom
	{
		static void Main1()
		{
			string str = "radar";
			int length = str.Length;

			bool isPalindrom=IsPalindrom(str, length);
			if (isPalindrom)
				Console.WriteLine($"{str} is palindrom");
			Console.ReadLine();

		}

		private static bool IsPalindrom(string str, int length)
		{
			for (int i = 0; i < length / 2; i++)
			{
				if (str[i] != str[length - (i+1)])
				{
					return false;
				}
			}
			return true;
		}
	}
}
