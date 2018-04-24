using System;
using System.Text;

public abstract class Provider : Unit
{
    private string id;
    private double energyOutput;

    protected Provider(string id, double energyOutput)
        : base(id)
    {
        this.EnergyOutput = energyOutput;
    }

    public string Id
    {
        get { return this.id; }
        protected set { this.id = value; }
    }

    public double EnergyOutput
    {
        get { return this.energyOutput; }
        protected set
        {
            if (value < 0 || value >= 10000)
            {
                throw new ArgumentException("Provider is not registered, because of it's EnergyOutput");
            }
            this.energyOutput = value;
        }
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.GetType().Name.Substring(0, this.GetType().Name.Length - 8)} Provider - {this.Id}");
        sb.AppendLine($"Energy Output: {this.energyOutput}");

        return sb.ToString().Trim();
    }
}
