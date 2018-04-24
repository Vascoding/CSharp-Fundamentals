using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Card
{
    public class Program
    {
        public static void Main()
        {
            //var t = Console.ReadLine();

            //if (t == "Rank")
            //{
            //    var type = typeof(CardRank).GetCustomAttributes(typeof(TypeAttribute), false)[0];
            //    Console.WriteLine(type);
            //}
            //else
            //{
            //    var type = typeof(CardSuits).GetCustomAttributes(typeof(TypeAttribute), false)[0];
            //    Console.WriteLine(type);
            //}

            //var typeSuit = typeof(CardSuits).GetEnumNames();
            //var typeRanks = typeof(CardRank).GetEnumNames();
            //foreach (var suit in typeSuit)
            //{
            //    foreach (var rank in typeRanks)
            //    {
            //        Console.WriteLine($"{rank} of {suit}");
            //    }
            //}


            var firstPlayer = Console.ReadLine();
            var secondPlayer = Console.ReadLine();
            List<string> cardsOutOfDeck = new List<string>();
            Dictionary<string, List<Card>> first = new Dictionary<string, List<Card>>();
            Dictionary<string, List<Card>> second = new Dictionary<string, List<Card>>();
            var count = 0;
            while (true)
            {

                var takeCardFromDeck = Console.ReadLine();

                if (cardsOutOfDeck.Contains(takeCardFromDeck))
                {
                    Console.WriteLine("Card is not in the deck.");
                    continue;
                }
                var cardType = takeCardFromDeck.Split();
                CardRank cardRank;
                CardSuits cardSuit;
                if (!Enum.TryParse(cardType[0], out cardRank) || !Enum.TryParse(cardType[2], out cardSuit))
                {
                    Console.WriteLine("No such card exists.");
                }

                else
                {
                    if (first.ContainsKey(firstPlayer))
                    {
                        first[firstPlayer].Add(new Card(cardType[0], cardType[2]));
                    }
                    else
                    {
                        first.Add(firstPlayer, new List<Card>());
                        first[firstPlayer].Add(new Card(cardType[0], cardType[2]));
                    }
                    count++;
                    cardsOutOfDeck.Add(takeCardFromDeck);
                }
                if (count == 5)
                {
                    break;
                }
            }
            count = 0;
            while (true)
            {

                var takeCardFromDeck = Console.ReadLine();

                if (cardsOutOfDeck.Contains(takeCardFromDeck))
                {
                    Console.WriteLine("Card is not in the deck.");
                    continue;
                }
                var cardType = takeCardFromDeck.Split();
                CardRank cardRank;
                CardSuits cardSuit;
                if (!Enum.TryParse(cardType[0], out cardRank) || !Enum.TryParse(cardType[2], out cardSuit))
                {
                    Console.WriteLine("No such card exists.");
                }
                else
                {
                    if (second.ContainsKey(secondPlayer))
                    {
                        second[secondPlayer].Add(new Card(cardType[0], cardType[2]));
                    }
                    else
                    {
                        second.Add(secondPlayer, new List<Card>());
                        second[secondPlayer].Add(new Card(cardType[0], cardType[2]));
                    }
                    cardsOutOfDeck.Add(takeCardFromDeck);
                    count++;
                }
                if (count == 5)
                {
                    break;
                }
            }
            var firstP = first.Select(a => a.Value.Max(v => v.Power()));
            Card cardOne = null;
            Card cardTwo = null;
            foreach (var v in first.Values)
            {
                cardOne = v.Max();
            }
            foreach (var v in second.Values)
            {
                cardTwo = v.Max();
            }
            var rem = cardOne.CompareTo(cardTwo);
            if (rem < 0)
            {
                Console.WriteLine($"{secondPlayer} wins with {cardTwo}.");
            }
            else
            {
                Console.WriteLine($"{firstPlayer} wins with {cardOne}.");
            }
        }
    }
}
