using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ActionPrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<List<string>> print = message => Console.WriteLine(string.Join("\r\n", message));
            print(Console.ReadLine().Split().ToList());
        }
    }
}
