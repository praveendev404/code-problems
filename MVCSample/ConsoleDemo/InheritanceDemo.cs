using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleDemo
{
	class InheritanceDemo : IA,IB
	{
		public void Add(int a, int b)
		{

		}
		static void Main()
		{
			InheritanceDemo obj = new InheritanceDemo();
			obj.Add(1,1);
		}
	}
	abstract class A
	{
		public abstract void Add(int a, int b);
		
	}
	interface IA
	{
		void Add(int a,int b);
	}
	interface IB
	{
		void Add(int a, int b);
	}
}
