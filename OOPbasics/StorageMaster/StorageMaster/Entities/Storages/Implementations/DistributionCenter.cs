using System.Collections.Generic;
using StorageMaster.Entities.Storages.Abstract;
using StorageMaster.Entities.Vehicles.Abstract;
using StorageMaster.Entities.Vehicles.Implementations;

namespace StorageMaster.Entities.Storages.Implementations
{
    public class DistributionCenter : Storage
    {
        private const int InitialCapacity = 2;
        private const int InitialGarageSlots = 5;

        public DistributionCenter(string name)
            : base(name, InitialCapacity, InitialGarageSlots, InitVehicles)
        {
        }

        private static List<Vehicle> InitVehicles => new List<Vehicle>()
        {
             new Van(),
             new Van(),
             new Van(),
        };

    }
}
