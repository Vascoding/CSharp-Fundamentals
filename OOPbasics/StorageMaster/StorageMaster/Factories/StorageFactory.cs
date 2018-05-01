using StorageMaster.Entities.Storages.Abstract;
using StorageMaster.Entities.Storages.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageMaster.Factories
{
    public class StorageFactory
    {
        public static Storage CreateStorage(string type, string name)
        {
            Storage storage = null;
            if (type == "AutomatedWarehouse")
            {
                storage = new AutomatedWarehouse(name);
            }
            else if (type == "DistributionCenter")
            {
                storage = new DistributionCenter(name);
            }
            else if (type == "Warehouse")
            {
                storage = new Warehouse(name);
            }
        
            else
            {
                throw new InvalidOperationException("Invalid storage type!");
            }

            return storage;
        }
    }
}
