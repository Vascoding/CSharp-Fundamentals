using System;
using System.Collections.Generic;

namespace PizzaCalories
{
    public class Pizza
    {
        private string name;
        private List<Topping> toppings;
        private Dough dough;
        private int numberOfToppings;
        public Pizza(string name, int numberOfToppings)
        {
            this.Name = name;
            this.NumberOfToppings = numberOfToppings;
            this.Toppings = new List<Topping>();
        }

        public int NumberOfToppings
        {
            get { return this.numberOfToppings; }
            set
            {
                if (value < 1 || value > 10)
                {
                    throw new ArgumentException("Number of toppings should be in range [0..10].");
                }
                this.numberOfToppings = value;
            }
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value) || value.Length > 15)
                {
                    throw new ArgumentException("Pizza name should be between 1 and 15 symbols.");
                }
                this.name = value;
            }
        }

        public Dough Dough
        {
            get { return this.dough; }
            set { this.dough = value; }
        }

        public List<Topping> Toppings
        {
            get { return this.toppings; }
            set { this.toppings = value; }
        }
        public double GetCalories()
        {
            double toppingsCalories = 0;
            foreach (var topping in toppings)
            {
                toppingsCalories += topping.GetCalories();
            }
            return this.dough.GetCalories() + toppingsCalories;
        }
        public void AddTopping(Topping topping)
        {
            this.toppings.Add(topping);
        }
    }
}
