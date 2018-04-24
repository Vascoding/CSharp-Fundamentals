namespace FoodShortage
{
    public interface IBuyer
    {
        void BuyFood();
        int Food { get; }
        string Name { get; }
    }
}