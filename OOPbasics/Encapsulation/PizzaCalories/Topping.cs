using System;

namespace PizzaCalories
{
    public class Topping
    {
        private const double meatModifier = 1.2;
        private const double veggiesModifier = 0.8;
        private const double cheeseModifier = 1.1;
        private const double souseModifier = 0.9;
        private const double caloriesPerGram = 2;

        private string type;
        private double weight;

        public Topping(string type, double weight)
        {
            this.Type = type;
            this.Weight = weight;
        }
        public string Type
        {
            get { return this.type; }
            set
            {
                if (value.ToLower() != "meat" && value.ToLower() != "veggies" && value.ToLower() != "cheese" && value.ToLower() != "sauce")
                {
                    throw new ArgumentException($"Cannot place {value} on top of your pizza.");
                }
                this.type = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            set
            {
                if (value < 1 || value > 50)
                {
                    throw new ArgumentException($"{this.type} weight should be in the range [1..50].");
                }
                this.weight = value;
            }
        }

        public double GetCalories()
        {
            double toppingModifier = 0;
            switch (this.type.ToLower())
            {
                case "meat":
                    toppingModifier = meatModifier;
                    break;
                case "veggies":
                    toppingModifier = veggiesModifier;
                    break;
                case "cheese":
                    toppingModifier = cheeseModifier;
                    break;
                case "sauce":
                    toppingModifier = souseModifier;
                    break;

            }
            
            return (caloriesPerGram * weight) * toppingModifier;
        }
    }
}
