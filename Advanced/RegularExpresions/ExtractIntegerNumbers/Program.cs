using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractIntegerNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("\\d+");
            var matches = regex.Matches(input);
            foreach (var match in matches)
            {
                Console.WriteLine(match);
            }
            
        }
    }
}
