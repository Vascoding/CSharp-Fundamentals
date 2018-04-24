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

            Dictionary<string, string> dict = new Dictionary<string, string>();
            var count = 1;
            var name = input;
            while (!input.Equals("stop"))
            {

                if (count % 2 != 0)
                {
                    if (!dict.ContainsKey(input))
                    {
                        dict.Add(input, string.Empty);
                    }
                    name = input;
                }
                else
                {
                    if (dict.ContainsKey(name))
                    {
                        if (input.ToUpper().EndsWith("US") || input.ToUpper().EndsWith("UK"))
                        {
                            dict.Remove(name);
                        }
                        else
                        {
                            dict[name] = input;
                        }
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
