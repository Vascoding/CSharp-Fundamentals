using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.ChangeList
{
    class ChangeList
    {
        static void Main(string[] args)
        {
            List<long> numbers = Console.ReadLine().Split(' ').Select(long.Parse).ToList();
            List<long> result = new List<long>();
            while (true)
            {
                List<string> commands = Console.ReadLine().Split(' ').ToList();
                string commandInput = commands[0];

                switch (commandInput)
                {
                    case "Delete":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            long deleteValue = long.Parse(commands[1]);
                            if (deleteValue == numbers[i])
                            {
                                numbers.Remove(numbers[i]);
                            }
                        }
                        break;
                    case "Insert":
                        long insertValue = long.Parse(commands[1]);
                        int index = int.Parse(commands[2]);
                        numbers.Insert(index, insertValue);
                        break;
                    case "Odd":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (Math.Abs(numbers[i]) % 2 == 1)
                            {
                                result.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", result));
                        break;
                    case "Even":
                        for (int i = 0; i < numbers.Count; i++)
                        {
                            if (Math.Abs(numbers[i]) % 2 == 0)
                            {
                                result.Add(numbers[i]);
                            }
                        }
                        Console.WriteLine(string.Join(" ", result));
                        break;
                }
                if (commandInput == "Odd" || commandInput == "Even")
                {
                    break;
                }
            }
        }
    }
}