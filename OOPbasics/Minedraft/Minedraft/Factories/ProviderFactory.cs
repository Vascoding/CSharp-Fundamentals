public static class ProviderFactory
{
    public static Provider Get(string type, string id, double energyOutput)
    {
        switch (type)
        {
            case "Solar":
                return new SolarProvider(id, energyOutput);
            case "Pressure":
                return new PressureProvider(id, energyOutput);
            default:
                return null;
        }
    }

}
