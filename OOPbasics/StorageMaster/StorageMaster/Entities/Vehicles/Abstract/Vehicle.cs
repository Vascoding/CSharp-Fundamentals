using StorageMaster.Entities.Products.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StorageMaster.Entities.Vehicles.Abstract
{
    public abstract class Vehicle
    {
        private int capacity;
        private List<Product> trunk;

        protected Vehicle(int capacity)
        {
            this.Capacity = capacity;
            this.trunk = new List<Product>();
        }

        public int Capacity
        {
            get { return this.capacity; }
            protected set { this.capacity = value; }
        }

        public IReadOnlyCollection<Product> Trunk => this.trunk;

        public bool IsFull => this.Trunk.Sum(p => p.Weight) >= this.Capacity;

        public bool IsEmpty => this.Trunk.Count == 0;

        public void LoadProduct(Product product)
        {
            this.trunk.Add(product);
        }

        public Product Unload()
        {
            Product product = this.Trunk.LastOrDefault();

            this.trunk.Remove(product);

            return product;
        }
    }
}
