public class EnduranceDriver : Driver
{
    private const double FuelConsumption = 1.5;
    private const int OvertakeIntervalOnSpecialCase = 3;
    private const int BaseOvertakeInterval = 2;

    public EnduranceDriver(string name, Car car)
        : base(name, car, FuelConsumption)
    {
    }

    public override int OvertakeInterval(string weather)
    {
        if (this.Car.Tyre.Name == "Hard")
        {
            if (weather == "Rainy")
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

