using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ExtractHyperlinks
{
    class Program
    {
        static void Main()
        {
            var input = Console.ReadLine();

            while (!input.Equals("END"))
            {
                var splited = input.Split(new[] {'?', '&'}, StringSplitOptions.RemoveEmptyEntries);
                Dictionary<string, List<string>> dict = new Dictionary<string, List<string>>();
                foreach (var s in splited)
                {
                    var split = s.Split('=');
                    if (split.Length > 1)
                    {
                        var key = split[0].Replace("%20", " ").Replace("+", " ").Trim();
                        var value = split[1].Replace("%20", " ").Replace("+", " ").Trim();
                        Regex regex = new Regex(@"[ ]{2,}");
                        value = regex.Replace(value, @" ");

                        if (dict.ContainsKey(key))
                        {
                            dict[key].Add(value);
                        }
                        else
                        {
                            dict.Add(key, new List<string>());
                            dict[key].Add(value);
                        }
                    }
                }

                foreach (var d in dict)
                {
                    Console.Write($"{d.Key}=[{string.Join(", ", d.Value)}]");
                }
                Console.WriteLine();
                input = Console.ReadLine();
            }
        }
    }
}
