using System;

namespace CodeProblems
{
	internal class FibonacciTriangle
	{
		/*
         Enter the limit: 9
1
1	1
1	1	2
1	1	2	3
1	1	2	3	5
1	1	2	3	5	8
1	1	2	3	5	8	13
1	1	2	3	5	8	13	21
1	1	2	3	5	8	13	21	34
             */

		public static void Main1()
		{
			int a = 0, b = 1, i, c, n, j;
			Console.Write("Enter the limit: ");
			n = int.Parse(Console.ReadLine());
			for (i = 1; i <= n; i++)
			{
				a = 0;
				b = 1;
				Console.Write(b + "\t");
				for (j = 1; j < i; j++)
				{
					c = a + b;
					Console.Write(c + "\t");
					a = b;
					b = c;
				}
				Console.Write("\n");
			}
		}
	}
}