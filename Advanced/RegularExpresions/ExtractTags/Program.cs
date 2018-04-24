using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractTags
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            
            while (!input.Equals("END"))
            {
                Regex regex = new Regex("<.+?>");
                MatchCollection matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    Console.WriteLine(match);
                }
                input = Console.ReadLine();
            }
        }
    }
}
