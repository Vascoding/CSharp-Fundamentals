using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomList
{
    public class Program
    {
        public static void Main()
        {
            var customList = new CustomList<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var command = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                
                switch (command[0].ToLower())
                {
                    case "add":
                        var e = command[1];
                        customList.Add(e);
                        break;
                    case "remove":
                        customList.Remove(int.Parse(command.Last()));
                        break;
                    case "contains":
                        Console.WriteLine(customList.Contains(command[1]));
                        break;
                    case "swap":
                        customList.Swap(int.Parse(command[1]), int.Parse(command[2]));
                        break;
                    case "greater":
                        Console.WriteLine(customList.CountGreaterThan(command[1]));
                        break;
                    case "max":
                        Console.WriteLine(customList.Max());
                        break;
                    case "min":
                        Console.WriteLine(customList.Min());
                        break;
                    case "sort":
                         customList.Elements = Sorter<string>.Sort(customList.Elements);
                        break;
                    case "print":
                        Console.WriteLine(customList);
                        break;
                }
            }
        }
    }
}
