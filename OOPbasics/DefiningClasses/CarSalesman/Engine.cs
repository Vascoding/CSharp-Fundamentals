namespace CarSalesman
{
    public class Engine
    {
        private string displacement = "n/a";
        private string efficiancy = "n/a";
        public string Model { get; set; }
        public int Power { get; set; }

        public string Displacement
        {
            get { return this.displacement; }
            set
            {
                this.displacement = value;
            }
        }

        public string Efficiency
        {
            get { return this.efficiancy; }
            set
            {
                this.efficiancy = value;
            }
        }
    }
}
