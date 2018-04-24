public class FireMonument : Monument
{
    private int fireAffinity;
    public FireMonument(string name, int fireAffinity) : base(name)
    {
        this.FireAffinity = fireAffinity;
    }

    protected int FireAffinity
    {
        get { return this.fireAffinity; }
        set { this.fireAffinity = value; }
    }

    public override int TotalAffinity()
    {
        return this.fireAffinity;
    }

    public override string ToString()
    {
        return $"###Fire Monument: {this.Name}, Fire Affinity: {this.fireAffinity}";
    }
}
