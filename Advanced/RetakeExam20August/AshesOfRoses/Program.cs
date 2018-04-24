using System.Text.RegularExpressions;

namespace AshesOfRoses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Program
    {
        public static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Icarus, Ignite!"))
                {
                    break;
                }

                Regex regex = new Regex(@"^Grow <{1}([A-Z]{1}[a-z]+)>{1} <{1}([a-zA-Z0-9]+)>{1} ([0-9]+)$");
                if (regex.IsMatch(input))
                {
                    var regionName = regex.Match(input).Groups[1].Value;
                    var color = regex.Match(input).Groups[2].Value;
                    var amount = int.Parse(regex.Match(input).Groups[3].Value);
                    if (!dict.ContainsKey(regionName))
                    {
                        dict.Add(regionName, new Dictionary<string, long>());
                    }
                    if (!dict[regionName].ContainsKey(color))
                    {
                        dict[regionName].Add(color, 0);
                    }
                    dict[regionName][color] += amount;
                }
            }

            foreach (var d in dict.OrderByDescending(v => v.Value.Values.Sum()).ThenBy(a => a.Key))
            {
                Console.WriteLine($"{d.Key}");
                foreach (var v in d.Value.OrderBy(v => v.Value).ThenBy(k => k.Key))
                {
                    Console.WriteLine($"*--{v.Key} | {v.Value}");
                }
            }
        }
    }
}

