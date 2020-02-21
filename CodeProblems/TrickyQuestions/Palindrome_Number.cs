using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
	class Palindrome_Number
	{
		static void Main1(string[] args)
		{
			int num, rem, sum = 0, temp;
			//clrscr();    
			Console.WriteLine("\n >>>> To Find a Number is Palindrome or not <<<< ");
			Console.Write("\n Enter a number: ");
			num = Convert.ToInt32(Console.ReadLine());
			temp = num;
			while (num > 0)
			{
				rem = num % 10; //for getting remainder by dividing with 10    
				num = num / 10; //for getting quotient by dividing with 10    
				sum = sum * 10 + rem;
				/*multiplying the sum with 10 and adding  
				remainder*/
			}
			Console.WriteLine("\n The Reversed Number is: {0} \n", sum);
			if (temp == sum) //checking whether the reversed number is equal to entered number    
			{
				Console.WriteLine("\n Number is Palindrome \n\n");
			}
			else
			{
				Console.WriteLine("\n Number is not a palindrome \n\n");
			}
			Console.ReadLine();
		}
	}
}
