using System;
using System.Linq;
using System.Text;

public class TimeLimitRace : Race
{
    private int goldTime;
    public TimeLimitRace(int length, string route, int prizePool, int goldTime) 
        : base(length, route, prizePool)
    {
        this.goldTime = goldTime;
    }

    public override void AddParticipant(Car car)
    {
        if (this.GetParticipans().Count == 0)
        {
            base.AddParticipant(car);
        }
    }

    public override string ToString()
    {
        Car winer = this.GetParticipans().FirstOrDefault();
        StringBuilder sb = new StringBuilder();
        var wonPrize = 0;
        var earnedTime = "";
        var timePerformance = this.TimePerformance(winer.Horsepower, winer.Acceleration);
        if (timePerformance <= this.goldTime)
        {
            earnedTime = "Gold";
            wonPrize = this.PrizePool;
        }

        else if (timePerformance <= this.goldTime + 15)
        {
            earnedTime = "Silver";
            wonPrize = (this.PrizePool * 50) / 100;
        }

        else if (timePerformance > this.goldTime + 15)
        {
            earnedTime = "Bronze";
            wonPrize = (this.PrizePool * 30) / 100;
        }

        sb.AppendLine($"{winer.Brand} {winer.Model} - {timePerformance} s.");
        sb.AppendLine($"{earnedTime} Time, ${wonPrize}.");
        

        return base.ToString() + Environment.NewLine + sb.ToString().Trim();
    }

    private int TimePerformance(int horsepower, int acceleration)
    {
        return this.Length * ((horsepower / 100) * acceleration);
    }
}

