using System;

public class ShowCar : Car
{
    private int stars = 0;
    public ShowCar(string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
        : base(brand, model, yearOfProduction, horsepower, acceleration, suspension, durability)
    {
    }

    public override string ToString()
    {
        var stars = $"{Environment.NewLine}{this.stars} *";
        return base.ToString() + stars;
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        this.stars += tuneIndex;
        base.Tune(tuneIndex, addOn);
    }
}

