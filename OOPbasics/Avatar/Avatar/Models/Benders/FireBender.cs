public class FireBender : Bender
{
    private double heatAggression;
    public FireBender(string name, int power, double heatAggression) : base(name, power)
    {
        this.HeatAggression = heatAggression;
    }

    public double HeatAggression
    {
        get { return this.heatAggression; }
        set { this.heatAggression = value; }
    }

    public override double TotalPower()
    {
        return this.heatAggression * this.Power;
    }

    public override string ToString()
    {
        return $"###Fire Bender: {this.Name}, Power: {this.Power}, Heat Aggression: {this.heatAggression:f2}";
    }
}
