public class UltrasoftTyre : Tyre
{
    private const string UltraSoftTyreName = "Ultrasoft";
    private double grip;
    public UltrasoftTyre(double hardness, double grip) 
        : base(UltraSoftTyreName, hardness)
    {
        this.grip = grip;
    }

    public double Grip
    {
        get { return this.grip; }
    }

    public override void ReduceDegradation()
    {
        this.Degradation -= (this.Hardness + this.Grip);
    }
    protected override int BlowUpPoint => 30;
}

