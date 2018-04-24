using System.Text;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class Repair : IAuxiliary
    {
        private string _partName;
        private int _hoursWorked;

        public string PartName
        {
            get { return this._partName; }
            set { this._partName = value; }
        }

        public int HoursWorked
        {
            get { return this._hoursWorked; }
            set { this._hoursWorked = value; }
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"Part Name: {this.PartName} Hours Worked: {this.HoursWorked}");
            return sb.ToString();
        }

        public Repair(string partName, int hoursWorked)
        {
            this.PartName = partName;
            this.HoursWorked = hoursWorked;
        }
    }
}