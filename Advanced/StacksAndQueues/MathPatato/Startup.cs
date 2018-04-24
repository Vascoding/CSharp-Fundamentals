using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MathPatato
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split().ToArray();
            int count = int.Parse(Console.ReadLine());
            Queue<string> queue = new Queue<string>(input);
            var cycle = 1;
            while (queue.Count != 1)
            {
                for (int i = 1; i < count; i++)
                {
                    queue.Enqueue(queue.Dequeue());
                }
                
                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {queue.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {queue.Dequeue()}");
                }
                cycle++;

            }
            Console.WriteLine($"Last is {queue.Dequeue()}");
        }
        public static bool IsPrime(int number)
        {
            if (number == 0 || number == 1)
            {
                return false;
            }
            if (number == 2)
            {
                return true;
            }
            if (number % 2 == 0)
            {
                return false;
            }
            int maxDivider = (int)Math.Sqrt(number);
            for (int divider = 3; divider <= maxDivider; divider += 2)
            {
                if (number % divider == 0)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
