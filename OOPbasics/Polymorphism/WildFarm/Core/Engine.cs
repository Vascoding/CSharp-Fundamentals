using System;

namespace WildFarm.Core
{
    public class Engine
    {
        public void Start()
        {
            string commands;
            while ((commands = Console.ReadLine()) != "End")
            {
                var cmdArgs = commands.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                var animal = ExecuteOddCommand(cmdArgs);
                var cmdFood = Console.ReadLine().Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                ExecuteEvenCommand(animal, cmdFood);
            }
        }

        private void ExecuteEvenCommand(Animal animal, string[] cmdFood)
        {
            var food = cmdFood[0];
            var quantity = int.Parse(cmdFood[1]);

            switch (food)
            {
                case "Vegetable":
                    Vegetable vegetable = new Vegetable(quantity);
                    try
                    {
                        Console.WriteLine(animal.MakeSound());
                        animal.EatFood(vegetable);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }

                    CommandDispatcher.Dispatch(animal);
                    break;
                case "Meat":
                    Meat meat = new Meat(quantity);
                    try
                    {
                        Console.WriteLine(animal.MakeSound());
                        animal.EatFood(meat);
                    }
                    catch (ArgumentException e)
                    {
                        Console.WriteLine(e.Message);
                    }
                    CommandDispatcher.Dispatch(animal);
                    break;
            }
        }

        private Animal ExecuteOddCommand(string[] cmdArgs)
        {
            var animalType = cmdArgs[0];
            var animalName = cmdArgs[1];
            var animalWeight = double.Parse(cmdArgs[2]);
            var animalRegion = cmdArgs[3];

            switch (animalType)
            {

                case "Mouse":
                    Mouse mouse = new Mouse(animalType, animalName, animalWeight, animalRegion);
                    return mouse;
                case "Tiger":
                    Tiger tiger = new Tiger(animalType, animalName, animalWeight, animalRegion);
                    return tiger;
                case "Cat":
                    var breed = cmdArgs[4];
                    Cat cat = new Cat(animalType, animalName, animalWeight, animalRegion, breed);
                    return cat;
                case "Zebra":
                    Zebra zebra = new Zebra(animalType, animalName, animalWeight, animalRegion);
                    return zebra;
                default:
                    return null;
            }
        }
    }
}
