public abstract class Driver
{
    private string name;
    private Car car;
    private double totalTime;
    private double fuelConsumptionPerKm;
    private double speed;
    private string failedReason;
    private const int BaseOvertakeInterval = 2;

    protected Driver(string name, Car car, double fuelConsumptionPerKm)
    {
        this.name = name;
        this.Car = car;
        this.fuelConsumptionPerKm = fuelConsumptionPerKm;
    }


    public string Name => this.name;

    public double TotalTime
    {
        get { return this.totalTime; }
        private set { this.totalTime = value; }
    }

    public double FuelConsumptionPerKm => this.fuelConsumptionPerKm;

    public Car Car
    {
        get { return this.car; }
        protected set { this.car = value; }
    }

    public virtual double Speed
    {
        get { return this.speed; }
        protected set { this.speed = value; }
    }

    public bool IsFailed { get; private set; } = false;

    public string FailedReason {
        get { return this.failedReason; }
        set
        {
            if (!this.IsFailed)
            {
                this.IsFailed = true;
                this.failedReason = value;
            }
        }
    }

    public void IncreaseTotalTime(int trackLength)
    {
        this.Speed = (this.Car.Hp + this.Car.Tyre.Degradation) / this.Car.FuelAmount;
        this.TotalTime += 60 / (trackLength / this.Speed);
    }

    public void BoxForRefuel(double amount)
    {
        this.Car.Refuel(amount);
    }

    public void BoxForTyres(Tyre tyre)
    {
        this.Car.ChangeTyres(tyre);
    }

    public void DecreaseTotalTime(int interval)
    {
        this.TotalTime -= interval;
    }

    public void IncreaseByInterval(int interval)
    {
        this.totalTime += interval;
    }

    public abstract int OvertakeInterval(string weather);
}

