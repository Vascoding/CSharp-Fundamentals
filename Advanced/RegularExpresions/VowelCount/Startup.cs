using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace VowelCount
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("[aeiouyAEIOUY]");

            Console.WriteLine($"Vowels: {regex.Matches(input).Count}");
        }
    }
}
