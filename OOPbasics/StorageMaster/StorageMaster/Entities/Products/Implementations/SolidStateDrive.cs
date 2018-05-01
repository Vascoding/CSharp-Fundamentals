using StorageMaster.Entities.Products.Abstract;

namespace StorageMaster.Entities.Products.Implementations
{
    public class SolidStateDrive : Product
    {
        private const double InitialWeight = 0.2;

        public SolidStateDrive(double price) 
            : base(price, InitialWeight)
        {
        }
    }
}
