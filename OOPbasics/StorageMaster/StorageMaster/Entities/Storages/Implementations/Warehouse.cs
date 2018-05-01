using System.Collections.Generic;
using StorageMaster.Entities.Storages.Abstract;
using StorageMaster.Entities.Vehicles.Abstract;
using StorageMaster.Entities.Vehicles.Implementations;

namespace StorageMaster.Entities.Storages.Implementations
{
    public class Warehouse : Storage
    {
        private const int InitialCapacity = 10;
        private const int InitialGarageSlots = 10;

        public Warehouse(string name) 
            : base(name, InitialCapacity, InitialGarageSlots, InitVehicles)
        {
        }

        private static List<Vehicle> InitVehicles => new List<Vehicle>()
        {
               new Semi(),
               new Semi(),
               new Semi(),
        };
       
    }
}
