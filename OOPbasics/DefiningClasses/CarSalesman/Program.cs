using System;
using System.Collections.Generic;
using System.Linq;

namespace CarSalesman
{
    public class Program
    {
        public static void Main()
        {
            var n = int.Parse(Console.ReadLine());
            List<Car> cars = new List<Car>();
            List<Engine> engines = new List<Engine>();
            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var engineModel = input[0];
                var enginePower = int.Parse(input[1]);
                Engine engine = new Engine
                {
                    Model = engineModel,
                    Power = enginePower
                };
                if (input.Length == 3)
                {
                    int d;
                    if (int.TryParse(input[2], out d))
                    {
                        var displacement = input[2];
                        engine.Displacement = displacement;
                    }
                    else
                    {
                        var efficiency = input[2];
                        engine.Efficiency = efficiency;
                    }
                    
                }
                if (input.Length == 4)
                {
                    var displacement = input[2];
                    var efficiency = input[3];
                    engine.Displacement = displacement;
                    engine.Efficiency = efficiency;
                }
                engines.Add(engine);
            }

            n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var input = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var carModel = input[0];
                var engineModel = input[1];
                var engine = engines.FirstOrDefault(e => e.Model == engineModel);
                Car car = new Car
                {
                    Model = carModel,
                    Engine = engine
                };

                if (input.Length == 3)
                {
                    int w;
                    if (int.TryParse(input[2], out w))
                    {
                        var weight = input[2];
                        car.Weight = weight;
                    }
                    else
                    {
                        var color = input[2];
                        car.Color = color;
                    }
                }

                if (input.Length == 4)
                {
                    var weight = input[2];
                    var color = input[3];
                    car.Weight = weight;
                    car.Color = color;
                }
                cars.Add(car);
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model}:");
                Console.WriteLine($"  {car.Engine.Model}:");
                Console.WriteLine($"    Power: {car.Engine.Power}");
                Console.WriteLine($"    Displacement: {car.Engine.Displacement}");
                Console.WriteLine($"    Efficiency: {car.Engine.Efficiency}");
                Console.WriteLine($"  Weight: {car.Weight}");
                Console.WriteLine($"  Color: {car.Color}");
            }
        }
    }
}
