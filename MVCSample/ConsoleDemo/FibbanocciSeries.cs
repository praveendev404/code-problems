using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
	class FibbanocciSeries
	{
		static void Main()
		{
			int num = 10;
			int a = 1, b = 2;
			int c;
			int k = 1;
			Console.Write(a+" ");
			while (k <= num)
			{
				//c = a + b;
				//a = b;
				//b = c;
				//Console.Write(c + " ");
				b = a + b;
				a = b;
				//b = c;
				Console.Write(b + " ");
				k++;
			}
			Console.ReadLine();
		}
	}
}
