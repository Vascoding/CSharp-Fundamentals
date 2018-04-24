using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TakeTwo
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ReadLine().Split().Select(int.Parse).Distinct().Where(i => i >= 10 && i <= 20).Take(2).ToList().ForEach(a => Console.Write(a + " "));
        }
    }
}
