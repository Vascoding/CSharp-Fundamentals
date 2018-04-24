using System;
using System.Linq;

namespace Froggy
{
    public class Program
    {
        public static void Main()
        {
            var stonesInLake = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            Lake<int> lake = new Lake<int>(stonesInLake);
            Console.WriteLine(string.Join(", ", lake));
        }
    }
}
