public class AirMonument : Monument
{
    private int airAffinity;
    public AirMonument(string name, int airAffinity) : base(name)
    {
        this.AirAffinity = airAffinity;
    }

    public int AirAffinity
    {
        get { return this.airAffinity; }
        set { this.airAffinity = value; }
    }

    public override int TotalAffinity()
    {
        return this.airAffinity;
    }

    public override string ToString()
    {
        return $"###Air Monument: {this.Name}, Air Affinity: {this.airAffinity}";
    }
}
