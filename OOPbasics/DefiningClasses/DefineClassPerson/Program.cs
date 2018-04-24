using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DefineClassPerson
{
    class Program
    {
        static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            HashSet<Car> cars = new HashSet<Car>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var model = input[0];
                var fuelAmount = double.Parse(input[1]);
                var fuelConsumtion = double.Parse(input[2]);

                Car car = new Car
                {
                    Model = model,
                    FuelAmount = fuelAmount,
                    FuelConsumtion = fuelConsumtion
                };
                cars.Add(car);
                
            }
            
            while (true)
            {
                var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
                if (input[0].Equals("End"))
                {
                    break;
                }
                var model = input[1];
                var amountOfkm = double.Parse(input[2]);
                Car car = cars.FirstOrDefault(a => a.Model == model);
                car.Drive(car, amountOfkm);
            }
            
            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:f2} {car.DistanceTraveled}");
            }
        }
    }
}
