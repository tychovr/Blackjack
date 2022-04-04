using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blackjack
{
    class Deck
    {

        static void Main(string[] args)
        {
            FillDeck();
        }




        public static void FillDeck()
        {
            List<Deck> decks = new List<Deck>();

            for (int i = 1; i <= 4; i++)
            {
                int value = i;
                var cardSuitValue = (Cards.cardSuit)i;
                string cardSuit = cardSuitValue.ToString();
                Console.WriteLine(cardSuit);

                for (int j = 0; j <= 13; j++)
                {

                }
            }
        }
    }
}



