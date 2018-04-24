using System;
using System.Collections.Generic;
using System.Linq;

namespace BorderControl
{
    public class Program
    {
        public static void Main()
        {
            var inhabitants = new List<IBirthable>();

            while (true)
            {
                var input = Console.ReadLine().Trim().Split();

                if (input[0].Equals("End", StringComparison.OrdinalIgnoreCase))
                {
                    break;
                }


                if (input[0].Equals("Citizen", StringComparison.OrdinalIgnoreCase))
                {
                    inhabitants.Add(new Citizen(input[1], int.Parse(input[2]), input[3], input[4]));
                }
                    
                else if (input[0].Equals("Pet", StringComparison.OrdinalIgnoreCase))
                {
                    inhabitants.Add(new Pet(input[1], input[2]));
                }
                    
            }

            var targetYear = Console.ReadLine().Trim();

            inhabitants
                .FindAll(x => x.Birthday.EndsWith(targetYear))
                .ForEach(inhabitant => Console.WriteLine(inhabitant.Birthday));

        }
    }
}
