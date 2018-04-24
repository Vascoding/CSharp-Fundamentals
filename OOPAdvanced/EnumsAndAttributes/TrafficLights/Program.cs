using System;
using System.Linq;

namespace TrafficLights
{
    public class Program
    {
        public static void Main()
        {
            var trafficLights = Console.ReadLine().Trim().Split()
                .Select(x => new TrafficLights(x))
                .ToList();

            var n = int.Parse(Console.ReadLine().Trim());

            for (int i = 0; i < n; i++)
            {
                trafficLights.ForEach(t => t.ToggleSignal());
                Console.WriteLine(string.Join(" ", trafficLights));
            }
        }
    }
}
