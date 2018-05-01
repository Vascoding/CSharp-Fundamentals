using StorageMaster.Entities.Vehicles.Abstract;
using StorageMaster.Entities.Vehicles.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    public class VehicleFactory
    {
        public static Vehicle CreateVehicle(string type)
        {
            Vehicle vehicle = null;

            if (type == "Semi")
            {
                vehicle = new Semi();
            }
            else if (type == "Truck")
            {
                vehicle = new Truck();
            }
            else if (type == "Van")
            {
                vehicle = new Van();
            }
            else
            {
                throw new InvalidOperationException("Invalid vehicle type!");
            }

            return vehicle;
        }
    }
}
