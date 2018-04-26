using System;

public class ItemFactory
{
    public static Item CreateItem(string type)
    {
        if (type != "ArmorRepairKit" && type != "HealthPotion" && type != "PoisonPotion")
        {
            throw new ArgumentException($"Invalid item \"{type}\"!");
        }
        var item = Type.GetType(type).GetConstructors()[0].Invoke(new object[] { });
        return (Item)item;
    }
}

