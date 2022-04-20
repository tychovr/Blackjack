namespace Blackjack
{
    internal class Game
    {
        // Get instances
        public string ActionCase = "";
        public ConsoleKeyInfo KeyInput;
        public string KeyInputCase = "";
        public string EmptyLeft = "                                                       ";

        // Fields
        public string CurrentPlayer = "";
        public int index = 0;
        public string Action = "";

        public static void Initialize()
        {
            Console.WriteLine("Initializing blackjack simulation.....");
            Deck deck = Deck.GetInstance();
            deck.ShuffleDeck();
            System.Threading.Thread.Sleep(3000);
        }

        public static void Intro()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("WELCOME TO ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("TYCHO'S ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("VIRTUAL BLACKJACK CASINO!");

            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }

        public static void Rules()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("THE RULES: \n");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("You have ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("$10000 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("to play with.");
            Console.Write("You can bet up to ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("$1000 ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("per hand.");
            Console.Write("You can only hit ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("once ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("per hand.");
            Console.Write("You can only stand ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("once ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("per hand.");
            Console.Write("You can only double down ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("once ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("per hand.");
            Console.Write("You can only split ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("once ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("per hand. \n");
        }

        public static void WinLose()
        {
            Console.Write("If you ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("lose ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("your bet is ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("lost.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("If you ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("win ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("your bet is ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("doubled. \n");
            Console.ForegroundColor = ConsoleColor.White;
        }

        public static void Controls()
        {
            Console.WriteLine("Use the, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'H' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("key to hit, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'S' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("key to stand, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'D' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("key to double down, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'Q' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("key to quit, ");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write("'X' ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("key to find a secret. \n\n");
        }

        public static void ToGame()
        {
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorLeft = 51;
            Console.CursorTop = 14;
            Console.WriteLine("Let the games begin!");
            System.Threading.Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Clear();
        }

        public void StartGame()
        {
            // Call instances
            Hand hand = Hand.GetInstance();
            Stats stats = Stats.GetInstance();

            // Deck UI
            Console.Clear();
            Console.SetCursorPosition(2, 1);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("----------------------------------------------------------------");
            Console.SetCursorPosition(2, 2);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 3);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 4);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 5);
            Console.Write("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(5, 1);
            Console.Write("Deck");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.SetCursorPosition(5, 3);
            Console.Write("Remaining cards in deck:");
            Console.SetCursorPosition(30, 3);
            Console.Write(Deck.GetInstance().shuffledDeck.Count());
            Console.SetCursorPosition(7, 4);
            Console.ForegroundColor = ConsoleColor.White;

            // Player UI
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(2, 7);
            Console.Write("----------------------------------------------------------------");
            Console.SetCursorPosition(2, 8);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 9);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 10);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 11);
            Console.Write("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(5, 7);
            Console.Write("Player's Hand & Bets");
            Console.ForegroundColor = ConsoleColor.White;

            // Dealer UI
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(2, 13);
            Console.Write("----------------------------------------------------------------");
            Console.SetCursorPosition(2, 14);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 15);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 16);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 17);
            Console.Write("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(5, 13);
            Console.Write("Dealer's Hand");
            Console.ForegroundColor = ConsoleColor.White;

            // Possible actions UI
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(2, 19);
            Console.Write("----------------------------------------------------------------");
            Console.SetCursorPosition(2, 20);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 21);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 22);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 23);
            Console.Write("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(5, 19);
            Console.Write("Actions");
            Console.ForegroundColor = ConsoleColor.White;

            // Comments
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.SetCursorPosition(2, 24);
            Console.Write("----------------------------------------------------------------");
            Console.SetCursorPosition(2, 25);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 26);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 27);
            Console.Write("|                                                              |");
            Console.SetCursorPosition(2, 28);
            Console.Write("----------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.SetCursorPosition(5, 24);
            Console.Write("Comments");
            Console.ForegroundColor = ConsoleColor.White;

            // Game log
            int tempTop = Console.CursorTop = hand.playerList.Count() + 6;

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.CursorLeft = 75;
            Console.CursorTop = hand.playerList.Count() + 6;
            Console.Write("-----------------------------------------");

            for (int i = 27; i > hand.playerList.Count() && i > tempTop; i--)
            {
                Console.CursorLeft = 75;
                Console.CursorTop = i;
                Console.Write("|                                       |");
            }

            Console.SetCursorPosition(75, 28);
            Console.Write("-----------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.CursorLeft = 78;
            Console.CursorTop = hand.playerList.Count() + 6;
            Console.Write("Game Log");
            Console.ForegroundColor = ConsoleColor.White;
            Console.CursorLeft = 78;
            Console.CursorTop = hand.playerList.Count() + 8;
            Console.Write(">>");
            stats.showStats();
        }

        // Deck on 5, 3
        // Player's hand & bets on 5, 9
        // Dealer's hand on 5, 13
        // Actions on 5, 19
        // Comments on 5, 26
        // Command input on 81, playerList.Count() + 6 | (game log)
        // Game log on 78, playerList.Count() + 8 and further
        public void Blackjack()
        {
            // Get instances
            Hand hand = Hand.GetInstance();
            Stats stats = Stats.GetInstance();

            // Input Fields
            string CommandInput = "";
            int CommandInputNums = 0;

            // Temp memory fields
            int Bet = 0;

            for (int i = 0; i < 1;)
            {
                // Start 2nd thread for key's
                Thread ActionsThread = new Thread(new ThreadStart(PossibleActions));
                ActionsThread.Start();

                // Possible Actions Introduction
                Console.SetCursorPosition(5, 21);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 21);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("q");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Quit | ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("x");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Secret");
                ActionCase = "1";

                // Comment Introduction
                CurrentPlayer = hand.playerList[index].PlayerName;
                Console.SetCursorPosition(5, 26);
                Console.Write("It's ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CurrentPlayer + "'s ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("turn!                  ");

                // Player's Hand & Bets
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(5, 7);
                Console.Write("P------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(5, 7);
                Console.Write(hand.playerList[index].PlayerName + "'s Hand & Bets");
                Console.SetCursorPosition(5, 9);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 9);
                Console.ForegroundColor = ConsoleColor.White;
                Thread.Sleep(3000);

                // No actions for ReadLine, omdat ja
                ActionCase = "0";
                Console.SetCursorPosition(5, 21);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("No actions available.                                   ");

                // Comment + Input Bet
                for (int j = 0; j < 1;)
                {
                    Console.SetCursorPosition(5, 26);
                    Console.Write("How much do you want to bet? (");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("Max $1000");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(")        ");
                    Console.CursorLeft = 81;
                    Console.CursorTop = hand.playerList.Count() + 8;
                    Console.ForegroundColor = ConsoleColor.Green;
                    CommandInputNums = Convert.ToInt32(Console.ReadLine());
                    Console.ForegroundColor = ConsoleColor.White;

                    if (CommandInputNums > 1000)
                    {
                        Console.CursorLeft = 81;
                        Console.CursorTop = hand.playerList.Count() + 8;
                        Console.Write("           ");
                        Console.SetCursorPosition(5, 26);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You can't bet more than $1000!           ");
                        Console.SetCursorPosition(119, 29);
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(3000);
                    }
                    else if (CommandInputNums < 10)
                    {
                        Console.CursorLeft = 81;
                        Console.CursorTop = hand.playerList.Count() + 8;
                        Console.Write("           ");
                        Console.SetCursorPosition(5, 26);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You can't bet less than $10!              ");
                        Console.SetCursorPosition(119, 29);
                        Console.ForegroundColor = ConsoleColor.White;
                        Thread.Sleep(3000);
                    }
                    else
                    {
                        Console.CursorLeft = 81;
                        Console.CursorTop = hand.playerList.Count() + 8;
                        Console.Write("           ");
                        Bet = CommandInputNums;
                        Console.SetCursorPosition(5, 26);
                        Console.Write("You bet is ");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.Write("$" + Bet);
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("!                                         ");
                        hand.playerList[index].Saldo -= Bet;
                        stats.ChangeStats(index);
                        Console.SetCursorPosition(119, 29);

                        // Possible Actions Introduction - Round
                        Console.SetCursorPosition(5, 21);
                        Console.Write(EmptyLeft);
                        Console.SetCursorPosition(5, 21);
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("q");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(": Quit | ");
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write("x");
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(": Secret");
                        ActionCase = "1";
                        Console.SetCursorPosition(119, 29);

                        Thread.Sleep(3000);
                        j++;
                    }
                }

                // Comment Round Start
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Choose one of the actions above!           ");

                // Possible Actions Round
                Console.SetCursorPosition(5, 21);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 21);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("h");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Hit | ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("s");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Stand | ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("d");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Double Down | ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("q");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Quit | ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("x");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Secret");

                // Input Action
                ActionCase = "2";
                Console.CursorLeft = 81;
                Console.CursorTop = hand.playerList.Count() + 8;
                Console.ForegroundColor = ConsoleColor.Green;
                KeyInput = Console.ReadKey();
                Console.CursorLeft = 81;
                Console.CursorTop = hand.playerList.Count() + 8;
                Console.Write("           ");
                KeyInputCase = KeyInput.KeyChar.ToString();
                Thread.Sleep(3000);
            }
        }

        public void PossibleActions()
        {
            // Get instances
            Hand hand = Hand.GetInstance();
            Deck deck = Deck.GetInstance();

            // Local fields
            List<Cards> Card = new List<Cards>();
            string SuitName = "";

            if (KeyInputCase != null)
            {
                switch
                    (ActionCase)
                {
                    // Case 1, game nog niet begonnen, bet invullen.
                    case "1":
                        switch (KeyInputCase)
                        {
                            case "q":
                                Thread.Sleep(10);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(5, 3);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 9);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 15);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 21);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 26);
                                Console.Write("Quitting blackjack.....                ");
                                Console.CursorLeft = 28;
                                Thread.Sleep(3000);
                                Console.Clear();
                                Console.SetCursorPosition(45, 15);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Quitted blackjack succesfully.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(0, 29);
                                System.Environment.Exit(0);
                                break;

                            case "x":
                                // Nog geen idee, maar hier komt de easter egg puzzel
                                break;

                            default:
                                Console.SetCursorPosition(5, 24);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Invalid input!                          ");
                                Console.SetCursorPosition(119, 29);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(3000);
                                break;
                        }
                        break;

                    // Case 2, blackjack begonnen, nog geen kaart gepakt.
                    case "2":
                        switch (KeyInputCase)
                        {
                            case "h":
                                // Comment
                                Console.SetCursorPosition(5, 26);
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(CurrentPlayer);
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.Write(" hits.                                  ");

                                // Get new card and add to hand

                                Card = deck.DrawCard(1);
                                hand.playerList[index].CardDraw.Add(Card[0]);
                                Console.SetCursorPosition(5, 11);
                                Console.Write(EmptyLeft);
                                Console.SetCursorPosition(5, 11);
                                for (int i = 0; i < hand.playerList[index].CardDraw.Count(); i++)
                                {
                                    SuitName = hand.playerList[index].CardDraw[i].SuitName.ToString();
                                    Console.Write(hand.playerList[index].CardDraw[i].ValueName.ToString() + " of " + SuitName + " | ");
                                }
                                Console.SetCursorPosition(119, 29);
                                ActionCase = "1";
                                Thread.Sleep(3000);
                                ActionCase = "3";
                                break;

                            case "s":
                                // Hier komt stand
                                break;

                            case "d":
                                // Hier komt double down
                                break;

                            case "q":
                                Thread.Sleep(10);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(5, 3);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 9);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 15);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 21);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 26);
                                Console.Write("Quitting blackjack.....                ");
                                Console.CursorLeft = 28;
                                Thread.Sleep(3000);
                                Console.Clear();
                                Console.SetCursorPosition(45, 15);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Quitted blackjack succesfully.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(0, 29);
                                System.Environment.Exit(0);
                                break;

                            case "x":
                                // Hier komt secret
                                break;

                            default:
                                Console.SetCursorPosition(5, 26);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Invalid input!                          ");
                                Console.SetCursorPosition(119, 29);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(3000);
                                break;
                        }
                        break;

                    // Case 3, na 1 kaart pakken (Geen Double Down)
                    case "3":
                        switch (KeyInputCase)
                        {
                            case "h":
                                break;

                            case "s":
                                // Hier komt stand
                                break;

                            case "q":
                                Thread.Sleep(10);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.SetCursorPosition(5, 3);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 9);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 15);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 21);
                                Console.Write("Quitting blackjack.....                ");
                                Console.SetCursorPosition(5, 26);
                                Console.Write("Quitting blackjack.....                ");
                                Console.CursorLeft = 28;
                                Thread.Sleep(3000);
                                Console.Clear();
                                Console.SetCursorPosition(45, 15);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Quitted blackjack succesfully.");
                                Console.ForegroundColor = ConsoleColor.White;
                                Console.SetCursorPosition(0, 29);
                                System.Environment.Exit(0);
                                break;

                            case "x":
                                // Hier komt secret
                                break;

                            default:
                                Console.SetCursorPosition(5, 26);
                                Console.ForegroundColor = ConsoleColor.Red;
                                Console.Write("Invalid input!                          ");
                                Console.SetCursorPosition(119, 29);
                                Console.ForegroundColor = ConsoleColor.White;
                                Thread.Sleep(3000);
                                break;
                        }
                        break;
                        KeyInputCase = "";
                }
            }
        }

        public void Hit()
        {
            Console.WriteLine("Test");
        }
    }
}

