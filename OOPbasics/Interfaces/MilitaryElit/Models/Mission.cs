using System;
using System.Text;
using MilitaryElit.Enums;
using MilitaryElit.Interfaces;

namespace MilitaryElit.Models
{
    class Mission : IAuxiliary
    {
        private string _codeName;
        private MissionState _missionState;

        public string CodeName
        {
            get { return this._codeName; }
            set { this._codeName = value; }
        }

        public MissionState MissionState
        {
            get { return this._missionState; }
            set { this._missionState = value; }
        }

        public void CompleteMission()
        {
            this.MissionState = MissionState.Finished;
        }

        public override string ToString()
        {
            var sb = new StringBuilder($"Code Name: {this.CodeName} State: {this.MissionState}");
            return sb.ToString();
        }

        public Mission(string codeName, string missionState)
        {
            this.CodeName = codeName;
            if (!Enum.TryParse(missionState, out _missionState))
                throw new ArgumentException("wrong mission state");
        }
    }
}