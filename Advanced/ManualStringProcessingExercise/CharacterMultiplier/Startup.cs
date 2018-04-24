using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CharacterMultiplier
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            var first = input[0].ToCharArray();
            var second = input[1].ToCharArray();
            var sum = 0;
            for (int i = 0; i < Math.Max(first.Length, second.Length); i++)
            {
                if (i < Math.Min(first.Length, second.Length))
                {
                    sum += first[i]*second[i];
                }
                else
                {
                    if (first.Length>second.Length)
                    {
                        sum += first[i];
                    }
                    else
                    {
                        sum += second[i];
                    }
                }
            }
            Console.WriteLine(sum);
        }
    }
}
