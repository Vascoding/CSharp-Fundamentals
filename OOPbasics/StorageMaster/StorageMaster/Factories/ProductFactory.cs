using StorageMaster.Entities.Products.Abstract;
using StorageMaster.Entities.Products.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    public class ProductFactory
    {
        public static Product CreateProduct(string type, double price)
        {
            Product product = null;
            if (type == "Gpu")
            {
                product = new Gpu(price);
            }
            else if (type == "HardDrive")
            {
                product = new HardDrive(price);
            }
            else if(type == "Ram")
            {
                product = new Ram(price);
            }
            else if(type == "SolidStateDrive")
            {
                product = new SolidStateDrive(price);
            }
            else
            {
                throw new InvalidOperationException("Invalid product type!");
            }

            return product;
        }
    }
}
