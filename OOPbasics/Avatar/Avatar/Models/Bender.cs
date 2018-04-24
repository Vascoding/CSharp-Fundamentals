public abstract class Bender
{
    private string name;
    private int power;

    public Bender(string name, int power)
    {
        this.Name = name;
        this.power = power;
    }
    public string Name
    {
        get { return this.name; }
        set { this.name = value; }
    }

    public int Power
    {
        get { return this.power; }
        set { this.power = value; }
    }

    public abstract double TotalPower();

    public override string ToString()
    {
        return "";
    }
}