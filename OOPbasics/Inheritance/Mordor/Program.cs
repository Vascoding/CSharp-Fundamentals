using System;

namespace Mordor
{
    public class Program
    {
        public static void Main()
        {
            var input = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            int allPoints = 0;
            for (int i = 0; i < input.Length; i++)
            {
                allPoints += FoodFactory.GetPoints(input[i].ToLower());
            }
            
            Console.WriteLine(allPoints);
            Console.WriteLine(MoodFactory.GetMood(allPoints));
        }
    }
}
