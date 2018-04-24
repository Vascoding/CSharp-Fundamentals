public class Tesla : ICar, IElectricCar
{
    public string Model { get; private set; }
    public string Color { get; private set; }
    public int Battery { get; private set; }

    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }
    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }

    public override string ToString()
    {
        return $"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} batteries";
    }
}
