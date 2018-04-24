using System;
using System.Linq;

public class Engine
{
    private IWriter writer;
    private IReader reader;
    private RaceTower raceTower;
    public Engine()
    {
        this.writer = new Writer();
        this.reader = new Reader();
        this.raceTower = new RaceTower();
    }

    public void Run()
    {
        var trackLabs = int.Parse(reader.ReadLine());
        var trackLength = int.Parse(reader.ReadLine());
        this.raceTower.SetTrackInfo(trackLabs, trackLength);
        while (true)
        {
            try
            {
                if (this.raceTower.IsRaceFinished)
                {
                    break;
                }
                var input = reader.ReadLine().Split();

                var command = input[0];

                switch (command)
                {
                    case "RegisterDriver":
                        this.raceTower.RegisterDriver(input.Skip(1).ToList());
                        break;
                    case "Leaderboard":
                        this.writer.WriteLine(this.raceTower.GetLeaderboard());
                        break;
                    case "ChangeWeather":
                        this.raceTower.ChangeWeather(input.Skip(1).ToList());
                        break;
                    case "CompleteLaps":
                        var message = this.raceTower.CompleteLaps(input.Skip(1).ToList());
                        if (message != "")
                        {
                            writer.WriteLine(message);
                        }
                        break;
                    case "Box":
                        this.raceTower.DriverBoxes(input.Skip(1).ToList());
                        break;
                    default:
                        break;
                }
            }
            catch (Exception ex)
            {
                writer.WriteLine(ex.Message);
            }
        }
    }
}

