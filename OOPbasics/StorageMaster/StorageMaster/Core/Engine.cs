using System;
using System.Linq;

namespace StorageMaster.Core
{
    public class Engine
    {
        private StorageMaster storeMaster;

        public Engine()
        {
            this.storeMaster = new StorageMaster();
        }

        public void Run()
        {
            while (true)
            {
                try
                {
                    string[] input = Console.ReadLine().Split();

                    string command = input[0];
                   
                    switch (command)
                    {
                        case "AddProduct":
                            Console.WriteLine(this.storeMaster.AddProduct(input[1], double.Parse(input[2])));
                            break;
                        case "RegisterStorage":
                            Console.WriteLine(this.storeMaster.RegisterStorage(input[1], input[2]));
                            break;
                        case "SelectVehicle":
                            Console.WriteLine(this.storeMaster.SelectVehicle(input[1], int.Parse(input[2])));
                            break;
                        case "LoadVehicle":
                            Console.WriteLine(this.storeMaster.LoadVehicle(input.Skip(1)));
                            break;
                        case "SendVehicleTo":
                            Console.WriteLine(this.storeMaster.SendVehicleTo(input[1], int.Parse(input[2]), input[3]));
                            break;
                        case "UnloadVehicle":
                            Console.WriteLine(this.storeMaster.UnloadVehicle(input[1], int.Parse(input[2])));
                            break;
                        case "GetStorageStatus":
                            Console.WriteLine(this.storeMaster.GetStorageStatus(input[1]));
                            break;
                        case "END":
                            Console.WriteLine(this.storeMaster.GetSummary());
                            return;
                        default:
                            break;
                    }
                }
                catch (Exception ex)
                {
                    if (typeof(InvalidOperationException) == ex.GetType())
                    {
                        Console.WriteLine("Error: " + ex.Message);
                    }
                    else
                    {
                        Console.WriteLine(ex.Message);
                    }
                }
            }
        }
    }
}
