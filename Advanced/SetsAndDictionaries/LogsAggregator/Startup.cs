using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogsAggregator
{
    class Log
    {
        public Log()
        {
            this.Ip = new SortedSet<string>();
        }
        public int Duration { get; set; }

        public SortedSet<string> Ip { get; set; }
    }
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            
            Dictionary<string, Log> dict = new Dictionary<string, Log>();

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (dict.ContainsKey(input[1]))
                {
                    dict[input[1]].Duration += int.Parse(input[2]);
                    dict[input[1]].Ip.Add(input[0]);
                }
                else
                {
                    dict.Add(input[1], new Log
                    {
                        Duration = int.Parse(input[2]),
                    });
                    dict[input[1]].Ip.Add(input[0]);
                }
            }

            foreach (var d in dict.OrderBy(a => a.Key))
            {
                Console.WriteLine($"{d.Key}: {d.Value.Duration} [{string.Join(", ", d.Value.Ip)}]");
            }
        }
    }
}
