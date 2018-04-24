using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SrubskoUnleashed
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

            Dictionary<string, Dictionary<string, long>> dict = new Dictionary<string, Dictionary<string, long>>();

            while (!input[0].Equals("End"))
            {
                if (input.Length > 3)
                {
                    long tickets;
                    long ticketPrice;
                    try
                    {
                         tickets = long.Parse(input[input.Length - 1]);
                         ticketPrice = long.Parse(input[input.Length - 2]);
                    }
                    catch (Exception)
                    {
                        input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                        continue;
                    }
                    
                    var split = input.Take(input.Length - 2).ToArray();
                    var singer = string.Empty;
                    var city = string.Empty;
                    long total = ticketPrice * tickets;
                    bool isValid = true;
                    for (int i = 0; i < split.Length; i++)
                    {
                        if (split[i].StartsWith("@"))
                        {
                            for (int j = i; j < split.Length; j++)
                            {
                                city += split[j] + " ";
                            }
                            break;
                        }
                        if (split[i].Contains("@"))
                        {
                            isValid = false;
                            break;
                        }
                        singer += split[i] + " ";
                    }
                    if (isValid)
                    {
                        singer = singer.Trim();
                        var m = city.Split('@').ToArray();
                        var cityEvent = m[1];
                        cityEvent = cityEvent.Trim();
                        if (singer.Split().Length > 0 && singer.Split().Length < 4 && cityEvent.Split().Length > 0 && cityEvent.Split().Length < 4)
                        {
                            if (dict.ContainsKey(cityEvent))
                            {
                                if (dict[cityEvent].ContainsKey(singer))
                                {
                                    dict[cityEvent][singer] += total;
                                }
                                else
                                {
                                    dict[cityEvent].Add(singer, total);
                                }
                            }
                            else
                            {
                                dict.Add(cityEvent, new Dictionary<string, long>());
                                dict[cityEvent].Add(singer, total);
                            }
                        }
                    }
                }
                input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }

            foreach (var d in dict)
            {
                Console.WriteLine($"{d.Key}");
                foreach (var v in d.Value.OrderByDescending(v => v.Value))
                {
                    Console.WriteLine($"#  {v.Key} -> {v.Value}");
                }
            }
        }
    }
}
