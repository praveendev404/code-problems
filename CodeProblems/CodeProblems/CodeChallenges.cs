using System;
using System.Collections.Generic;
using System.Text;

namespace CodeProblems
{
	static class CodeChallenges
	{
		static String location;
		static DateTime time;
		
		public static void CodeChallenge()
		{
			Console.WriteLine(location == null ? "location is null" : location);
			Console.WriteLine(time == null ? "time is null" : time.ToString());
			//Console.ReadLine();


		}
	}
}
