using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchFullName
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                Regex regex = new Regex("^([A-Z]{1}[a-z]+ [A-Z]{1}[a-z]+)");
                if (regex.IsMatch(input))
                {
                    Console.WriteLine($"{regex.Match(input)}");
                }

                input = Console.ReadLine();
            }
        }
    }
}
