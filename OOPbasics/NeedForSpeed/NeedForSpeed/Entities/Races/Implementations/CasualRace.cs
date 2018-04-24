using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) 
        : base(length, route, prizePool)
    {
    }

    public override string ToString()
    {
        List<Car> winers = this.GetParticipans().OrderByDescending(c => this.OverallPerformance(c.Horsepower, c.Acceleration, c.Suspension, c.Durability)).Take(3).ToList();
        StringBuilder sb = new StringBuilder();
        var places = new Dictionary<int, int>();
        places.Add(1, (this.PrizePool * 50) / 100);
        places.Add(2, (this.PrizePool * 30) / 100);
        places.Add(3, (this.PrizePool * 20) / 100);
        for (int i = 0; i < winers.Count(); i++)
        {
            sb.AppendLine($"{i + 1}. {winers[i].Brand} {winers[i].Model} {this.OverallPerformance(winers[i].Horsepower, winers[i].Acceleration, winers[i].Suspension, winers[i].Durability)}PP - ${places[i + 1]}");
        }

        return base.ToString() + Environment.NewLine + sb.ToString().Trim();
    }

    private int OverallPerformance(int horsepower, int acceleration, int suspension, int durability)
    {
        return (horsepower / acceleration) + (suspension + durability);
    }
}

