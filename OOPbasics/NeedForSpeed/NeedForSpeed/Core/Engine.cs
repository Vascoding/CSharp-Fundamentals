using System;

public class Engine
{
    private CarManager manager;

    public Engine()
    {
        this.manager = new CarManager();
    }
    public void Run()
    {
        while (true)
        {
            var input = Console.ReadLine().Split();
            
            var command = input[0];
            if (command == "Cops")
            {
                break;
            }
            var id = int.Parse(input[1]);
            switch (command)
            {
                case "register":
                    var type = input[2];
                    var brand = input[3];
                    var model = input[4];
                    var yearOfProduction = int.Parse(input[5]);
                    var horsePowers = int.Parse(input[6]);
                    var acceleration = int.Parse(input[7]);
                    var suspension = int.Parse(input[8]);
                    var durability = int.Parse(input[9]);
                    this.manager.Register(id, type, brand, model, yearOfProduction, horsePowers, acceleration, suspension, durability);
                    break;
                case "check":
                    Console.WriteLine(this.manager.Check(id));
                    break;
                case "open":
                    var raceType = input[2];
                    var length = int.Parse(input[3]);
                    var route = input[4];
                    var prizePool = int.Parse(input[5]);
                    var specialParam = 0;
                    if (raceType == "Circuit" || raceType == "TimeLimit")
                    {
                        specialParam = int.Parse(input[6]);
                    }
                    this.manager.Open(id, raceType, length, route, prizePool, specialParam);
                    break;
                case "participate":
                    var raceId = int.Parse(input[2]);
                    this.manager.Participate(id, raceId);
                    break;
                case "start":
                    Console.WriteLine(this.manager.Start(id));
                    break;
                case "park":
                    this.manager.Park(id);
                    break;
                case "unpark":
                    this.manager.Unpark(id);
                    break;
                case "tune":
                    var addOns = input[2];
                    this.manager.Tune(id, addOns);
                    break;
                default:
                    break;
            }
        }
    }
}

