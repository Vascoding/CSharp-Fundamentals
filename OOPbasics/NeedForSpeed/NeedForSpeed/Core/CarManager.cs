using System.Collections.Generic;

public class CarManager
{
    private Dictionary<int, Car> cars;
    private Dictionary<int, Race> races;
    private Garage garage;
    public CarManager()
    {
        this.cars = new Dictionary<int, Car>();
        this.races = new Dictionary<int, Race>();
        this.garage = new Garage();
    }

    public void Register(int id, string type, string brand, string model, int yearOfProduction, int horsepower, int acceleration, int suspension, int durability)
    {
        this.cars.Add(id, CarFactory.CreateCar(type, brand, model, yearOfProduction, horsepower, acceleration, suspension, durability));
    }

    public string Check(int id)
    {
        return this.cars[id].ToString();
    }

    public void Open(int id, string type, int length, string route, int prizePool, int specialParam)
    {
        this.races.Add(id, RaceFactory.CreateRace(type, length, route, prizePool, specialParam));
    }

    public void Participate(int carId, int raceId)
    {
        if (!this.garage.ParkedCars.ContainsKey(carId))
        {
            this.races[raceId].AddParticipant(this.cars[carId]);
        }
    }

    public string Start(int id)
    {
        if (this.races[id].GetParticipans().Count != 0)
        {
            this.races[id].StartRace();
            return this.races[id].ToString();
        }
        return "Cannot start the race with zero participants.";
    }

    public void Park(int id)
    {
        var isValid = true;
        foreach (var race in this.races.Values)
        {
            foreach (var car in race.GetParticipans())
            {
                if (this.cars[id] == car && race.IsOpen)
                {
                    isValid = false;
                }
            }
        }

        if (isValid)
        {
            this.garage.ParkedCars.Add(id, this.cars[id]);
        }
    }

    public void Unpark(int id)
    {
        this.garage.ParkedCars.Remove(id);
    }

    public void Tune(int tuneIndex, string addOn)
    {
        if (this.garage.ParkedCars.Count != 0)
        {
            this.garage.Tune(tuneIndex, addOn);
        }
    }
}

