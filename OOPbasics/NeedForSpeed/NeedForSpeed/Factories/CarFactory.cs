using System;

public class CarFactory
{
    public static Car CreateCar(string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        type += "Car";
        return (Car)Type.GetType(type).GetConstructors()[0].Invoke(new object[] { brand, model, yearOfProduction, horsepower, acceleration, suspension, durability });
    }
}

