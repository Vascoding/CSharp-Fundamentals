using System;

namespace Vehicles
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity) : base(fuelQuantity, fuelConsumptionPerKm, tankCapacity)
        {
            this.FuelConsumptionPerKm += 0.9;
        }

        protected override double FuelQuantity
        {
            set
            {
                if (value > this.TankCapacity)
                {
                    throw new ArgumentException("Cannot fit fuel in tank");
                }
                base.FuelQuantity = value;
            }
        }
    }
}