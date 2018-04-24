using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstName
{
    class Program
    {
        static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().ToList();
            var leters = Console.ReadLine().Split().ToList().OrderBy(a => a);
            var name = string.Empty;
            foreach (var leter in leters)
            {
                name = names.FirstOrDefault(a => a.ToLower().StartsWith(leter.ToLower()));
                if (name != null)
                {
                    Console.WriteLine(name);
                    break;
                }
            }
            if (name == null)
            {
                Console.WriteLine("No match");
            }
        }
    }
}
