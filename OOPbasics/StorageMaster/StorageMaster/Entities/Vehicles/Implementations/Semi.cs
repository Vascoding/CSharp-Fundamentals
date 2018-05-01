using StorageMaster.Entities.Vehicles.Abstract;

namespace StorageMaster.Entities.Vehicles.Implementations
{
    public class Semi : Vehicle
    {
        private const int InitialCapacity = 10;
        public Semi() 
            : base(InitialCapacity)
        {
        }
    }
}
