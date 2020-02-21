using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace TrickyQuestions
{
	class Program
	{
		/*
        //What is the output of the program below? Explain your answer.
        delegate void Printer();

        static void Main1()
        {
            List<Printer> printers = new List<Printer>();
            int i = 0;
            for (; i < 10; i++)
            {
                printers.Add(delegate { Console.WriteLine(i); });
            }

            foreach (var printer in printers)
            {
                printer();
            }
            Console.ReadLine();
        }
        */

		private static string result;

		static void Main()
		{
			DecimalTo.DecimalToBinary();
			//string s = "like for example $  you don't have $  network $  access";
			//Regex rgx = new Regex("\\$\\s+");
			//s = Regex.Replace(s, @"(\$\s+.*?)\$\s+", "$1$$");
			//Console.WriteLine("string is: {0}", s);
			//SaySomething();
			//Console.WriteLine(result);
			//TestStatic t = new TestStatic();
			//t.Print();
		}

		static async Task<string> SaySomething()
		{
			await Task.Delay(5);
			result = "Hello world!";
			return "Something";
		}
	}

	public class TestStatic
	{
		public static int TestValue;

		public TestStatic()
		{
			if (TestValue == 0)
			{
				TestValue = 5;
			}
		}
		static TestStatic()
		{
			if (TestValue == 0)
			{
				TestValue = 10;
			}

		}

		public void Print()
		{
			if (TestValue == 5)
			{
				TestValue = 6;
			}
			Console.WriteLine("TestValue : " + TestValue);

		}
	}

}
