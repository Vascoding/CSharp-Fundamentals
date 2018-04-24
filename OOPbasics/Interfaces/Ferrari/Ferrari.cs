namespace Ferrari
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Model = "488-Spider";
            this.Driver = driver;
        }
        public string Model { get; }
        public string Driver { get; }
        public string Breaks()
        {
            return "Brakes!";
        }

        public string PushTheGasPedal()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            return $"{this.Model}/{this.Breaks()}/{this.PushTheGasPedal()}/{this.Driver}";
        }
    }
}