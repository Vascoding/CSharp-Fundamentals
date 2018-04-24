using System;

public abstract class Tyre
{
    private string name;
    private double hardness;
    private double degradation = 100;
    protected Tyre(string name, double hardness)
    {
        this.name = name;
        this.hardness = hardness;
    }

    public string Name
    {
        get { return this.name; }
        protected set { this.name = value; }
    }

    public double Hardness
    {
        get { return this.hardness; }
        protected set { this.hardness = value; }
    }

    public double Degradation
    {
        get { return this.degradation; }
        protected set
        {
            if (value < this.BlowUpPoint)
            {
                throw new ArgumentException();
            }
            this.degradation = value;
        }
    }
    public virtual void ReduceDegradation()
    {
         this.Degradation -= this.Hardness;
    }

    protected virtual int BlowUpPoint => 0;
}

