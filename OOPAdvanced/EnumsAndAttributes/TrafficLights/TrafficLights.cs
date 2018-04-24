using System;

namespace TrafficLights
{
    public class TrafficLights
    {
        private Lights signal;

      
        public string Signal
        {
            get { return this.signal.ToString(); }
            private set { Enum.TryParse(value, out signal); }
        }

        public void ToggleSignal()
        {
            var signals = typeof(Lights).GetEnumValues();
            this.signal = (Lights)signals.GetValue((int)(signal + 1) % signals.Length);
        }

        public override string ToString()
        {
            return this.Signal;
        }

        public TrafficLights(string signal)
        {
            this.Signal = signal;
        }
    }
}