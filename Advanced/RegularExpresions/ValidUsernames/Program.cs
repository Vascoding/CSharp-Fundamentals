using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidUsernames
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Regex regex = new Regex("^[\\w-]{3,16}$");
                if (regex.IsMatch(input))
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }

                input = Console.ReadLine();
            }
        }
    }
}
