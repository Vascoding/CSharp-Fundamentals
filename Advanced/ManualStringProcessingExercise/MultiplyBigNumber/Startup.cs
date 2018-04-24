using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace MultiplyBigNumber
{
    class Startup
    {
        static void Main(string[] args)
        {
            var first = BigInteger.Parse(Console.ReadLine());
            var second = BigInteger.Parse(Console.ReadLine());
            BigInteger result = first * second;
            Console.WriteLine($"{result}");
        }
    }
}
