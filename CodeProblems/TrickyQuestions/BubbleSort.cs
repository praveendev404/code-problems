using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
    public class BubbleSort
    {
        static void Main1(string[] args)
        {
            int[] numbers = { 3, 2, 5, 4, 1 };
            int t;
            Console.WriteLine("The Array is : ");
            for (int i = 0; i < numbers.Length; i++)
            {
                Console.WriteLine(numbers[i]);
            }
            for (int j = 0; j <= numbers.Length - 2; j++)
            {
                for (int i = 0; i <= numbers.Length - 2; i++)
                {
                    if (numbers[i] > numbers[i + 1])
                    {
                        t = numbers[i + 1];
                        numbers[i + 1] = numbers[i];
                        numbers[i] = t;
                    }
                }
            }
            foreach (int num in numbers)
            {
                Console.Write("\t {0}", num);
            }
            Console.Read();
        }
    }
}
