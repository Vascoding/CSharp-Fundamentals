using System;

public class DriverFactory
{
    public static Driver CreateDriver(string type, string name, Car car)
    {
        type += "Driver";
        var driver = Type.GetType(type).GetConstructors()[0].Invoke(new object[] { name, car });
        return (Driver)driver;
    }
}

