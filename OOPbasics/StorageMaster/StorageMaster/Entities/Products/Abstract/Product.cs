using System;

namespace StorageMaster.Entities.Products.Abstract
{
    public abstract class Product
    {
        private double price;
        private double weight;

        protected Product(double price, double weight)
        {
            this.Price = price;
            this.Weight = weight;
        }

        public double Price
        {
            get { return this.price; }
            protected set
            {
                if (value < 0)
                {
                    throw new InvalidOperationException("Price cannot be negative!");
                }
                this.price = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            protected set { this.weight = value; }
        }
    }
}
