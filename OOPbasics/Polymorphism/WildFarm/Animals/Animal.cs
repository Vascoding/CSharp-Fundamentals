using System.Text;

namespace WildFarm
{
    public abstract class Animal
    {
        private string animalType;
        private string animalName;
        private double animalWeight;
        private int foodEaten;
        public Animal(string animalType, string animalName, double animalWeight)
        {
            this.AnimalType = animalType;
            this.AnimalName = animalName;
            this.AnimalWeight = animalWeight;
        }

        public string AnimalType
        {
            get { return this.animalType; }
            set { this.animalType = value; }
        }

        public string AnimalName
        {
            get { return this.animalName; }
            set { this.animalName = value; }
        }

        public double AnimalWeight
        {
            get { return this.animalWeight; }
            set { this.animalWeight = value; }
        }

        public int FoodEaten
        {
            get { return this.foodEaten; }
            set { this.foodEaten = value; }
        }

        public abstract string MakeSound();

        public abstract void EatFood(Food food);

        
    }
}