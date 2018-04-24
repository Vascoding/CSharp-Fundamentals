using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CircuitRace : Race
{
    private int laps;
    public CircuitRace(int length, string route, int prizePool, int laps)
        : base(length, route, prizePool)
    {
        this.laps = laps;
    }

    public override string ToString()
    {
        List<Car> winers = this.GetParticipans().OrderByDescending(c => this.OverallPerformance(c.Horsepower, c.Acceleration, c.Suspension, c.Durability)).Take(4).ToList();
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length * this.laps}");
        var places = new Dictionary<int, int>();
        places.Add(1, (this.PrizePool * 40) / 100);
        places.Add(2, (this.PrizePool * 30) / 100);
        places.Add(3, (this.PrizePool * 20) / 100);
        places.Add(4, (this.PrizePool * 10) / 100);
        for (int i = 0; i < winers.Count(); i++)
        {
            sb.AppendLine($"{i + 1}. {winers[i].Brand} {winers[i].Model} {this.OverallPerformance(winers[i].Horsepower, winers[i].Acceleration, winers[i].Suspension, winers[i].Durability - this.laps * (this.Length * this.Length))}PP - ${places[i + 1]}");
        }
        var participants = this.GetParticipans();

        foreach (var car in participants)
        {
            car.Durability -= this.laps * (this.Length * this.Length);
        }
        return sb.ToString().Trim();
    }

    private int OverallPerformance(int horsepower, int acceleration, int suspension, int durability)
    {
        return (horsepower / acceleration) + (suspension + durability);
    }
}

