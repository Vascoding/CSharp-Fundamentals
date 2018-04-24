using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchPhoneNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("end"))
            {
                Regex regex = new Regex("^\\+359([ |-]){1}2\\1[0-9]{3}\\1[0-9]{4}\\b");

                var matches = regex.Matches(input);
                foreach (Match match in matches)
                {
                    Console.WriteLine($"{match}");
                }
                input = Console.ReadLine();
            }
        }
    }
}
