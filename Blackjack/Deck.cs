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

                    Cards cards = new Cards(cardValue, valueInt, cardSuitName, valueSuit);
                    sortedDeck.Add(cards);
                }
            }
        }

        public void ShuffleDeck()
        {
            FillDeck();

            for (int i = 0; i <= 51; i++)
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
                        Console.Write("\nAdding " + shuffledDeck[i] + " to deck.....");
                        System.Threading.Thread.Sleep(50);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
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
                draw.Add(shuffledDeck[0]);
                shuffledDeck.RemoveAt(0);
            }

            return draw;
        }

        public void Print(int cardNumber)
        {
            Console.Write(" " + shuffledDeck[cardNumber]);
        }
    }
}



