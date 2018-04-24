using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CubicAssault
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();
            while (true)
            {
                var input = Console.ReadLine();
                if (input.Equals("Count em all"))
                {
                    break;
                }
                var splited = input.Split(new[] { " -> " }, StringSplitOptions.RemoveEmptyEntries);
                
                var regionName = splited[0];
                var meteorType = splited[1];
                var count = long.Parse(splited[2]);
                if (!dict.ContainsKey(regionName))
                {
                    dict.Add(regionName, new Dictionary<string, long>());
                    dict[regionName].Add("Black", new long());
                    dict[regionName].Add("Red", new long());
                    dict[regionName].Add("Green", new long());
                }

                if (dict[regionName][meteorType] + count >= 1000000)
                {
                    dict[regionName][meteorType] += count;

                    if (meteorType == "Red")
                    {
                        dict[regionName]["Black"] += dict[regionName]["Red"] / 1000000;
                        dict[regionName]["Red"] %= 1000000;
                    }
                    if (meteorType == "Green")
                    {
                        dict[regionName]["Red"] += dict[regionName]["Green"] / 1000000;
                        dict[regionName]["Green"] %= 1000000;
                        if (dict[regionName]["Red"] >= 1000000)
                        {
                            dict[regionName]["Black"] += dict[regionName]["Red"] / 1000000;
                            dict[regionName]["Red"] %= 1000000;
                        }
                    }
                }
                else
                {
                    dict[regionName][meteorType] += count;
                }
            }

            foreach (var d in dict.OrderByDescending(v => v.Value["Black"]).ThenBy(k => k.Key.Length).ThenBy(k => k.Key))
            {
                Console.WriteLine($"{d.Key}");
                foreach (var v in d.Value.OrderByDescending(v => v.Value).ThenBy(k => k.Key))
                {
                    Console.WriteLine($"-> {v.Key} : {v.Value}");
                }
            }
        }
    }
}
