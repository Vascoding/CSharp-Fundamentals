using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReverseStrings
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            Stack<char> stack = new Stack<char>();
            foreach (var ch in input)
            {
                stack.Push(ch);
            }
            foreach (var s in stack)
            {
                Console.Write(s);
            }
            Console.WriteLine();
        }
    }
}
