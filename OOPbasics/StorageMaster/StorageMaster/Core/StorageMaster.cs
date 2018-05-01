using StorageMaster.Entities.Products.Abstract;
using StorageMaster.Entities.Storages.Abstract;
using StorageMaster.Entities.Vehicles.Abstract;
using StorageMaster.Factories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Core
{
    public class StorageMaster
    {
        private List<Product> productsPool;
        private List<Storage> storageRegistry;
        private Vehicle currentVehicle;

        public StorageMaster()
        {
            this.productsPool = new List<Product>();
            this.storageRegistry = new List<Storage>();
        }

        public string AddProduct(string type, double price)
        {
            this.productsPool.Add(ProductFactory.CreateProduct(type, price));

            return $"Added {type} to pool";
        }

        public string RegisterStorage(string type, string name)
        {
            this.storageRegistry.Add(StorageFactory.CreateStorage(type, name));

            return $"Registered {name}";
        }

        public string SelectVehicle(string storageName, int garageSlot)
        {
            Storage storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);

            this.currentVehicle = storage.GetVehicle(garageSlot);

            return $"Selected {this.currentVehicle.GetType().Name}";
        }

        public string LoadVehicle(IEnumerable<string> productNames)
        {
            var products = this.currentVehicle.Trunk;
            var loadedProductsCount = 0;
            var productCount = productNames.Count();
            if (this.currentVehicle.IsFull)
            {
                throw new InvalidOperationException("Vehicle is full!");
            }
            foreach (var prodName in productNames)
            {
                if (!this.productsPool.Any(p => p.GetType().Name == prodName))
                {
                    throw new InvalidOperationException($"{prodName} is out of stock!");
                }
                if (this.currentVehicle.IsFull)
                {
                    break;
                }
                var product = this.productsPool.LastOrDefault(p => p.GetType().Name == prodName);
                this.currentVehicle.LoadProduct(product);
                this.productsPool.Remove(product);
                loadedProductsCount++;
                if (!this.productsPool.Any())
                {
                    break;
                }
            }
            
            return $"Loaded {loadedProductsCount}/{productCount} products into {this.currentVehicle.GetType().Name}";
        }

        public string SendVehicleTo(string sourceName, int sourceGarageSlot, string destinationName)
        {
            var sourceStorage = this.storageRegistry.FirstOrDefault(s => s.Name == sourceName);
            var destinationStorage = this.storageRegistry.FirstOrDefault(s => s.Name == destinationName);
            if (sourceStorage == null)
            {
                throw new InvalidOperationException("Invalid source storage!");
            }
            if (destinationStorage == null)
            {
                throw new InvalidOperationException("Invalid destination storage!");
            }

            var vehicle = sourceStorage.GetVehicle(sourceGarageSlot);

            var destinationGarageSlot =  sourceStorage.SendVehicleTo(sourceGarageSlot, destinationStorage);

            return $"Sent {vehicle.GetType().Name} to {destinationName} (slot {destinationGarageSlot})";
        }

        public string UnloadVehicle(string storageName, int garageSlot)
        {
            var storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
           
            var vehicle = storage.GetVehicle(garageSlot);
            var productsInVehicle = vehicle.Trunk.Count;
            var unloadedProductsCount = storage.UnloadVehicle(garageSlot);
            

            return $"Unloaded {unloadedProductsCount}/{productsInVehicle} products at {storageName}";
        }

        public string GetStorageStatus(string storageName)
        {
            StringBuilder storageStatus = new StringBuilder();

            var storage = this.storageRegistry.FirstOrDefault(s => s.Name == storageName);
            var products = storage.Products.GroupBy(a => a.GetType().Name)
                .Select(group => new
                {
                    Name = group.Key,
                    SumOfWeight = group.Sum(g => g.Weight),
                    Count = group.Count(),
                })
                .OrderByDescending(p => p.Count)
                .ThenBy(p => p.Name)
                .ToList();
            var prod = new List<string>();
            foreach (var item in products)
            {
                prod.Add($"{item.Name} ({item.Count})");
            }
            storageStatus.AppendLine($"Stock ({products.Sum(w => w.SumOfWeight)}/{storage.Capacity}): [{string.Join(", ", prod)}]");
           
            var vehicles = new List<string>();
            for (int i = 0; i < storage.GarageSlots; i++)
            {
                vehicles.Add(storage.GetVehicleForPrint(i));
            }

            storageStatus.AppendLine($"Garage: [{string.Join("|", vehicles)}]");
            

            return storageStatus.ToString().Trim();
        }
            
        public string GetSummary()
        {
            return string.Join($"{Environment.NewLine}", this.storageRegistry.OrderByDescending(s => s.Products.Sum(p => p.Price)));
        }

    }
}
