using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotPatato
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            int count = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);

            while (queue.Count != 1)
            {
                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                Console.WriteLine($"Removed {queue.Dequeue()}");
            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
    }
}
