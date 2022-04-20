namespace Blackjack
{
    class Cards
    {
        public string ValueName;
        public string SuitName;
        public int ValueInt;
        public int SuitInt;

        public bool Initiate { get; set; } = true;

        public Cards(string valueName, int valueInt, string suitName, int suitInt)
        {
            ValueName = valueName;
            ValueInt = valueInt;
            SuitName = suitName;
            SuitInt = suitInt;
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
            Two = 1,
            Three = 2,
            Four = 3,
            Five = 4,
            Six = 5,
            Seven = 6,
            Eight = 7,
            Nine = 8,
            Ten = 9,
            Jacks = 10,
            Queen = 11,
            King = 12,
            Ace = 13
        }

        public override string ToString()
        {
            return ValueName + " of " + SuitName;
        }
    }
}
