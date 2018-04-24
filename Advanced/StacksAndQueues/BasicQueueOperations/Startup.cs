using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BasicStackOperations
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

            Queue<int> queue = new Queue<int>();
            for (int i = 0; i < n; i++)
            {
                queue.Enqueue(elements[i]);
            }
            for (int i = 0; i < s; i++)
            {
                queue.Dequeue();
            }
            if (queue.Count == 0)
            {
                Console.WriteLine("0");
            }
            else
            {
                if (queue.Contains(x))
                {
                    Console.WriteLine("true");
                }
                else
                {
                    Console.WriteLine(queue.Min());
                }
            }

        }
    }
}
