namespace Blackjack
{
    internal class Deck
    {
        private Deck() { }
        private static Deck _instance;
        public static Deck GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Deck();
            }
            return _instance;
        }

        public List<Cards> sortedDeck = new List<Cards>(52);
        public List<Cards> shuffledDeck = new List<Cards>(52);
        public bool Initiate = true;

        public void FillDeck()
        {

            for (int i = 1; i <= 4; i++)
            {
                int valueSuit = i;
                var cardSuitValue = (Cards.cardSuit)i;
                string cardSuitName = cardSuitValue.ToString();

                for (int j = 1; j <= 13; j++)
                {
                    int valueInt = j;
                    var cardIntValue = (Cards.cardValue)j;
                    string cardValue = cardIntValue.ToString();

                    string CardName = "";
                    string CardSuit = "";
                    string newCardName = " ";

                    string SwitchCaseValue = valueInt.ToString();
                    string SwitchCaseSuit = valueSuit.ToString();

                    switch (SwitchCaseValue)
                    {
                        case "1":
                            CardName = "2";
                            break;

                        case "2":
                            CardName = "3";
                            break;

                        case "3":
                            CardName = "4";
                            break;

                        case "4":
                            CardName = "5";
                            break;

                        case "5":
                            CardName = "6";
                            break;

                        case "6":
                            CardName = "7";
                            break;

                        case "7":
                            CardName = "8";
                            break;

                        case "8":
                            CardName = "9";
                            break;

                        case "9":
                            CardName = "10";
                            break;

                        case "10":
                            CardName = "j";
                            break;

                        case "11":
                            CardName = "q";
                            break;

                        case "12":
                            CardName = "k";
                            break;

                        case "13":
                            CardName = "a";
                            break;
                    }

                    switch (SwitchCaseSuit)
                    {
                        case "1":
                            CardSuit = "♦";
                            break;

                        case "2":
                            CardSuit = "♣";
                            break;

                        case "3":
                            CardSuit = "♠";
                            break;

                        case "4":
                            CardSuit = "♥";
                            break;
                    }

                    newCardName = CardName + CardSuit;

                    Cards cards = new Cards(cardValue, valueInt, cardSuitName, valueSuit, newCardName);
                    sortedDeck.Add(cards);
                }
            }
        }

        public void ShuffleDeck()
        {
            int Index = 0;
            FillDeck();

            for (int i = 0; i != sortedDeck.Count();)
            {

                Random randomIndex = new Random();
                {
                    int random = randomIndex.Next(sortedDeck.Count);
                    shuffledDeck.Add(sortedDeck[random]);
                    sortedDeck.RemoveAt(random);
                    System.Threading.Thread.Sleep(10);

                    // Shows adding .... to deck at initialization.

                    if (Initiate == true)
                    {
                        Console.Write("\r");
                        Console.Write("\nAdding " + shuffledDeck[Index] + " to deck.....");
                        System.Threading.Thread.Sleep(50);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        Index++;
                    }
                }
            }

            // Loading Screen for simulation during initialization.
            if (Initiate == true)
            {
                Console.Clear();
                Console.WriteLine("Initializing blackjack simulation..... \n");
                Console.CursorLeft = 46;
                Console.Write("Loading in simulation.....\n\n");

                Console.CursorLeft = 9;
                Console.Write("[");
                Console.CursorLeft = 109;
                Console.Write("]");

                for (int i = 10; i <= 108; i++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.CursorLeft = i;
                    System.Threading.Thread.Sleep(30);
                    Console.Write("#");
                    Console.CursorLeft = 58;
                    i = i - 8;
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(i + "%");
                    i = i + 8;
                }

                System.Threading.Thread.Sleep(300);
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("\n");
                Console.CursorLeft = 50;
                Console.WriteLine("Simulation loaded.");
            }

            Initiate = false;
        }

        public List<Cards> DrawCard(int amount)
        {
            List<Cards> draw = new List<Cards>(amount);
            for (int i = 0; i < amount; i++)
            {
                if (shuffledDeck.Count == 0)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.SetCursorPosition(5, 26);
                        Console.Write("                          ");
                        Console.SetCursorPosition(5, 26);
                        Console.Write("Shuffling deck");

                        for (int k = 0; k < 4; k++)
                        {
                            Console.Write(".");
                            Thread.Sleep(300);
                        }
                    }

                    ShuffleDeck();
                }

                draw.Add(shuffledDeck[0]);
                shuffledDeck.RemoveAt(0);
            }

            return draw;
        }

        public void PlayerGetDeck()
        {
            Hand hand = Hand.GetInstance();
            Deck deck = Deck.GetInstance();
            Game game = Game.GetInstance();

            List<Cards> Card = new List<Cards>();

            Card = deck.DrawCard(2);
            hand.playerList[game.index].CardDraw.Add(Card[0]);
            game.GameLogSection(0);
            game.DeckSection(0);
            hand.playerList[game.index].CardDraw.Add(Card[1]);
            game.GameLogSection(0);
            game.DeckSection(0);
        }

        public void Dealer(int Scenario)
        {
            Hand hand = Hand.GetInstance();
            Deck deck = Deck.GetInstance();
            Game game = Game.GetInstance();

            List<Cards> Card = new List<Cards>();

            if (Scenario == 0) // Get first card from deck
            {
                Card = deck.DrawCard(1);
                hand.dealerHand[0].CardDraw.Add(Card[0]);
                game.GameLogSection(1);
                game.DeckSection(0);
            }
        }
    }
}



