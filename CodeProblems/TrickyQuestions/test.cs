using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
	public class test
	{
		static void Main1(string[] args)
		{
			WithDoubleEqual();
			WithEqualsExtension();
			
			var v = 123;
			var sss = "aaaaa";
			Console.WriteLine(v.GetHashCode());
			Console.ReadLine();
		}

		private static void WithDoubleEqual()
		{
			object o = "Hellow world";
			object o1 = o;
			Console.WriteLine(o == o1);
			Console.WriteLine(o.Equals(o1));

		}
		private static void WithEqualsExtension()
		{
			object o = "Hellow world";
			object o1 = new string("Hellow world".ToCharArray());
			Console.WriteLine(o == o1);
			Console.WriteLine(o.Equals(o1));
		}
	}
	public class teatc: Interface2
	{
		public void Mul()
		{

		}
		public void Add()
		{

		}
		private sealed  class teatc1
		{
			public teatc1() { }
		}
		//private class teatc2: teatc1
		//{

		//}
	}
}
