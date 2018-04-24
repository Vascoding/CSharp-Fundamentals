using System.Collections.Generic;

public class Garage
{
    private Dictionary<int, Car> parkedCars;
    public Garage()
    {
        this.parkedCars = new Dictionary<int, Car>();
    }

    public Dictionary<int, Car> ParkedCars
    {
        get { return this.parkedCars; }
        set { this.parkedCars = value; }
    }

    public void Tune(int tuneIndex, string addon)
    {
        foreach (Car car in this.parkedCars.Values)
        {
            car.Tune(tuneIndex, addon);
        }
    }
}

