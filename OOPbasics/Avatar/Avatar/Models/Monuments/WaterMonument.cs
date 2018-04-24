public class WaterMonument : Monument
{
    private int waterAffinity;
    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    protected int WaterAffinity
    {
        get { return this.waterAffinity; }
        set { this.waterAffinity = value; }
    }

    public override int TotalAffinity()
    {
        return this.waterAffinity;
    }

    public override string ToString()
    {
        return $"###Water Monument: {this.Name}, Water Affinity: {this.waterAffinity}";
    }
}
