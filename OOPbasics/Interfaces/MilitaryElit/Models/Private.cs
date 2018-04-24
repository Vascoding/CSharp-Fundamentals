using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class Private : Soldier, IPrivate
    {
        private double _salary;

        public double Salary
        {
            get { return this._salary; }
            set { this._salary = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString())
                .Append($" Salary: {this.Salary:F2}");

            return sb.ToString();
        }

        public Private(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName)
        {
            this.Salary = salary;
        }
    }
}