using System;

public class CharacterFactory
{
    public static Character CreateCharacter(string faction, string type, string name)
    {
        if (faction != "CSharp" && faction != "Java")
        {
            throw new ArgumentException($"Invalid faction \"{faction}\"!");
        }
        if (type != "Warrior" && type != "Cleric")
        {
            throw new ArgumentException($"Invalid character type \"{type}\"!");
        }

        var soldier = Type.GetType(type).GetConstructors()[0].Invoke(new object[] { name, Enum.Parse(typeof(Faction), faction) });
        return (Character)soldier;
    }
}

