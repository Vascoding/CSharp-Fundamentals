using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculateSequenceWithQueue
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = long.Parse(Console.ReadLine());
            Queue<long> queue = new Queue<long>();
            queue.Enqueue(input);
            int count = 1;
            Console.Write("{0} ", input);
            while (count < 50)
            {
                input = queue.Dequeue();
                Console.Write("{0} ", input + 1);
                queue.Enqueue(input + 1);

                count++;
                if (count < 50)
                {
                    Console.Write("{0} ", 2 * input + 1);
                    queue.Enqueue(2 * input + 1);
                    count++;
                }
                else
                {
                    break;
                }
                if (count < 50)
                {
                    Console.Write("{0} ", input + 2);
                    queue.Enqueue(input + 2);
                    count++;
                }
                else
                {
                    break;
                }
            }
        }
    }
}
