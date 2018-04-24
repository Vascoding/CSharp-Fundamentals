using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PopulationCounter
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();

            while (!input[0].Equals("report"))
            {
                if (dict.ContainsKey(input[1]))
                {
                    dict[input[1]].Add(input[0], long.Parse(input[2]));
                }
                else
                {
                    dict.Add(input[1], new Dictionary<string, long>());
                    dict[input[1]].Add(input[0], long.Parse(input[2]));
                }

                input = Console.ReadLine().Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var d in dict.OrderByDescending(c => c.Value.Values.Sum()))
            {
                Console.WriteLine($"{d.Key} (total population: {d.Value.Sum(v => v.Value)})");
                foreach (var v in d.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"=>{v.Key}: {v.Value}");
                }
            }
        }
    }
}
