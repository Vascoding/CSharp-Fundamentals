using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public abstract class Race
{
    private List<Car> participants;
    private int length;
    private string route;
    private int prizePool;

    protected Race(int length, string route, int prizePool)
    {
        this.participants = new List<Car>();
        this.length = length;
        this.route = route;
        this.prizePool = prizePool;
    }

    public int Length
    {
        get
        {
            return this.length;
        }
        protected set
        {
            this.length = value;
        }
    }

    public string Route
    {
        get
        {
            return this.route;
        }
        protected set
        {
            this.route = value;
        }
    }

    public int PrizePool
    {
        get
        {
            return this.prizePool;
        }
        protected set
        {
            this.prizePool = value;
        }
    }

    public bool IsOpen { get; private set; } = true;

    public void CloseRace()
    {
        this.IsOpen = false;
    }

    public bool isStarted { get; private set; } = false;

    public List<Car> GetParticipans()
    {
        return this.participants;
    }

    public void StartRace()
    {
        this.IsOpen = false;
        this.isStarted = true;
    }

    public virtual void AddParticipant(Car car)
    {
        this.participants.Add(car);
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine($"{this.Route} - {this.Length}");

        return sb.ToString().Trim();
    }
}

