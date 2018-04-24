using System;
using System.Collections.Generic;

public class PerformanceCar : Car
{
    private ICollection<string> addOns;
    private const int HorsepowersIncreasePercentage = 50;
    private const int SuspensionDecreasePercentage = 25;
    public PerformanceCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability) 
        : base(brand, model, yearOfProduction, horsepower += (horsepower * HorsepowersIncreasePercentage) / 100, acceleration, suspension -= (suspension * SuspensionDecreasePercentage) / 100, durability)
    {
        this.addOns = new List<string>();
    }

   
    public override string ToString()
    {
        var addons = this.addOns.Count == 0 ? $"{Environment.NewLine}Add-ons: None" : $"{Environment.NewLine}Add-ons: {string.Join(", ", this.addOns)}";
        return base.ToString() + addons;
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        this.addOns.Add(addOn);
        base.Tune(tuneIndex, addOn);
    }
}

