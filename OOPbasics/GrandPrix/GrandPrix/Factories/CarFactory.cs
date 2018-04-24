public class CarFactory
{
    public static Car CreateCar(int hp, double fuelAmount, Tyre tyre)
    {
        return new Car(hp, fuelAmount, tyre);
    }
}

