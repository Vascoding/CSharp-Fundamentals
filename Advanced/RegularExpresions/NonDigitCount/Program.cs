using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NonDigitCount
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Regex regex = new Regex("\\D");

            Console.WriteLine($"Non-digits: {regex.Matches(input).Count}");
        }
    }
}
