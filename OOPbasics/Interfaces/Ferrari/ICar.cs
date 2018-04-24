namespace Ferrari
{
    public interface ICar
    {
        string Model { get; }
        string Driver { get; }

        string Breaks();
        string PushTheGasPedal();

    }
}