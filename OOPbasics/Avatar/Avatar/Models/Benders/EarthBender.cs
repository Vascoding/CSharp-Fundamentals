public class EarthBender : Bender
{
    private double groundSaturation;
    public EarthBender(string name, int power, double groundSaturation) : base(name, power)
    {
        this.GroundSaturation = groundSaturation;
    }

    public double GroundSaturation
    {
        get { return this.groundSaturation; }
        set { this.groundSaturation = value; }
    }

    public override double TotalPower()
    {
        return this.groundSaturation * this.Power;
    }

    public override string ToString()
    {
        return $"###Earth Bender: {this.Name}, Power: {this.Power}, Ground Saturation: {this.groundSaturation:f2}";
    }
}
