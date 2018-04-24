using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InfernoIII
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers =
                Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            while (true)
            {
                var commands = Console.ReadLine();
                if (commands.Equals("Forge"))
                {
                    break;
                }
                if (commands.Contains("Exclude"))
                {
                    var splited = commands.Split(new []{';'}, StringSplitOptions.RemoveEmptyEntries);
                    var condition = splited[1];
                    var value = int.Parse(splited[2]);
                    if (condition.Equals("Sum Left"))
                    {
                        
                    }
                }

                if (commands.Contains("Reverse"))
                {
                    
                }
            }
        }
    }
}

