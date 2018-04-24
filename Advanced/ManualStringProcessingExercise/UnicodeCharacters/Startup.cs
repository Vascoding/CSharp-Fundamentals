using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnicodeCharacters
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().ToCharArray();
            var unicode = string.Empty;
            foreach (var i in input)
            {
                unicode += "\\u" + ((int)i).ToString("x4");
            }
            Console.WriteLine(unicode);
        }
    }
}
