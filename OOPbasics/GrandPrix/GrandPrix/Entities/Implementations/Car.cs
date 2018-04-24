using System;

public class Car
{
    private int hp;
    private double fuelAmount;
    private Tyre tyre;
    private const int MaximumTankCapacity = 160;
    public Car(int hp, double fuelAmount, Tyre tyre)
    {
        this.hp = hp;
        this.FuelAmount = fuelAmount;
        this.Tyre = tyre;
    }

    public int Hp
    {
        get { return this.hp; }
    }

    public double FuelAmount
    {
        get { return this.fuelAmount; }
        private set
        {
            if (value < 0)
            {
                throw new ArgumentException();
            }
            this.fuelAmount = Math.Min(value, MaximumTankCapacity);
        }
    }

    public Tyre Tyre
    {
        get { return this.tyre; }
        private set { this.tyre = value; }
    }

    public void DecreaseFuel(int trackLength, double driverFuelConsumptionPerKm)
    {
        this.FuelAmount -= trackLength * driverFuelConsumptionPerKm;
    }

    public void Refuel(double amount)
    {
        this.FuelAmount += amount;
    }

    public void ChangeTyres(Tyre tyre)
    {
        this.Tyre = tyre;
    }
}

