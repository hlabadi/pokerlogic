using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;


namespace CsharpPoker
{
    public class Hand
    {
        public Hand()
        {
            Cards = new List<Card>();
        }
        public List<Card> Cards { get; }

        public void Draw(Card card)
        {
            Cards.Add(card);
        }
        public HandRank GetHandRank()
        {
            if (Cards.All(x => x.Suit == Cards.First().Suit))
            {
                if ((int)Cards.OrderBy(x => x.Value).First().Value >= 10)
                {
                    return HandRank.RoyalFlush;
                }
                return HandRank.Flush;
            }
            if (Cards.OrderBy(x => x.Value).Average((x => (int)x.Value)) == (int)Cards.OrderBy(x => x.Value).ElementAt(2).Value && Cards.GroupBy(x=>x.Value).Count()==5)
                return HandRank.Straight;
            if (Cards.GroupBy(x => x.Value).Count() == 2)
                if (Cards.GroupBy(x => x.Value).First().Count()==4 || Cards.GroupBy(x => x.Value).First().Count() == 1)
                    return HandRank.FourOfAKind;
                else
                    return HandRank.FullHouse;
            if (Cards.GroupBy(x => x.Value).Count() ==3)
                return HandRank.ThreeOfAKind;
            if (Cards.GroupBy(x => x.Value).Count() ==4)
                return HandRank.Pair;
            return HandRank.HighCard;
        }

        public Card HighCard() => Cards.OrderByDescending(x => x.Value).First();
    }
}
