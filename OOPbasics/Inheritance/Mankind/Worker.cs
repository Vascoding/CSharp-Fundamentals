using System;

namespace Mankind
{
    public class Worker : Human
    {
        private decimal weekSalary;
        private decimal hoursPerDay;

        public Worker(string firstName, string lastName, decimal weekSalary, decimal hoursPerDay)
            : base(firstName, lastName)
        {
            this.WeekSalary = weekSalary;
            this.HoursPerDay = hoursPerDay;
        }

        public decimal WeekSalary
        {
            get { return this.weekSalary; }
            set
            {
                if (value < 10)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: weekSalary");
                }
                this.weekSalary = value;
            }
        }

        public decimal HoursPerDay
        {
            get { return this.hoursPerDay; }
            set
            {
                if (value < 1 || value > 12)
                {
                    throw new ArgumentException("Expected value mismatch! Argument: workHoursPerDay");
                }
                this.hoursPerDay = value;
            }
        }

        private decimal GetSalaryPerHour()
        {
            return (this.weekSalary/5)/this.HoursPerDay;
        }

        public override string ToString()
        {
            return $"First Name: {this.FirstName}\r\nLast Name: " +
                   $"{this.LastName}\r\nWeek Salary: " +
                   $"{this.weekSalary:f2}\r\nHours per day: " +
                   $"{this.hoursPerDay:f2}\r\nSalary per hour: " +
                   $"{this.GetSalaryPerHour():f2}";
        }
    }
}
