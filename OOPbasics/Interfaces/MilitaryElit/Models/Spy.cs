using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class Spy : Soldier, ISpy
    {
        private string _codeNumber;

        public string CodeNumber
        {
            get { return this._codeNumber; }
            set { this._codeNumber = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder(base.ToString());

            sb.AppendLine()
                .Append($"Code Number: {this.CodeNumber.TrimStart(new char[] { '0' })}");

            return sb.ToString();
        }

        public Spy(string id, string firstName, string lastName, string codeNumber)
            : base(id, firstName, lastName)
        {
            this.CodeNumber = codeNumber;
        }
    }
}