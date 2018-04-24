public class EarthMonument : Monument
{
    private int earthAffinity;
    public EarthMonument(string name, int earthAffinity) : base(name)
    {
        this.EarthAffinity = earthAffinity;
    }

    protected int EarthAffinity
    {
        get { return this.earthAffinity; }
        set { this.earthAffinity = value; }
    }

    public override int TotalAffinity()
    {
        return this.earthAffinity;
    }

    public override string ToString()
    {
        return $"###Earth Monument: {this.Name}, Earth Affinity: {this.earthAffinity}";
    }
}
