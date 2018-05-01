using StorageMaster.Entities.Products.Abstract;

namespace StorageMaster.Entities.Products.Implementations
{
    public class Gpu : Product
    {
        private const double InitialWeight = 0.7;
        public Gpu(double price) 
            : base(price, InitialWeight)
        {
        }
    }
}
