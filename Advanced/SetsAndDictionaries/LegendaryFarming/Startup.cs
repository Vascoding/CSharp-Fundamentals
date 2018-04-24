using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LegendaryFarming
{
    class Startup
    {
        static void Main(string[] args)
        {

            Dictionary<string, int> keyMaterials = new Dictionary<string, int>();
            SortedDictionary<string, int> junkMaterials = new SortedDictionary<string, int>();
            keyMaterials.Add("shards", 0);
            keyMaterials.Add("fragments", 0);
            keyMaterials.Add("motes", 0);

            while (true)
            {
                string[] input = Console.ReadLine().ToLower().Split(' ').ToArray();
                for (int i = 0; i < input.Length; i += 2)
                {
                    int quantity = int.Parse(input[i]);
                    string material = input[i + 1];
                    if (keyMaterials.ContainsKey(material))
                    {
                        keyMaterials[material] += quantity;
                        if (keyMaterials["shards"] >= 250)
                        {
                            keyMaterials["shards"] -= 250;
                            Console.WriteLine("Shadowmourne obtained!");

                            foreach (var d in keyMaterials.OrderByDescending(v => v.Value))
                            {
                                Console.WriteLine($"{d.Key}: {d.Value}");
                            }
                            foreach (var d in junkMaterials)
                            {
                                Console.WriteLine($"{d.Key}: {d.Value}");
                            }
                            return;
                        }
                        if (keyMaterials["fragments"] >= 250)
                        {
                            keyMaterials["fragments"] -= 250;
                            Console.WriteLine("Valanyr obtained!");
                            foreach (var d in keyMaterials.OrderByDescending(v => v.Value))
                            {
                                Console.WriteLine($"{d.Key}: {d.Value}");
                            }
                            foreach (var d in junkMaterials)
                            {
                                Console.WriteLine($"{d.Key}: {d.Value}");
                            }
                            return;
                        }
                        if (keyMaterials["motes"] >= 250)
                        {
                            keyMaterials["motes"] -= 250;
                            Console.WriteLine("Dragonwrath obtained!");
                            foreach (var d in keyMaterials.OrderByDescending(v => v.Value))
                            {
                                Console.WriteLine($"{d.Key}: {d.Value}");
                            }
                            foreach (var d in junkMaterials)
                            {
                                Console.WriteLine($"{d.Key}: {d.Value}");
                            }
                            return;
                        }
                    }

                    else
                    {
                        junkMaterials.Add(material, 0);
                        junkMaterials[material] += quantity;
                    }

                }
            }
        }
    }
}
