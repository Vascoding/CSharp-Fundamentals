using System;
using System.Collections.Generic;
using System.Linq;

namespace Card
{
    public class Card : IComparable<Card>
    {
        private string cardRank;
        private string cardSuit;
        
        public Card(string cardRank, string cardSuit)
        {
            this.cardRank = cardRank;
            this.cardSuit = cardSuit;
        }

        
        public int Power()
        {
            CardSuits cardSuit = (CardSuits)Enum.Parse(typeof(CardSuits), this.cardSuit);
            CardRank cardRank = (CardRank) Enum.Parse(typeof(CardRank), this.cardRank);

            return (int) (cardSuit) + (int) (cardRank);
        }
    
        public int CompareTo(Card other)
        {
            if (ReferenceEquals(this, other))
            {
                return 0;
            }
            if (ReferenceEquals(null, other))
            {
                return 1;
            }
            var cardPower = this.Power().CompareTo(other.Power());
            
            return cardPower;
        }

        public override string ToString()
        {
            return $"{this.cardRank} of {this.cardSuit}";
        }

       
    }
}