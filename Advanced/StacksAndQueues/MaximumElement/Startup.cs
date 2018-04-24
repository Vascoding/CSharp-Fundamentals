using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximumElement
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Stack<long> stack = new Stack<long>();
            long max = 0;
            for (int i = 0; i < n; i++)
            {
                var queue = Console.ReadLine().Split().Select(long.Parse).ToArray();

                if (queue[0].Equals(1))
                {
                    stack.Push(queue[1]);
                    if (max < queue[1])
                    {
                        max = queue[1];
                    }
                }
                if (queue[0].Equals(2))
                {
                    var element = stack.Pop();
                    if (element == max && stack.Count > 0)
                    {
                        max = stack.Max();
                    }
                    else if (element == max && stack.Count == 0)
                    {
                        max = 0;
                    }
                }
                if (queue[0].Equals(3))
                {
                    Console.WriteLine($"{max}");
                }
            }
        }
    }
}
