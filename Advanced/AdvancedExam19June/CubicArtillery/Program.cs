//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace CubicArtillery
//{
//    class Program
//    {
//        static void Main(string[] args)
//        {
//            var n = int.Parse(Console.ReadLine());
//            var capacity = n;
//            while (true)
//            {
//                var input = Console.ReadLine();
//                if (input.Equals("Bunker Revision"))
//                {
//                    break;
//                }
//                var splited = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
//                Queue<char> bunker = new Queue<char>();
//                Queue<int> weapons = new Queue<int>();
//                for (int i = 0; i < splited.Length; i++)
//                {
//                    int weapon;
//                    int.TryParse(splited[i], out weapon);
//                    if (weapon > 0)
//                    {
//                        weapons.Enqueue(weapon);
//                    }
//                    else
//                    {
//                        bunker.Enqueue(input[i]);
//                    }
//                }

//                if (bunker.Count == 1)
//                {
//                    while (true)
//                    {
//                        if (capacity < weapons.Sum())
//                        {
//                            weapons.Dequeue();
//                        }
//                        if (capacity >= weapons.Sum())
//                        {
//                            if (weapons.Count == 0)
//                            {
//                                Console.WriteLine($"{bunker.Dequeue()} -> Empty");
//                            }
//                            else
//                            {
//                                Console.WriteLine($"{bunker.Dequeue()} -> {string.Join(", ", weapons)}");
//                            }

//                            break;
//                        }
//                    }
//                }
//                else
//                {
//                    capacity = n;
//                    List<int> stored = new List<int>();
//                    while (true)
//                    {
//                        if (bunker.Count == 0 || weapons.Count == 0)
//                        {
//                            break;
//                        }
//                        if (capacity >= weapons.Peek())
//                        {
//                            capacity -= weapons.Peek();
//                            stored.Add(weapons.Dequeue());
//                        }
//                        else
//                        {
//                            Console.WriteLine($"{bunker.Dequeue()} -> {string.Join(", ", stored)}");
//                            break;
//                        }
//                    }
//                }
//            }
//        }
//    }
//}



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AndreyAndbilliard
{
    class Program
    {
        static void Main(string[] args)
        {

            int productsCount = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> shopProducts = new Dictionary<string, decimal>();

            //adding products to shop
            for (int i = 0; i < productsCount; i++)
            {
                string[] tokens = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
                string name = tokens[0];
                decimal price = decimal.Parse(tokens[1]);

                if (shopProducts.ContainsKey(name))
                {
                    shopProducts[name] = price;
                }
                else
                {
                    shopProducts.Add(name, price);
                }

            }

            Dictionary<string, Customer> dict = new Dictionary<string, Customer>();
            while (true)
            {
                string[] tokens = Console.ReadLine().Split(new[] { ',', '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();

                string name = tokens[0];
                if (name == "end of clients")
                {
                    break;
                }
                string product = tokens[1];
                if (shopProducts.ContainsKey(product))
                {
                    long quantity = long.Parse(tokens[2]);
                    decimal price = shopProducts[product];
                    if (dict.ContainsKey(name))
                    {
                        dict[name].Bill += quantity * price;
                        if (dict[name].ItemsInfo.ContainsKey(product))
                        {
                            dict[name].ItemsInfo[product] += quantity;
                        }
                        else
                        {
                            dict[name].ItemsInfo.Add(product, quantity);
                        }
                    }
                    else
                    {
                        dict.Add(name, new Customer());
                        dict[name].ItemsInfo = new Dictionary<string, long>();
                        dict[name].ItemsInfo.Add(product, quantity);
                        dict[name].Bill = price * quantity;
                    }
                }
            }

            foreach (var customer in dict.OrderBy(k => k.Key))
            {
                Console.WriteLine(customer.Key);
                foreach (var v in customer.Value.ItemsInfo)
                {
                    Console.WriteLine($"-- {v.Key} - {v.Value}");
                }

                Console.WriteLine($"Bill: {customer.Value.Bill:F2}");
            }
            Console.WriteLine("Total bill: {0:f2}", dict.Sum(v => v.Value.Bill));
        }
    }

    public class Customer
    {
        public Dictionary<string, long> ItemsInfo { get; set; }
        public decimal Bill { get; set; }
    }
}