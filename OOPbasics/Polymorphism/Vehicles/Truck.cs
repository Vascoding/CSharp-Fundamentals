using System;

namespace Vehicles
{
    public class Truck : Vehicle
    {

        public Truck(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm += 1.6;
        }
        public override void Refuel(double fuel)
        {
            base.Refuel(fuel * 0.95);
        }
    }
}