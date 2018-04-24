using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MinerTask
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            Dictionary<string, long> dict = new Dictionary<string, long>();
            var count = 1;
            var name = input;
            while (!input.Equals("stop"))
            {
                
                if (count % 2 != 0)
                {
                    if (!dict.ContainsKey(input))
                    {
                        dict.Add(input, 0);
                    }
                    name = input;
                }
                else
                {
                    if (dict.ContainsKey(name))
                    {
                        dict[name] += int.Parse(input);
                    }
                }

                input = Console.ReadLine();
                count++;
            }

            foreach (var d in dict)
            {
                Console.WriteLine($"{d.Key} -> {d.Value}");
            }
        }
    }
}
