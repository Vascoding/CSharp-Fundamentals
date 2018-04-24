using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PredicateForNames
{
    class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);

            Predicate<string> isValid = (string x) => x.Length <= n;
            Console.WriteLine(string.Join("\r\n", input.Where(isValid.Invoke)));
        }
    }
}
