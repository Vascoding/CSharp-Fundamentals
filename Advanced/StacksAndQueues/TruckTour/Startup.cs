using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TruckTour
{
    class Startup
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            Queue<int> tank = new Queue<int>();
            Dictionary<int, Dictionary<int, int>> dict = new Dictionary<int, Dictionary<int, int>>();

            for (int i = 0; i < n; i++)
            {
                var info = Console.ReadLine().Split().Select(int.Parse).ToArray();
                var petrol = info[0];
                var distance = info[1];
                dict.Add(i, new Dictionary<int, int>());
                dict[i].Add(petrol, distance);
            }

            int result = 0;
            int count = 0;
            for (int i = 0; i < dict.Count; i++)
            {
                foreach (var v in dict[i])
                {
                    var petrol = v.Key;
                    var distance = v.Value;
                    result += petrol - distance;
                    tank.Enqueue(i);
                    if (result < 0)
                    {
                        result = 0;
                        tank.Clear();
                        break;
                    }
                    count++;
                    if (count == n)
                    {
                        Console.WriteLine(tank.Peek());
                        return;
                    }
                }
                if (i + 1 == dict.Count)
                {
                    i = -1;
                }
            }
        }
    }
}
