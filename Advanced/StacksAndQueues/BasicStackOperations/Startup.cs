using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicQueueOperations
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var elements = Console.ReadLine().Split().Select(int.Parse).ToArray();

            var n = input[0];
            var s = input[1];
            var x = input[2];

            Stack<int> stack = new Stack<int>();
            for (int i = 0; i < n; i++)
            {
                stack.Push(elements[i]);
            }
            for (int i = 0; i < s; i++)
            {
                stack.Pop();
            }
            if (stack.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (stack.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(stack.Min());
                }
            }
        }
    }
}
