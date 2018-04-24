using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RaceTower
{
    private int laps;
    private int currentLap = 0;
    private int trackLength;
    private string weather = "Sunny";

    private List<Driver> drivers;

    public RaceTower()
    {
        this.drivers = new List<Driver>();
    }

    public bool IsRaceFinished => this.currentLap == this.laps;

    public void SetTrackInfo(int lapsNumber, int trackLength)
    {
        this.laps = lapsNumber;
        this.trackLength = trackLength;
    }
    public void RegisterDriver(List<string> commandArgs)
    {
        try
        {
            var driverType = commandArgs[0];
            var driverName = commandArgs[1];
            var hp = int.Parse(commandArgs[2]);
            var fuelAmount = double.Parse(commandArgs[3]);
            var tyreType = commandArgs[4];
            var tyreHardness = double.Parse(commandArgs[5]);
            var grip = 0.0;
            Driver driver = null;
            Car car = null;
            Tyre tyre = null;
            if (tyreType == "Ultrasoft")
            {
                grip = double.Parse(commandArgs[6]);
                tyre = TyreFactory.CreateUltraSoft(tyreHardness, grip);
            }
            else if (tyreType == "Hard")
            {
                tyre = TyreFactory.CreateHard(tyreHardness);
            }
           
            car = CarFactory.CreateCar(hp, fuelAmount, tyre);
            driver = DriverFactory.CreateDriver(driverType, driverName, car);

            this.drivers.Add(driver);
        }
        catch
        {
        }
    }

    public void DriverBoxes(List<string> commandArgs)
    {
        var reason = commandArgs[0];
        var driverName = commandArgs[1];
        var driver = this.drivers.FirstOrDefault(d => d.Name == driverName);
        driver.IncreaseByInterval(20);
        if (reason == "Refuel")
        {
            driver.BoxForRefuel(double.Parse(commandArgs[2]));
        }
        if (reason == "ChangeTyres")
        {
            var tyreType = commandArgs[2];
            if (tyreType == "Hard")
            {
                driver.BoxForTyres(TyreFactory.CreateHard(double.Parse(commandArgs[3])));
            }
            if (tyreType == "Ultrasoft")
            {
                driver.BoxForTyres(TyreFactory.CreateUltraSoft(double.Parse(commandArgs[3]), double.Parse(commandArgs[4])));
            }
        }
    }

    public string CompleteLaps(List<string> commandArgs)
    {
        var lapsToComplete = int.Parse(commandArgs[0]);
        StringBuilder sb = new StringBuilder();
        if (lapsToComplete > this.laps - this.currentLap)
        {
            throw new ArgumentException($"There is no time! On lap {this.currentLap}.");
        }

        for (int i = 0; i < lapsToComplete; i++)
        {
            foreach (var driver in this.drivers)
            {
                if (!driver.IsFailed)
                {
                    driver.IncreaseTotalTime(this.trackLength);
                    try
                    {
                        driver.Car.DecreaseFuel(this.trackLength, driver.FuelConsumptionPerKm);
                    }
                    catch
                    {
                        driver.FailedReason = "Out of fuel";
                    }
                    try
                    {
                        driver.Car.Tyre.ReduceDegradation();
                    }
                    catch
                    {
                        driver.FailedReason = "Blown Tyre";
                    }
                }
            }
            var fromSlowest = drivers.OrderByDescending(d => d.TotalTime).ToList();
            for (int j = 0; j < fromSlowest.Count; j++)
            {
                if (j < fromSlowest.Count - 1)
                {
                    if (this.Overtake(fromSlowest[j], fromSlowest[j + 1]))
                    {
                        sb.AppendLine($"{fromSlowest[j].Name} has overtaken {fromSlowest[j + 1].Name} on lap {i + 1}.");
                        j++;
                    }
                }
            }
        }

        this.currentLap += lapsToComplete;
        if (this.IsRaceFinished)
        {
            var driver = this.drivers.Where(d => !d.IsFailed).OrderBy(d => d.TotalTime).FirstOrDefault();
            return $"{driver.Name} wins the race for {driver.TotalTime:f3} seconds.";
        }
        return sb.ToString().Trim();
    }

    public string GetLeaderboard()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"Lap {currentLap}/{laps}");
        var onGoing = this.drivers.Where(d => !d.IsFailed).OrderBy(d => d.TotalTime).ToList();
        var failedDrivers = this.drivers.Where(d => d.IsFailed).ToList();
        var place = 0;
        for (int i = 0; i < onGoing.Count(); i++)
        {
            place++;
            sb.AppendLine($"{place} {onGoing[i].Name} {onGoing[i].TotalTime:f3}");
        }
        for (int i = failedDrivers.Count - 1; i >= 0; i--)
        {
            place++;
            sb.AppendLine($"{place} {failedDrivers[i].Name} {failedDrivers[i].FailedReason}");
        }
       
        return sb.ToString().Trim();
    }

    public void ChangeWeather(List<string> commandArgs)
    {
        this.weather = commandArgs[0];
    }

    public bool Overtake(Driver behind, Driver ahead)
    {
        var interval = behind.OvertakeInterval(this.weather);
        if (!behind.IsFailed && !ahead.IsFailed)
        {
            if (behind.TotalTime - ahead.TotalTime <= interval)
            {
                behind.DecreaseTotalTime(interval);
                ahead.IncreaseByInterval(interval);
                return true;
            }
        }
        
        return false;
    }
}

