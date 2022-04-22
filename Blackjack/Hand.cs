namespace Blackjack
{
    internal class Hand
    {
        private Hand() { }
        private static Hand _instance;
        public static Hand GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Hand();
            }
            return _instance;
        }

        public List<Hand> dealerHand = new List<Hand>();
        public List<Hand> playerList = new List<Hand>();

        // hand object property's
        public List<Cards> CardDraw = new List<Cards>();
        public string PlayerName = "";
        public int Saldo = 0;
        public int Wins = 0;

        // variables in logic code
        public string tempPlayerName = "";

        public Hand(List<Cards> cardDraw, string playerName, int saldo, int wins)
        {
            CardDraw = cardDraw;
            PlayerName = playerName;
            Saldo = saldo;
            Wins = wins;
        }

        // Enter player names and 
        public void PlayerHand()
        {
            // Get instances
            Deck deck = Deck.GetInstance();
            Stats stats = Stats.GetInstance();

            int players = 0;

            for (int i = 0; i < 1;)
            {
                if (players < 10)
                {

                    if (players < 1)
                    {
                        Console.CursorTop = 0;
                        Console.CursorLeft = 0;
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("What is the name of player 1? (");
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("MAX 10");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine("):");
                        Console.ForegroundColor = ConsoleColor.Green;
                        tempPlayerName = Console.ReadLine();
                        tempPlayerName = tempPlayerName.TrimStart();
                        Console.ResetColor();

                        if (tempPlayerName == "")
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            Console.CursorLeft = 0;
                            Console.Write("                                                                                                                       ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nPlease enter a valid name!        ");
                            Console.CursorLeft = 26;
                            System.Threading.Thread.Sleep(3000);
                            Console.CursorLeft = 0;
                            Console.Write("                                    ");
                        }

                        else if (tempPlayerName.Length > 10)
                        {
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                            Console.CursorLeft = 0;
                            Console.Write("                                                                                                                       ");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\nDo not exceed the 10 character limit!        ");
                            Console.CursorLeft = 37;
                            System.Threading.Thread.Sleep(3000);
                            Console.CursorLeft = 0;
                            Console.Write("                                                    ");
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                        }

                        else
                        {
                            List<Cards> cards = null;
                            Hand player = new Hand(cards, tempPlayerName, 1000, 0);
                            playerList.Add(player);
                            players++;
                        }
                    }

                    else
                    {
                        Console.Write("\nDo you want to add another player? ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("(Y/N)\n");
                        Console.ResetColor();

                        var answer = Console.ReadKey().Key;
                        Console.CursorLeft = 0;
                        Console.Write("                                 ");
                        Console.CursorLeft = 0;
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);

                        if (answer == ConsoleKey.Y)
                        {
                            players++;
                            tempPlayerName = "";
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write("What is the name of player " + players + "? (");
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("MAX 10");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.WriteLine("):             ");
                            Console.ForegroundColor = ConsoleColor.Green;
                            players--;

                            for (int j = 0; j < 1;)
                            {
                                Console.CursorLeft = 0;
                                Console.ForegroundColor = ConsoleColor.Green;
                                tempPlayerName = Console.ReadLine();
                                tempPlayerName = tempPlayerName.TrimStart();
                                Console.ResetColor();

                                if (tempPlayerName == "")
                                {
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                    Console.CursorLeft = 0;
                                    Console.Write("                                                                                                                       ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\nPlease enter a valid name!        ");
                                    Console.CursorLeft = 26;
                                    System.Threading.Thread.Sleep(3000);
                                    Console.CursorLeft = 0;
                                    Console.Write("                                    ");
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                }

                                else if (tempPlayerName.Length > 10)
                                {
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                    Console.CursorLeft = 0;
                                    Console.Write("                                                                                                                       ");
                                    Console.ForegroundColor = ConsoleColor.Red;
                                    Console.Write("\nDo not exceed the 10 character limit!        ");
                                    Console.CursorLeft = 37;
                                    System.Threading.Thread.Sleep(3000);
                                    Console.CursorLeft = 0;
                                    Console.Write("                                                    ");
                                    Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                }

                                else
                                {
                                    var matches = playerList.Where(p => String.Equals(p.PlayerName, tempPlayerName, StringComparison.CurrentCulture));
                                    if (matches.Count() > 0)
                                    {
                                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                        Console.CursorLeft = 0;
                                        Console.Write("                                                                                                                       ");
                                        Console.ForegroundColor = ConsoleColor.Red;
                                        Console.Write("\nPlayer name already exists!        ");
                                        Console.CursorLeft = 27;
                                        System.Threading.Thread.Sleep(3000);
                                        Console.CursorLeft = 0;
                                        Console.Write("                                                    ");
                                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 1);
                                    }

                                    else
                                    {
                                        List<Cards> cards = deck.DrawCard(2);
                                        Hand player = new Hand(cards, tempPlayerName, 10000, 0);
                                        playerList.Add(player);
                                        players++;
                                        j++;
                                    }
                                }
                            }
                        }

                        else if (answer == ConsoleKey.N)
                        {
                            Console.Clear();
                            stats.showStats();
                            i++;

                            // Makes dealer
                            List<Cards> cards = deck.DrawCard(2);
                            Hand player = new Hand(cards, "Dealer", 10000, 0);
                            dealerHand.Add(player);
                        }

                        else
                        {
                            Console.CursorLeft = 0;
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.Write("\n\nInvalid input, please try again.");
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.CursorLeft = 32;
                            System.Threading.Thread.Sleep(3000);
                            Console.CursorLeft = 0;
                            Console.Write("                                 ");
                            Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop - 3);
                        }
                    }
                }

                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("You have reached the maximum amount of players.");
                    Console.ResetColor();

                    // Makes dealer
                    List<Cards> cards = deck.DrawCard(2);
                    Hand player = new Hand(cards, "Dealer", 10000, 0);
                    dealerHand.Add(player);

                    System.Threading.Thread.Sleep(3000);
                    i++;
                    Console.Clear();
                }
            }
        }
    }
}

