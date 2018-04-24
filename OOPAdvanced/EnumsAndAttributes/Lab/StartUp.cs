//[SoftUni("Ventsi")]
//public class StartUp
//{
//    [SoftUni("Gosho")]
//    public static void Main()
//    {
//        var tracker = new Tracker();
//        tracker.PrintMethodsByAuthor();
//    }
//}
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace AppendLists
{

    public class Program
    {
        static void Main(string[] args)
        {

            var input = Console.ReadLine();
            var result = new Dictionary<string, Evolutions>();

            while (input != "wubbalubbadubdub")
            {
                var tokens = input.Split(" ->".ToCharArray(), StringSplitOptions.RemoveEmptyEntries);
                var pokeName = tokens[0];
                if (tokens.Length > 1)
                {

                    var pokeEvo = tokens[1];
                    var pokeIndex = int.Parse(tokens[2]);

                    var evoAndIndex = new Evolutions();
                    evoAndIndex.EvoName = new List<string>();
                    evoAndIndex.EvoIndex = new List<int>();
                    evoAndIndex.EvoName.Add(pokeEvo);
                    evoAndIndex.EvoIndex.Add(pokeIndex);

                    if (!result.ContainsKey(pokeName))
                    {
                        result[pokeName] = evoAndIndex;
                    }
                    else
                    {
                        result[pokeName].EvoIndex.Add(pokeIndex);
                        result[pokeName].EvoName.Add(pokeEvo);
                    }
                }
                else
                {

                    Console.WriteLine($"# {pokeName}");
                    for (int i = 0; i < result[pokeName].EvoIndex.Count; i++)
                    {
                        Console.WriteLine($"{result[pokeName].EvoName[i]} <-> {result[pokeName].EvoIndex[i]}");
                    }
                }


                input = Console.ReadLine();
            }

            foreach (var name in result.OrderByDescending(a => a.Value.EvoIndex))
            {
                Console.WriteLine($"# {name.Key}");
                for (int i = 0; i < name.Value.EvoName.Count; i++)
                {
                    Console.WriteLine($"{name.Value.EvoName[i]} <-> {name.Value.EvoIndex[i]}");
                }

            }

        }

        class Evolutions
        {
            public List<string> EvoName { get; set; }
            public List<int> EvoIndex { get; set; }

        }
    }
}