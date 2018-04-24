using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMinFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(Console.ReadLine().Split().Select(int.Parse).Min());
        }
    }
}
