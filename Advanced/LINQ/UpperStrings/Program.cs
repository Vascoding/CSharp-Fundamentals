using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UpperStrings
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries).Select(a => a.ToUpper()).ToList().ForEach(c => Console.Write(c + " "));
        }
    }
}
