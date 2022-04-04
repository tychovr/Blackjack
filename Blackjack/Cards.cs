namespace Blackjack
{
    class Cards
    {
        public void Card(int cardValue, string cardSuit)
        {
            int value = cardValue;
            string suit = cardSuit;
        }

        public enum cardSuit
        {
            Diamonds = 1,
            Clubs = 2,
            Spades = 3,
            Hearts = 4

        }

        public enum cardValue
        {
            one = 1,
            two = 2,
            three = 3,
            four = 4,
            five = 5,
            six = 6,
            seven = 7,
            eight = 8,
            nine = 9,
            jacks = 10,
            queen = 10,
            king = 10,
            ace = 11
        }


    }
}
