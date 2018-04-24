using System;

namespace PizzaCalories
{
    public class Dough
    {
        private const double white = 1.5;
        private const double wholegrain = 1.0;
        private const double crispy = 0.9;
        private const double chewy = 1.1;
        private const double homemade = 1.0;
        private const double doughCalories = 2;

        private string flourType;
        private string bakingTechnique;
        private double weight;

        public Dough(string flourType, string bakingTechnique, double weight)
        {
            this.FlourType = flourType;
            this.BackingTechnique = bakingTechnique;
            this.Weight = weight;
        }
        public string FlourType
        {
            get { return this.flourType; }
            private set
            {
                if (value.ToLower() != "white" && value.ToLower() != "wholegrain")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.flourType = value;
            }
        }

        public double Weight
        {
            get { return this.weight; }
            private set
            {
                if (value < 1 || value > 200)
                {
                    throw new ArgumentException("Dough weight should be in the range [1..200].");
                }
                this.weight = value;
            }
        }

        public string BackingTechnique
        {
            get { return this.bakingTechnique; }
            private set
            {
                if (value.ToLower() != "crispy" && value.ToLower() != "chewy" && value.ToLower() != "homemade")
                {
                    throw new ArgumentException("Invalid type of dough.");
                }
                this.bakingTechnique = value;
            }
        }

        public double GetCalories()
        {
            double flour = 0;
            double backing = 0;
            switch (this.flourType.ToLower())
            {
                case "white":
                    flour = white;
                    break;
                case "wholegrain":
                    flour = wholegrain;
                    break;
            }
            switch (this.bakingTechnique.ToLower())
            {
                case "crispy":
                    backing = crispy;
                    break;
                case "chewy":
                    backing = chewy;
                    break;
                case "homemade":
                    backing = homemade;
                    break;
            }
            return (doughCalories * this.weight) * flour * backing;
        }
    }
}
