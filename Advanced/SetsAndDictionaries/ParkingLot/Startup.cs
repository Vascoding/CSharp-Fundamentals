using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ParkingLot
{
    class Startup
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(new[] {' ', ','}, StringSplitOptions.RemoveEmptyEntries);
            SortedSet<string> cars = new SortedSet<string>();

            while (!input[0].Equals("END"))
            {
                if (input[0].Equals("IN"))
                {
                    cars.Add(input[1]);
                }
                if (input[0].Equals("OUT"))
                {
                    cars.Remove(input[1]);
                }

                input = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            }
            
            if (cars.Count > 0)
            {
                Console.WriteLine(string.Join("\n", cars));
            }
            else
            {
                Console.WriteLine("Parking Lot is Empty");
            }
        }
    }
}
