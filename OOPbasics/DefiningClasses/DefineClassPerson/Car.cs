using System;
using System.Collections.Generic;
using System.Linq;

namespace DefineClassPerson
{
    public class Car
    {
        private string model;
        private double fuelAmount;
        private double fuelConsumtion;
        private double distanceTraveled;

        public string Model
        {
            get { return this.model; }
            set { this.model = value; }
        }

        public double FuelAmount
        {
            get { return this.fuelAmount; }
            set { this.fuelAmount = value; }
        }

        public double FuelConsumtion
        {
            get { return this.fuelConsumtion; }
            set { this.fuelConsumtion = value; }
        }

        public double DistanceTraveled
        {
            get { return this.distanceTraveled; }
            set { this.distanceTraveled = value; }
        }

        public void Drive(Car car, double distance)
        {
            var consumtion = car.fuelConsumtion;
            var fuelAmount = car.fuelAmount;
            if (consumtion * distance <= fuelAmount)
            {
                this.fuelAmount -= consumtion*distance;
                this.distanceTraveled += distance;
            }
            else
            {
                Console.WriteLine("Insufficient fuel for the drive");
            }
        }
    }
}
