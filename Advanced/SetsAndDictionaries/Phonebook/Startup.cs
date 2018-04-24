using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phonebook
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {'-'}, StringSplitOptions.RemoveEmptyEntries).ToArray();
            Dictionary<string, string> phonebook = new Dictionary<string, string>();
            while (!input[0].Equals("search"))
            {
                if (input.Length == 2)
                {
                    if (phonebook.ContainsKey(input[0]))
                    {
                        phonebook[input[0]] = input[1];
                    }
                    else
                    {
                        phonebook.Add(input[0], input[1]);
                    }
                }
                input = Console.ReadLine().Split(new[] { '-' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            }
            var name = Console.ReadLine();
            while (!name.Equals("stop"))
            {
                var exists = false;
                foreach (var phone in phonebook)
                {
                    if (phone.Key == name)
                    {
                        Console.WriteLine($"{phone.Key} -> {phone.Value}");
                        exists = true;
                    }
                }
                if (!exists)
                {
                    Console.WriteLine($"Contact {name} does not exist.");
                }
                name = Console.ReadLine();
            }
        }
    }
}
