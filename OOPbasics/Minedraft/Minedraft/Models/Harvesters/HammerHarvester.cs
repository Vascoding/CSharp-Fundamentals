public class HammerHarvester : Harvester
{
    public HammerHarvester(string id, double oreOutput, double energyRequirement) : base(id, oreOutput, energyRequirement)
    {
        this.OreOutput += oreOutput*2;
        this.EnergyRequirement += energyRequirement;
    }
}
