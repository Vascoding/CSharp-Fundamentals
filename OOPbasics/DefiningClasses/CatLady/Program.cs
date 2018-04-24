using System;
using System.Collections.Generic;
using System.Linq;

namespace CatLady
{
    public class Program
    {
        public static void Main()
        {
            List<Cat> cats = new List<Cat>();
            while (true)
            {
                var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("End"))
                {
                    break;
                }
                var breed = input[0];
                var catName = input[1];
                var characteristics = double.Parse(input[2]);

                var cat = cats.FirstOrDefault(a => a.Name == catName);
                
                if (cat == null)
                {
                    Cat c = new Cat
                    {
                        Name = catName
                    };
                    if (breed == "Siamese")
                    {
                        c.BreedName = breed;
                        c.EarSize = characteristics;
                    }
                    if (breed == "Cymric")
                    {
                        c.BreedName = breed;
                        c.FurLength = characteristics;
                    }
                    if (breed == "StreetExtraordinaire")
                    {
                        c.BreedName = breed;
                        c.MeawingDecibels = characteristics;
                    }
                    cats.Add(c);
                }
            }
            var catN = Console.ReadLine();
            var catInfo = cats.FirstOrDefault(n => n.Name == catN);
            if (catInfo != null)
            {
                Console.WriteLine(catInfo.ToString());
            }
        }
    }
}
