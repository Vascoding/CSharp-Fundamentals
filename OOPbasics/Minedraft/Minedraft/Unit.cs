public abstract class Unit
{
    private string id;

    protected Unit(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get => this.id;
        set => this.id = value;
    }
}
