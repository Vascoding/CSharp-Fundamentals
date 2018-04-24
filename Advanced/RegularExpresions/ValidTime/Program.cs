using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ValidTime
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                Regex regex = new Regex("^[01][0-9](:[0-5]\\d){2} (A|P)M");
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
