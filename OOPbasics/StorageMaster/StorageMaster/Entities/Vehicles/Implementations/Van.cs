using StorageMaster.Entities.Vehicles.Abstract;

namespace StorageMaster.Entities.Vehicles.Implementations
{
    public class Van : Vehicle
    {
        private const int InitialCapacity = 2;
        public Van() 
            : base(InitialCapacity)
        {
        }
    }
}
