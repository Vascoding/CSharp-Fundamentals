using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MatchCount
{
    class Startup
    {
        static void Main(string[] args)
        {
            Regex regex = new Regex(Console.ReadLine());
            var input = Console.ReadLine();
            Console.WriteLine(regex.Matches(input).Count);
        }
    }
}
