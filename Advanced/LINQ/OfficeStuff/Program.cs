//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace OfficeStuff
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var n = int.Parse(Console.ReadLine());
//            Dictionary<string, Dictionary<string, int>> dict = new Dictionary<string, Dictionary<string, int>>();
//            for (int i = 0; i < n; i++)
//            {
//                var input = Console.ReadLine().Split(new []{' ', '-', '|'}, StringSplitOptions.RemoveEmptyEntries);
//                var company = input[0];
//                var product = input[2];
//                var amount = int.Parse(input[1]);
//                if (!dict.ContainsKey(company))
//                {
//                    dict.Add(company, new Dictionary<string, int>());
//                }
//                if (!dict[company].ContainsKey(product))
//                {
//                    dict[company].Add(product, amount);
//                }
//                else
//                {
//                    dict[company][product] += amount;
//                }

//            }
//            foreach (var d in dict.OrderBy(c => c.Key))
//            {
//                Console.WriteLine($"{d.Key}: {string.Join("  ", d.Value).Replace(", ", "-").Replace("[", "").Replace("]", "").Replace("  ", ", ")}");
//            }
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        var dict = new Dictionary<string, SortedDictionary<string, Dictionary<string, int>>>();
        int n = int.Parse(Console.ReadLine());
        for (int a = 0; a < n; a++)
        {
            string[] input = Console.ReadLine().Split();
            while (input.Contains("null"))
            {
                int index = Array.IndexOf(input, "null");
                switch (index)
                {
                    case 2:
                        input[index] = "250";
                        break;
                    case 3:
                        input[index] = "45";
                        break;
                    case 4:
                        input[index] = "10";
                        break;
                }
            }
            string type = input[0];
            string name = input[1];
            int damage = int.Parse(input[2]);
            int health = int.Parse(input[3]);
            int armor = int.Parse(input[4]);
            if (!dict.ContainsKey(type))
            {
                dict[type] = new SortedDictionary<string, Dictionary<string, int>>();
            }
            if (!dict[type].ContainsKey(name))
            {
                dict[type][name] = new Dictionary<string, int>();
            }
            dict[type][name]["damage"] = damage;
            dict[type][name]["health"] = health;
            dict[type][name]["armor"] = armor;
        }
        foreach (KeyValuePair<string, SortedDictionary<string, Dictionary<string, int>>> a in dict)
        {
            double averageDamage = 0;
            double averageHealth = 0;
            double averageArmor = 0;
            Console.WriteLine($"{a.Key}::({averageDamage}/{averageHealth}/{averageArmor})");
            foreach (KeyValuePair<string, Dictionary<string, int>> b in a.Value)
            {
                Console.Write($"-{b.Key} -> ");
                bool isFirst = true;
                foreach (KeyValuePair<string, int> c in b.Value)
                {
                    if (isFirst == false)
                    {
                        Console.Write(", ");
                    }
                    isFirst = false;
                    Console.Write($"{c.Key}: {c.Value}");
                }
                Console.WriteLine();
            }
        }
    }
}