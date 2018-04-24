using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniqueUsernames
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = int.Parse(Console.ReadLine());
            HashSet<string> names = new HashSet<string>();
            for (int i = 0; i < input; i++)
            {
                var name = Console.ReadLine();
                names.Add(name);
            }
            Console.WriteLine(string.Join("\r\n", names));
        }
    }
}

