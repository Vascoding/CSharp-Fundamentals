using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ParseTags
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            Regex regex = new Regex("(<upcase>[a-z A-Z]+<\\/upcase>)");
            var matches = regex.Matches(input);
            foreach (Match match in matches)
            {
                var index = match.ToString().IndexOf("</upcase>");
                var replace = match.ToString().Substring(8, index - 8).ToUpper();
                input = input.Replace(match.ToString(), replace);

            }

            Console.WriteLine(input);
        }
    }
}
