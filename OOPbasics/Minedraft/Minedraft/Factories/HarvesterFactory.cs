public static class HarvesterFactory
{
    public static Harvester Get(string type, string id, double oreOutput, double energyRequirement, int sonicFactor)
    {
        switch (type)
        {
            case "Sonic":
                return new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            case "Hammer":
                return new HammerHarvester(id, oreOutput, energyRequirement);
            default:
                return null;
        }
    }
}
