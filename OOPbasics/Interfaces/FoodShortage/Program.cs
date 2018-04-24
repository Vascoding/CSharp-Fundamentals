using System;
using System.Collections.Generic;
using System.Linq;

namespace FoodShortage
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<IBuyer> buyers = new List<IBuyer>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split();
                if (input.Length == 4)
                {
                    buyers.Add(new Citizen(input[0], int.Parse(input[1]), input[2], input[3]));
                }
                else
                {
                    buyers.Add(new Rebel(input[0], int.Parse(input[1]), input[2]));
                }
            }
            string command;
            while ((command = Console.ReadLine()) != "End")
            {
                var buyer = buyers.FirstOrDefault(b => b.Name == command);
                if (buyer != null)
                {
                    buyer.BuyFood();
                }
            }
            Console.WriteLine($"{buyers.Sum(f => f.Food)}");
        }
    }
}
