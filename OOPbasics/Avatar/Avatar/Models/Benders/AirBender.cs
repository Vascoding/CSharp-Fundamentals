public class AirBender : Bender
{
    private double aerialIntegrity;
    public AirBender(string name, int power, double aeriaIntegrity) : base(name, power)
    {
        this.AerialIntegrity = aeriaIntegrity;
    }

    public double AerialIntegrity
    {
        get { return this.aerialIntegrity; }
        set { this.aerialIntegrity = value; }
    }

    public override double TotalPower()
    {
        return this.aerialIntegrity * this.Power;
    }

    public override string ToString()
    {
        return $"###Air Bender: {this.Name}, Power: {this.Power}, Aerial Integrity: {this.AerialIntegrity:f2}";
    }
}
