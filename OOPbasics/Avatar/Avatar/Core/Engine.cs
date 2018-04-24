using System;
using System.Collections.Generic;
using System.Linq;
using Avatar.Models.Nations;

public class Engine
{
    public static void Start()
    {
        Nation airNation = new AirNation("Air Nation");
        Nation fireNation = new FireNation("Fire Nation");
        Nation waterNation = new WaterNation("Water Nation");
        Nation earthNation = new EarthNation("Earth Nation");
        List<War> wars = new List<War>();
        string input;
        while ((input = Console.ReadLine()) != "Quit")
        {
            var cmdArgs = input.Split(new []{' '}, StringSplitOptions.RemoveEmptyEntries);
            
            List<Nation> nations = new List<Nation>();
            nations.Add(airNation);
            nations.Add(fireNation);
            nations.Add(waterNation);
            nations.Add(earthNation);
            Execute(cmdArgs, nations, wars);
        }
        for (int i = 0; i < wars.Count; i++)
        {
            Console.WriteLine($"War {i + 1} issued by {wars[i].Name}");
        }
    }

    private static void Execute(string[] cmdArgs, List<Nation> nations, List<War> wars)
    {
        switch (cmdArgs[0])
        {
            case "Bender":
                InsertBender(cmdArgs, nations);
                break;
            case "Monument":
                InsertMonument(cmdArgs, nations);
                break;
            case "Status":
                PrintStatus(cmdArgs[1], nations);
                break;
            case "War":
                War war = new War(cmdArgs[1]);
                war.Nations.AddRange(nations);
                wars.Add(war);
                war.Fight();
                break;
        }
    }

    private static void PrintStatus(string type, List<Nation> nations)
    {
        switch (type)
        {
            case "Air":
                var airNation = nations.FirstOrDefault(n => n.Name.Contains(type));
                Console.WriteLine(airNation);
                break;
            case "Fire":
                var fireNation = nations.FirstOrDefault(n => n.Name.Contains(type));
                Console.WriteLine(fireNation);
                break;
            case "Earth":
                var earthNation = nations.FirstOrDefault(n => n.Name.Contains(type));
                Console.WriteLine(earthNation);
                break;
            case "Water":
                var waterNation = nations.FirstOrDefault(n => n.Name.Contains(type));
                Console.WriteLine(waterNation);
                break;
        }
    }

    private static void InsertMonument(string[] cmdArgs, List<Nation> nations)
    {
        var type = cmdArgs[1];
        var name = cmdArgs[2];
        var affinity = int.Parse(cmdArgs[3]);

        switch (type)
        {
            case "Air":
                Monument airMonument = new AirMonument(name, affinity);
                var airNation = nations.FirstOrDefault(n => n.Name == "Air Nation");
                airNation.Monuments.Add(airMonument);
                break;
            case "Earth":
                Monument earthMonument = new EarthMonument(name, affinity);
                var earthNation = nations.FirstOrDefault(n => n.Name == "Earth Nation");
                earthNation.Monuments.Add(earthMonument);
                break;
            case "Fire":
                Monument fireMonument = new FireMonument(name, affinity);
                var fireNation = nations.FirstOrDefault(n => n.Name == "Fire Nation");
                fireNation.Monuments.Add(fireMonument);
                break;
            case "Water":
                Monument waterMonument = new WaterMonument(name, affinity);
                var waterNation = nations.FirstOrDefault(n => n.Name == "Water Nation");
                waterNation.Monuments.Add(waterMonument);
                break;
        }
    }

    private static void InsertBender(string[] cmdArgs, List<Nation> nations)
    {
        var type = cmdArgs[1];
        var name = cmdArgs[2];
        var power = int.Parse(cmdArgs[3]);
        var secondaryParam = double.Parse(cmdArgs[4]);
        switch (type)
        {
            case "Air":
                Bender airBender = new AirBender(name, power, secondaryParam);
                var airNation = nations.FirstOrDefault(n => n.Name == "Air Nation");
                airNation.Benders.Add(airBender);
                break; 
            case "Earth":
                Bender earthBender = new EarthBender(name, power, secondaryParam);
                var earthNation = nations.FirstOrDefault(n => n.Name == "Earth Nation");
                earthNation.Benders.Add(earthBender);
                break;
            case "Fire":
                Bender fireBender = new FireBender(name, power, secondaryParam);
                var fireNation = nations.FirstOrDefault(n => n.Name == "Fire Nation");
                fireNation.Benders.Add(fireBender);
                break;
            case "Water":
                Bender waterBender = new WaterBender(name, power, secondaryParam);
                var waterNation = nations.FirstOrDefault(n => n.Name == "Water Nation");
                waterNation.Benders.Add(waterBender);
                break;
        }
    }
}

