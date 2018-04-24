using System;

namespace WildFarm
{
    public class Tiger: Felime
    {
        public override string MakeSound()
        {
            return "ROAAR!!!";
        }

        public override void EatFood(Food food)
        {
            if (food.GetType().Name != "Meat")
            {
                throw new ArgumentException($"{this.GetType().Name}s are not eating that type of food!");
            }
            this.FoodEaten = food.Quantity;
        }

        public Tiger(string animalType, string animalName, double animalWeight, string leavingRegion) : base(animalType, animalName, animalWeight, leavingRegion)
        {
        }
    }
}