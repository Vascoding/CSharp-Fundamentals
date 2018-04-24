namespace GreedyTimes
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.Linq;

    public class Bag
    {
        public Bag(string name)
        {
            this.Name = name;
        }
        public string Name { get; set; }
        public int Amount { get; set; }
    }

    public class Program
    {
        public static void Main()
        {
            Dictionary<string, List<Bag>> bag = new Dictionary<string, List<Bag>>();
            bag.Add("Cash", new List<Bag>());
            bag.Add("Gem", new List<Bag>());
            bag.Add("Gold", new List<Bag>());

            var maxAmount = int.Parse(Console.ReadLine());
            var itemQuantityPair = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Dictionary<string, int> itemQuantityDict = new Dictionary<string, int>();
            for (int i = 0; i < itemQuantityPair.Length; i++)
            {
                if (i % 2 == 0)
                {
                    if (!itemQuantityDict.ContainsKey(itemQuantityPair[i].ToLower()))
                    {
                        itemQuantityDict.Add(itemQuantityPair[i].ToLower(), int.Parse(itemQuantityPair[i + 1]));
                    }
                    else
                    {
                        itemQuantityDict[itemQuantityPair[i].ToLower()] += int.Parse(itemQuantityPair[i + 1]);
                    }
                }
            }

            foreach (var item in itemQuantityDict)
            {
                if (item.Key.Length == 3 && item.Value + bag["Cash"].Sum(e => e.Amount) <= maxAmount && item.Value + bag["Cash"].Sum(a => a.Amount) <= bag["Gem"].Sum(d => d.Amount))
                {
                    var cash = new Bag(item.Key);
                    cash.Amount += item.Value;
                    bag["Cash"].Add(cash);
                }
                if (item.Key.Length >= 4 && item.Key.EndsWith("gem") && item.Value + bag["Gem"].Sum(e => e.Amount) >= bag["Cash"].Sum(a => a.Amount) && item.Value + bag["Gem"].Sum(e => e.Amount) <= maxAmount)
                {
                    var gem = new Bag(item.Key);
                    gem.Amount += item.Value;
                    bag["Gem"].Add(gem);
                }
                if (item.Key.ToLower().Equals("gold") && item.Value + bag["Gold"].Sum(e => e.Amount) >= bag["Gem"].Sum(a => a.Amount) && item.Value + bag["Gold"].Sum(e => e.Amount) <= maxAmount)
                {
                    var gold = new Bag(item.Key);
                    gold.Amount += item.Value;
                    bag["Gold"].Add(gold);
                }
            }

            foreach (var type in bag.OrderByDescending(a => a.Value.Sum(e => e.Amount)))
            {
                if (type.Value.Sum(e => e.Amount) > 0)
                {
                    Console.WriteLine($"<{type.Key}> ${type.Value.Sum(a => a.Amount)}");
                    foreach (var value in type.Value.OrderByDescending(a => a.Name).ThenBy(e => e.Amount))
                    {
                        TextInfo name = new CultureInfo("en-US", false).TextInfo;
                        if (type.Key == "Cash")
                        {
                            Console.WriteLine($"##{value.Name.ToUpper()} - {value.Amount}");
                        }
                        else
                        {
                            Console.WriteLine($"##{name.ToTitleCase(value.Name)} - {value.Amount}");
                        }
                        
                    }
                }
            }
        }
    }
}
