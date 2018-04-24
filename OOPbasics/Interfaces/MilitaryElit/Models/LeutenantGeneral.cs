using System.Collections.Generic;
using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class LuetenantGeneral : Private, ILeutenantGeneral
    {
        private HashSet<ISoldier> _privates;

        public HashSet<ISoldier> Privates => _privates;

        public void AddPrivate(ISoldier @private)
        {
            this._privates.Add(@private);
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendLine()
                .AppendLine($"Privates:");
            foreach (var @private in this.Privates)
            {
                sb.AppendLine(new string(' ', Helper.Indentation) + @private);
            }

            return sb.ToString().Trim();
        }

        public LuetenantGeneral(string id, string firstName, string lastName, double salary)
            : base(id, firstName, lastName, salary)
        {
            this._privates = new HashSet<ISoldier>();
        }
    }
}