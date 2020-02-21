using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace TrickyQuestions
{
   public class RegExDemo
    {
        public static void Main1()
        {
            var regex = new Regex(@"morphimages\(\'([a-z0-9_\.jpg]*)");
            var strContent = "morphimages[0]=http://www.autobase.com/photos/00320/1410/14107197_001.jpg";


            var imgUrlsList = new List<string>();

            foreach (Match match in regex.Matches(strContent)) imgUrlsList.Add(match.Value);

        }
    }
}
