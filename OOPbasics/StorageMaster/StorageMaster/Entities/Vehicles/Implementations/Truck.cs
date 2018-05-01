using StorageMaster.Entities.Vehicles.Abstract;

namespace StorageMaster.Entities.Vehicles.Implementations
{
    public class Truck : Vehicle
    {
        private const int InitialCapacity = 5;
        public Truck() 
            : base(InitialCapacity)
        {
        }
    }
}
