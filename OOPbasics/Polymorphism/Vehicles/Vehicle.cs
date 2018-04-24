using System;

namespace Vehicles
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumptionPerKm;
        private double tankCapacity;
        public Vehicle(double fuelQuantity, double fuelConsumptionPerKm, double tankCapacity)
        {
            this.TankCapacity = tankCapacity;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumptionPerKm = fuelConsumptionPerKm;
            
        }
        protected virtual double FuelQuantity
        {
            get { return this.fuelQuantity; }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }
                this.fuelQuantity = value;
            }
        }

        public double FuelConsumptionPerKm
        {
            get { return this.fuelConsumptionPerKm; }
            set { this.fuelConsumptionPerKm = value; }
        }

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            set { this.tankCapacity = value; }
        }
        protected virtual bool Drive(double distance, bool isAcOn)
        {
            var fuelNeeded = distance* this.fuelConsumptionPerKm;
            if (fuelNeeded <= fuelQuantity)
            {
                fuelQuantity -= fuelNeeded;
                return true;
            }
            return false;
        }

        
        public string TryTravel(double distance, bool isAcOn)
        {
            if (this.Drive(distance, isAcOn))
            {
                return $"{this.GetType().Name} travelled {distance} km";
            }
            return $"{this.GetType().Name} needs refueling";
        }

        public string TryTravel(double distance)
        {
            return this.TryTravel(distance, true);
        }
        public virtual void Refuel(double fuel)
        {
            if (fuel <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
            this.FuelQuantity += fuel;
        }
       
        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:f2}";
        }
    }
}