using System;

namespace Tuple
{
    public class Program
    {
        public static void Main()
        {
            var prersonInfo = Console.ReadLine().Split();
            var beerInfo = Console.ReadLine().Split();
            var bank = Console.ReadLine().Split();

            var name = prersonInfo[0] + " " + prersonInfo[1];
            var address = prersonInfo[2];
            var town = prersonInfo[3];

            Tuple<string, string, string> personTuple = new Tuple<string, string, string>(name, address, town);
            Console.WriteLine(personTuple);
            
            var nameBeer = beerInfo[0];
            var beers = int.Parse(beerInfo[1]);
            var drinkOrNot = beerInfo[2];
            bool isDrunk = !(drinkOrNot != "drunk");
            Tuple<string, int, bool> beerTuple = new Tuple<string, int, bool>(nameBeer, beers, isDrunk);
            Console.WriteLine(beerTuple);
            var nameOfPerson = bank[0];
            var accountBalance = double.Parse(bank[1]);
            var bankName = bank[2];

            Tuple<string, double, string> numberTuple = new Tuple<string, double, string>(nameOfPerson, accountBalance, bankName);
            Console.WriteLine(numberTuple);
        }
    }
}
