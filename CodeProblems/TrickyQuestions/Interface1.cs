using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrickyQuestions
{
	interface Interface1
	{
		void Mul();
	}
	interface Interface2: Interface1
	{
		void Add();
	}
}
