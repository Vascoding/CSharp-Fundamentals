//using System;
//using System.Collections.Generic;
//using System.Linq;

//namespace RowData
//{
//    public class Program
//    {
//        public static void Main()
//        {
//            var n = int.Parse(Console.ReadLine());
//            List<Car> cars = new List<Car>();

//            for (int i = 0; i < n; i++)
//            {
//                var input = Console.ReadLine().Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
//                var model = input[0];
//                var engineSpeed = int.Parse(input[1]);
//                var enginePower = int.Parse(input[2]);
//                var cargoWeight = int.Parse(input[3]);
//                var cargoType = input[4];
//                var tP1 = double.Parse(input[5]);
//                var tA1 = int.Parse(input[6]);
//                var tP2 = double.Parse(input[7]);
//                var tA2 = int.Parse(input[8]);
//                var tP3 = double.Parse(input[9]);
//                var tA3 = int.Parse(input[10]);
//                var tP4 = double.Parse(input[11]);
//                var tA4 = int.Parse(input[12]);

//                Tire tireOne = new Tire
//                {
//                    Presure = tP1,
//                    Age = tA1
//                };
//                Tire tireTwo = new Tire
//                {
//                    Presure = tP2,
//                    Age = tA2
//                };
//                Tire tireThree = new Tire
//                {
//                    Presure = tP3,
//                    Age = tA3
//                };
//                Tire tireFour = new Tire
//                {
//                    Presure = tP4,
//                    Age = tA4
//                };

//                Cargo cargo = new Cargo
//                {
//                    Type = cargoType,
//                    Weight = cargoWeight
//                };

//                Engine engine = new Engine
//                {
//                    Power = enginePower,
//                    Speed = engineSpeed
//                };
//                List<Tire> tires = new List<Tire>();
//                tires.Add(tireOne);
//                tires.Add(tireTwo);
//                tires.Add(tireThree);
//                tires.Add(tireFour);
//                Car car = new Car(engine, cargo);
//                car.Tires = tires;
//                car.Model = model;
//                cars.Add(car);
//            }

//            var type = Console.ReadLine();
//            if (type.Equals("fragile"))
//            {
//                var result = cars.Where(c => c.Cargo.Type == "fragile" && c.Tires.Any(a => a.Presure < 1.0)).Select(car => car.Model);
//                foreach (var car in result)
//                {
//                    Console.WriteLine(car);
//                }
//            }

//            if (type.Equals("flamable"))
//            {
//                var result = cars.Where(c => c.Cargo.Type == "flamable" && c.Engine.Power > 250).Select(car => car.Model);
//                foreach (var car in result)
//                {
//                    Console.WriteLine(car);
//                }
//            }
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Batteries
{
    class Program
    {
        static void Main(string[] args)
        {
            double[] capacities = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            double[] usage = Console.ReadLine().Split(' ').Select(double.Parse).ToArray();
            List<double> result = new List<double>();
            int testHours = int.Parse(Console.ReadLine());

            for (int i = 0; i < usage.Length; i++)
            {
                if ((capacities[i] - (testHours * usage[i])) >= 0)
                {
                    result.Add(capacities[i] - (testHours * usage[i]));
                }
                else
                {
                    result.Add(Math.Ceiling((capacities[i]) / usage[i]));
                }
            }

            for (int i = 0; i < result.Count; i++)
            {
                if (result[i] > 100)
                {
                    Console.WriteLine("Battery {0}: {1:f2} mAh ({2:f2})%", i + 1, result[i],
                                                (result[i] / capacities[i]) * 100);
                }
                else
                {
                    Console.WriteLine("Battery {0}: dead (lasted {1} hours)", i + 1, result[i]);
                }

            }

        }
    }
}