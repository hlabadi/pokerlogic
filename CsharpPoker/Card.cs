using System;
using System.Collections.Generic;
using System.Text;

namespace CsharpPoker
{
    public class Card
    {
        public CardValue Value { get;}
        public CardSuit Suit { get; }
        public Card()
        {

        }

        public Card(CardValue value, CardSuit suit)
        {
            Value = value;
            Suit = suit;
        }

        public override string ToString() => $"{Value} of {Suit}";
    }
}
