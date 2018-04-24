using System.Collections.Generic;
using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class Engineer : SpecialisedSoldier, IEngineer
    {
        private HashSet<IAuxiliary> _reparis;

        public HashSet<IAuxiliary> Repairs => _reparis;

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendLine($"Repairs:");
            foreach (var repair in this.Repairs)
            {
                sb.AppendLine(new string(' ', Helper.Indentation) + repair);
            }

            return sb.ToString().Trim();
        }

        public Engineer(string id, string firstName, string lastName, double salary, string corps, HashSet<IAuxiliary> repairs)
            : base(id, firstName, lastName, salary, corps)
        {
            this._reparis = repairs;
        }
    }
}