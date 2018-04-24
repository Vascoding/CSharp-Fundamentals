using System;
using System.Collections.Generic;
using System.Linq;

namespace ShoppingSpree
{
    public class Program
    {
        public static void Main()
        {
            var firstLine = Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            var secondLine = Console.ReadLine().Split(new[] {';'}, StringSplitOptions.RemoveEmptyEntries);
            List<Person> people = new List<Person>();
            List<Product> products = new List<Product>();
            for (int i = 0; i < firstLine.Length; i++)
            {
                string[] personParams = firstLine[i].Split('=');
                string name = personParams[0];
                decimal money = decimal.Parse(personParams[1]);

                try
                {
                    people.Add(new Person(name, money));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }

            for (int i = 0; i < secondLine.Length; i++)
            {
                string[] productParams = secondLine[i].Split('=');
                string name = productParams[0];
                decimal cost = decimal.Parse(productParams[1]);

                try
                {
                    products.Add(new Product(name, cost));
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    return;
                }
            }
            while (true)
            {
                var command = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                if (command[0].Equals("END"))
                {
                    break;
                }

                var name = command[0];
                var product = command[1];

                var p = people.FirstOrDefault(n => n.Name == name);
                var prod = products.FirstOrDefault(a => a.Name == product);
                if (p != null && prod != null)
                {
                    if (p.Money >= prod.Cost)
                    {
                        p.Products.Add(prod);
                        p.Money -= prod.Cost;
                        Console.WriteLine($"{p.Name} bought {prod.Name}");
                    }
                    else
                    {
                        Console.WriteLine($"{p.Name} can't afford {prod.Name}");
                    }
                }

            }

            foreach (var p in people)
            {
                Console.Write($"{p.Name} - ");

                if (p.Products.Count == 0)
                {
                    Console.WriteLine("Nothing bought");
                }
                else
                {
                    Console.WriteLine(string.Join(", ", p.Products.Select(n => n.Name)));
                }
            }
        }
    }
}
