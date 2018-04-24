using System;
using System.Collections.Generic;
using System.Linq;

public class DraftManager
{
    private Dictionary<string, Harvester> harvesters;
    private Dictionary<string, Provider> providers;
    private string mode = "Full Mode";
    private double totalStoredEnergy;
    private double totalMinedOre;


    public DraftManager()
    {
        this.harvesters = new Dictionary<string, Harvester>();
        this.providers = new Dictionary<string, Provider>();
    }

    public string RegisterHarvester(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var oreOutput = double.Parse(arguments[2]);
        var energyRequirement = double.Parse(arguments[3]);
        
        if (type == "Hammer")
        {

            Harvester harvester = new HammerHarvester(id, oreOutput, energyRequirement);
            this.harvesters.Add(id, harvester);

        }
        if (type == "Sonic")
        {
            var sonicFactor = int.Parse(arguments[4]);

            Harvester harvester = new SonicHarvester(id, oreOutput, energyRequirement, sonicFactor);
            this.harvesters.Add(id, harvester);

        }
        return $"Successfully registered {type} Harvester - {id}";
    }
    public string RegisterProvider(List<string> arguments)
    {
        var type = arguments[0];
        var id = arguments[1];
        var energyOutput = double.Parse(arguments[2]);
        if (type == "Pressure")
        {

            Provider provider = new PressureProvider(id, energyOutput);
            this.providers.Add(id, provider);
        }
        if (type == "Solar")
        {

            Provider provider = new SolarProvider(id, energyOutput);
            this.providers.Add(id, provider);
        }
        return $"Successfully registered {type} Provider - {id}";
    }
    public string Day()
    {
        var energySum = this.providers.Values.Sum(e => e.EnergyOutput);
        double energyRequirement = this.harvesters.Values.Sum(e => e.EnergyRequirement);
        this.TotalStoredEnergy += energySum;
        double oreOutput = 0;
        if (this.mode == "Half Mode")
        {
            energyRequirement = energyRequirement * 0.6;
            if (energyRequirement <= TotalStoredEnergy)
            {
                this.TotalStoredEnergy -= energyRequirement;
                oreOutput = this.harvesters.Values.Sum(o => o.OreOutput) * 0.5;
                this.TotalMinedOre += oreOutput;
            }
        }
        if (this.mode == "Full Mode")
        {
            if (energyRequirement <= TotalStoredEnergy)
            {
                this.TotalStoredEnergy -= energyRequirement;
                oreOutput = this.harvesters.Values.Sum(o => o.OreOutput);
                this.TotalMinedOre += oreOutput;
            }
        }
        
        return $"A day has passed.{Environment.NewLine}Energy Provided: {energySum}{Environment.NewLine}Plumbus Ore Mined: {oreOutput}";
    }
    public string Mode(List<string> arguments)
    {
        this.mode = arguments[0] + " " + "Mode";
        return $"Successfully changed working mode to {mode}";
    }
    public string Check(List<string> arguments)
    {
        var id = arguments[0];
        var harvester = harvesters.FirstOrDefault(h => h.Key == id);
        var provider = providers.FirstOrDefault(p => p.Key == id);
        if (harvester.Key != null)
        {
            return $"{harvester.Value.GetType().Name.Replace("Harvester", "")} Harvester - {id}" +
                   $"{Environment.NewLine}Ore Output: {harvester.Value.OreOutput}" +
                   $"{Environment.NewLine}Energy Requirement: {harvester.Value.EnergyRequirement}";
        }
        if (provider.Key != null)
        {
            return $"{provider.Value.GetType().Name.Replace("Provider", "")} Provider - {id}" +
                   $"{Environment.NewLine}Energy Output: {provider.Value.EnergyOutput}";
        }
        return $"No element found with id - {id}";

    }
    public string ShutDown()
    {
        return $"System Shutdown{Environment.NewLine}Total Energy Stored: {this.TotalStoredEnergy}{Environment.NewLine}Total Mined Plumbus Ore: {this.totalMinedOre}";
    }

    public double TotalStoredEnergy
    {
        get { return this.totalStoredEnergy; }
        private set { this.totalStoredEnergy = value; }
    }

    public double TotalMinedOre
    {
        get { return this.totalMinedOre; }
        private set { this.totalMinedOre = value; }
    }

}
