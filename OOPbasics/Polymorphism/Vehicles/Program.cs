using System;

namespace Vehicles
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var inputCar = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var inputTruck = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            var inputBus = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(inputCar[1]), double.Parse(inputCar[2]), double.Parse(inputCar[3]));
            Vehicle truck = new Truck(double.Parse(inputTruck[1]), double.Parse(inputTruck[2]), double.Parse(inputTruck[3]));
            Vehicle bus = new Bus(double.Parse(inputBus[1]), double.Parse(inputBus[2]), double.Parse(inputBus[3]));
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var commandInput = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var command = commandInput[0];
                    var vehicle = commandInput[1];
                    var param = double.Parse(commandInput[2]);
                    if (vehicle.Equals("Car"))
                    {
                        ExecuteCommand(car, command, param);
                    }
                    else if (vehicle.Equals("Truck"))
                    {
                        ExecuteCommand(truck, command, param);
                    }
                    else if (vehicle.Equals("Bus"))
                    {
                        ExecuteCommand(bus, command, param);
                    }
                }
                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }

            }
            Console.WriteLine(car);
            Console.WriteLine(truck);
            Console.WriteLine(bus);
        }

        private static void ExecuteCommand(Vehicle vehicle, string command, double d)
        {
            switch (command)
            {
                case "Drive":
                    Console.WriteLine(vehicle.TryTravel(d));
                    break;
                case "Refuel":
                    vehicle.Refuel(d);
                    break;
                case "DriveEmpty":
                    Console.WriteLine(vehicle.TryTravel(d, false));
                    break;
            }
        }
    }
}
