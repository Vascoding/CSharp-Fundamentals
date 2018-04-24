using System;
using System.Collections.Generic;

namespace Animals
{
    public class Program
    {
        public static void Main()
        {
            List<Animal> animals = new List<Animal>();
            while (true)
            {
                try
                {
                    var input = Console.ReadLine();
                    if (input.Equals("Beast!"))
                    {
                        break;
                    }
                    var animalInput = Console.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                    int age;
                    if (!int.TryParse(animalInput[1], out age))
                    {
                        throw new ArgumentException("Invalid input!");
                    }

                    switch (input)
                    {
                        case "Cat":
                            Cat cat = new Cat(animalInput[0], int.Parse(animalInput[1]), animalInput[2]);
                            Console.WriteLine(cat);
                            break;
                        case "Dog":
                            Dog dog = new Dog(animalInput[0], int.Parse(animalInput[1]), animalInput[2]);
                            Console.WriteLine(dog);
                            break;
                        case "Frog":
                            Frog frog = new Frog(animalInput[0], int.Parse(animalInput[1]), animalInput[2]);
                            Console.WriteLine(frog);
                            break;
                        case "Kitten":
                            Kitten kitten = new Kitten(animalInput[0], int.Parse(animalInput[1]));
                            Console.WriteLine(kitten);
                            break;
                        case "Tomcat":
                            Tomcat tomcat = new Tomcat(animalInput[0], int.Parse(animalInput[1]));
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            throw new ArgumentException("Invalid input!");

                    }
                }

                catch (ArgumentException e)
                {
                    Console.WriteLine(e.Message);
                }
                catch (Exception)
                {
                    Console.WriteLine("Invalid input!");
                }
            }
        }
    }
}
