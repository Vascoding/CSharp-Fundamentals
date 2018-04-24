namespace CarSalesman
{
    public class Car
    {
        private string weight = "n/a";
        private string color = "n/a";
        public string Model { get; set; }
        public Engine Engine { get; set; }

        public string Weight
        {
            get { return this.weight; }
            set
            {
                this.weight = value;
            }
        }

        public string Color
        {
            get { return this.color; }
            set
            {
                this.color = value;
            }
        }

    }
}
