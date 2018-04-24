using System.Collections.Generic;
using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class Commando : SpecialisedSoldier, ICommando
    {
        private HashSet<IAuxiliary> _missions;

        public HashSet<IAuxiliary> Missions => _missions;

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendLine($"Missions:");
            foreach (var mission in this.Missions)
            {
                sb.AppendLine(new string(' ', Helper.Indentation) + mission);
            }

            return sb.ToString().Trim();
        }

        public Commando(string id, string firstName, string lastName, double salary, string corps, HashSet<IAuxiliary> missions)
            : base(id, firstName, lastName, salary, corps)
        {
            this._missions = missions;
        }
    }
}