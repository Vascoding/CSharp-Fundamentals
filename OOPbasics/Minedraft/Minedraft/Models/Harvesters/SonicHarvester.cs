public class SonicHarvester : Harvester
{
    private int sonicFactor;

    public SonicHarvester(string id, double oreOutput, double energyRequirement, int sonicFactor) : base(id, oreOutput, energyRequirement)
    {
        this.EnergyRequirement = energyRequirement / sonicFactor;
    }

    public int SonicFactor
    {
        get { return this.sonicFactor; }
        protected set { this.sonicFactor = value; }
    }
}
