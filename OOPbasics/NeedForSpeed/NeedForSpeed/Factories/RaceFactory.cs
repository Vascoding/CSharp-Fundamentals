using System;

public class RaceFactory
{
    public static Race CreateRace(string type, int length, string route, int prizePool, int specialParam)
    {
        if (type == "TimeLimit" || type == "Circuit")
        {
            type += "Race";
            return (Race)Type.GetType(type).GetConstructors()[0].Invoke(new object[] { length, route, prizePool, specialParam });
        }
        type += "Race";
        return (Race)Type.GetType(type).GetConstructors()[0].Invoke(new object[] { length, route, prizePool});
    }
}

