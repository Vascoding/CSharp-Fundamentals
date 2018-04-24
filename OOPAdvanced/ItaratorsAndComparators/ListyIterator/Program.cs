using System;
using System.Linq;

namespace ListyIterator
{
    public class Program
    {
        public static void Main()
        {
            ListyIterator<string> listy = new ListyIterator<string>();
            string input;
            while ((input = Console.ReadLine()) != "END")
            {
                var cmdArgs = input.Split();
                
                switch (cmdArgs[0])
                {

                    case "Create":
                        if (cmdArgs.Length > 1)
                        {
                            listy.Create(cmdArgs.Skip(1).ToArray());
                        }
                        break;
                    case "Move":
                        Console.WriteLine(listy.MoveNext());
                        break;
                    case "Print":
                        try
                        {
                            Console.WriteLine(listy.Print());
                            
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        break;
                    case "PrintAll":
                        Console.WriteLine(string.Join(" ", listy));
                        break;
                    case "HasNext":
                        Console.WriteLine(listy.HasNext());
                        break;
                    case "END":
                        return;
                }
            }
        }
    }
}
