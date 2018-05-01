using System.Collections.Generic;
using StorageMaster.Entities.Storages.Abstract;
using StorageMaster.Entities.Vehicles.Implementations;
using StorageMaster.Entities.Vehicles.Abstract;

namespace StorageMaster.Entities.Storages.Implementations
{
    public class AutomatedWarehouse : Storage
    {
        private const int InitialCapacity = 1;
        private const int InitialGarageSlots = 2;

        public AutomatedWarehouse(string name) 
            : base(name, InitialCapacity, InitialGarageSlots, InitVehicles)
        {
        }

        private static List<Vehicle> InitVehicles => new List<Vehicle>()
        {
            new Truck()
        };
    }
}
