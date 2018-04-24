using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    abstract class Soldier : ISoldier
    {
        private string _id;
        private string _firstName;
        private string _lastName;

        public string Id
        {
            get { return this._id; }
            set { this._id = value; }
        }

        public string FirstName
        {
            get { return this._firstName; }
            set { this._firstName = value; }
        }

        public string LastName
        {
            get { return this._lastName; }
            set { this._lastName = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"Name: {this.FirstName} {this.LastName} Id: {this.Id}");

            return sb.ToString();
        }

        protected Soldier(string id, string firstName, string lastName)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
        }
    }
}