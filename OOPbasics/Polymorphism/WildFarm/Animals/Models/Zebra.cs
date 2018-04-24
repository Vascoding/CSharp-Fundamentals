using System;

namespace WildFarm
{
    public class Zebra : Mammal
    {
        public override string MakeSound()
        {
            return "Zs";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name != "Vegetable")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }
            this.FoodEaten = food.Quantity;
        }

        public Zebra(string animalType, string animalName, double animalWeight, string leavingRegion) : base(animalType, animalName, animalWeight, leavingRegion)
        {
        }
    }
}