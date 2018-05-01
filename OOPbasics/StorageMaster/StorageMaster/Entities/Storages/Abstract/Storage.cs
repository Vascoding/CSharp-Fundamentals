using StorageMaster.Entities.Products.Abstract;
using StorageMaster.Entities.Vehicles.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StorageMaster.Entities.Storages.Abstract
{
    public abstract class Storage
    {
        private string name;
        private int capacity;
        private int garageSlots;
        private List<Vehicle> garage;
        private List<Product> products;

        protected Storage(string name, int capacity, int garageSlots, IEnumerable<Vehicle> vehicles)
        {
            this.name = name;
            this.capacity = capacity;
            this.garageSlots = garageSlots;
            this.garage = new List<Vehicle>(garageSlots);
            this.products = new List<Product>();
            this.InitializeGarage(vehicles);
        }

        public string Name => this.name;

        public int Capacity => this.capacity;

        public int GarageSlots => this.garageSlots;

        public bool IsFull => this.Products.Sum(p => p.Weight) >= this.Capacity;

        public IReadOnlyCollection<Vehicle> Garage => this.garage;

        public IReadOnlyCollection<Product> Products => this.products;

        public Vehicle GetVehicle(int garageSlot)
        {
            if (garageSlot >= this.GarageSlots)
            {
                throw new InvalidOperationException("Invalid garage slot!");
            }

            Vehicle vehicle = this.garage[garageSlot];

            if (vehicle == null)
            {
                throw new InvalidOperationException("No vehicle in this garage slot!");
            }

            return vehicle;
        }

        public int SendVehicleTo(int garageSlot, Storage deliveryLocation)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);

            if (!deliveryLocation.garage.Any(v => v == null))
            {
                throw new InvalidOperationException("No room in garage!");
            }

            this.garage[garageSlot] = null;
            var count = deliveryLocation.AddVehicle(vehicle);
            if (count == 0)
            {
                throw new InvalidOperationException("No room in garage!");
            }
            return count;
        }

        public int UnloadVehicle(int garageSlot)
        {
            Vehicle vehicle = this.GetVehicle(garageSlot);
            if (this.IsFull)
            {
                throw new InvalidOperationException("Storage is full!");
            }
            int unloadedProducts = 0;

            while (true)
            {
                if (this.IsFull)
                {
                    break;
                }
                if (vehicle.IsEmpty)
                {
                    break;
                }
                Product product = vehicle.Unload();
                this.products.Add(product);
                unloadedProducts++;
            }

            return unloadedProducts;
        }

        private void InitializeGarage(IEnumerable<Vehicle> vehicles)
        {
            foreach (var vehicle in vehicles)
            {
                this.garage.Add(vehicle);
            }
            for (int i = 0; i < this.GarageSlots - vehicles.Count(); i++)
            {
                this.garage.Add(null);
            }
        }

        private int AddVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < this.garage.Count; i++)
            {
                if (this.garage[i] == null)
                {
                    this.garage[i] = vehicle;
                    return i;
                }
            }
            return 0;
        }

        public string GetVehicleForPrint(int garageSlot)
        {
            Vehicle vehicle = this.garage[garageSlot];
            if (vehicle == null)
            {
                return "empty";
            }
            return vehicle.GetType().Name;
        }

        public override string ToString()
        {
            StringBuilder storageStats = new StringBuilder();
            storageStats.AppendLine($"{this.Name}:");
            storageStats.AppendLine($"Storage worth: ${this.Products.Sum(p => p.Price):F2}");
            return storageStats.ToString().Trim();
        }
    }
}
