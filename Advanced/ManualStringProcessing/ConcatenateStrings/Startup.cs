using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConcatenateStrings
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();
                sb.Append(word + " ");
            }
            Console.WriteLine(sb);
        }
    }
}
