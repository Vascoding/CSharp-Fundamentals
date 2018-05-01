using StorageMaster.Entities.Products.Abstract;

namespace StorageMaster.Entities.Products.Implementations
{
    public class HardDrive : Product
    {
        private const double InitialWeight = 1;

        public HardDrive(double price) 
          : base(price, InitialWeight)
        {
        }
    }
}
