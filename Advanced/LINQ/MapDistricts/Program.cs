using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MapDistricts
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            var bound = long.Parse(Console.ReadLine());
            Dictionary<string, List<long>> dict = new Dictionary<string, List<long>>();
            foreach (var i in input)
            {
                var splited = i.Split(':');
                var city = splited[0];
                var population = long.Parse(splited[1]);
                if (!dict.ContainsKey(city))
                {
                    dict.Add(city, new List<long>());
                }
                dict[city].Add(population);
            }
            foreach (var d in dict.Where(v => v.Value.Sum() > bound).OrderByDescending(b => b.Value.Sum()))
            {
                Console.WriteLine($"{d.Key}: {string.Join(" ", d.Value.OrderByDescending(v => v).Take(5))}");
            }
        }
    }
}
