using System;
using System.Text;
using MilitaryElit.Enums;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class SpecialisedSoldier : Private, ISpecialisedSoldier
    {
        private Corps _corps;

        public Corps Corps
        {
            get { return this._corps; }
            set { this._corps = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendLine()
                .AppendLine($"Corps: {this.Corps}");

            return sb.ToString();
        }

        public SpecialisedSoldier(string id, string firstName, string lastName, double salary, string corps)
            : base(id, firstName, lastName, salary)
        {
            if (!Enum.TryParse(corps, out this._corps))
                throw new ArgumentException("Invalid Corps!");
        }
    }
}