using System;
using System.Collections.Generic;

public class CoffeeMachine
{
    private int coins;
    public void BuyCoffee(string price, string type)
    {
        CoffeeType coffeeType = (CoffeeType)Enum.Parse(typeof(CoffeeType), type);

        CoffeePrice coffeePrice = (CoffeePrice)Enum.Parse(typeof(CoffeePrice), price);

        if (this.coins >= (int)coffeePrice)
        {
            this.CoffeesSold = new List<CoffeeType>();
            this.CoffeesSold.Add(coffeeType);
            this.coins = 0;
        }
    }

    public void InsertCoin(string coin)
    {
        Coin rem = (Coin)Enum.Parse(typeof(Coin), coin);
        this.coins += (int)rem;
    }
    public List<CoffeeType> CoffeesSold { get; set; }

}
