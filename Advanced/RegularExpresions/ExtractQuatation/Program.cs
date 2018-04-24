using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractQuatation
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("(\\\"|\')(.*?)\\1");

            var matches = regex.Matches(input);

            foreach (Match match in matches)
            {
                Console.WriteLine($"{match.Groups[2].Value}");
            }
        }
    }
}
