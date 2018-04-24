public class AggressiveDriver : Driver
{
    private const double FuelConsumption = 2.7;
    private const double SpeedMultiplyer = 1.3;
    private const int OvertakeIntervalOnSpecialCase = 3;
    private const int BaseOvertakeInterval = 2;

    public AggressiveDriver(string name, Car car) 
        : base(name, car, FuelConsumption)
    {
    }

    public override double Speed { get => base.Speed; protected set => base.Speed = value * SpeedMultiplyer; }

    public override int OvertakeInterval(string weather)
    {
        if (this.Car.Tyre.Name == "Ultrasoft")
        {
            if (weather == "Froggy")
            {
                this.FailedReason = "Crashed";
            }
            else
            {
                return OvertakeIntervalOnSpecialCase;
            }
        }
        return BaseOvertakeInterval;
    }
}

