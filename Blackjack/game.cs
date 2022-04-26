namespace Blackjack
{
    internal class Game
    {

        private Game() { }
        private static Game _instance;
        public static Game GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Game();
            }
            return _instance;
        }

        // Get instances
        public string ActionCase = "";
        public ConsoleKeyInfo KeyInput;
        public string KeyInputCase = "";
        public string EmptyLeft = "                                                        ";
        public string EmptyRight = "                                                        ";

        // Input fields
        public int CommandInputNums = 0;
        public string CommandInput = "";

        // Fields
        public string CurrentPlayer = "";
        public int index = 0;
        public string Action = "";
        public bool DefaultCase = false;
        public string CardTransfer = "";
        public int GameLog = 0;
        public int Bet = 0;
        public int valueInt = 0;
        public int totalValue = 0;
        public int totalValue2 = 0;

        // Lists
        public List<Cards> Card = new List<Cards>();


        public static void Initialize()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.Title = "Tycho's blackjack simulation";
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
            Deck deck = Deck.GetInstance();

            for (int i = 0; i < 1;)
            {
                PlayerHandSection(0); // Player's hand hidden
                DealerHandSection(0); // Dealer's hand hidden
                CommentSection(0); // Announce player
                ActionSection(0); // No actions available
                DeckSection(0); // Show deck count
                deck.PlayerGetDeck(); // Player get cards before round
                deck.Dealer(0); // Dealer get cards

                Console.SetCursorPosition(119, 29);
                Thread.Sleep(3000);

                CommentSection(1); // Comment + input bet

                // Start round
                CommentSection(2); // Choose action
                PlayerHandSection(1); // Player's hand shown
                DealerHandSection(1); // Dealer's hand shown
                ActionSection(1); // Available actions (hit, stand, double down, quit, secret)

                // Input Action
                ActionCase = "2";
                GetKeyInput();
                PossibleActions();
                Thread.Sleep(3000);

                if (totalValue2 <= 17) // dealer hit
                {
                    DealerHandSection(3);
                }

                else if (totalValue2 >= 18) // dealer stand
                {
                    DealerHandSection(3);
                }

                /* 
                Hit afmaken, hoger dan 21, lose round
                Aan andere actions beginnen
                Dealer speelt nadat player action heeft gedaan, tenzij player lose
                Object reference not set for blackjack() and PlayerGetDeck()
                */
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
            int totalValue = 0;
            int valueInt = 0;

            if (KeyInputCase != null)
            {
                switch
                    (ActionCase)
                {
                    // Case 1, niet meer nodig denk ik?
                    case "1":
                        switch (KeyInputCase)
                        {
                            case "q":
                                Quit();
                                break;

                            case "x":
                                Secret();
                                break;

                            default:
                                CommentSection(2);
                                break;
                        }
                        break;

                    // Case 2, blackjack begonnen, nog geen kaart gepakt.
                    case "2":
                        switch (KeyInputCase)
                        {
                            case "h":
                                Hit();
                                break;

                            case "s":
                                Stand();
                                break;

                            case "d":
                                DoubleDown();
                                break;

                            case "q":
                                Quit();
                                break;

                            case "x":
                                Secret();
                                break;

                            default:
                                CommentSection(2);
                                break;
                        }
                        break;

                    // Case 3, na 1 kaart pakken (Geen Double Down)
                    case "3":
                        switch (KeyInputCase)
                        {
                            case "h":
                                Hit();
                                break;

                            case "s":
                                Stand();
                                break;

                            case "q":
                                Quit();
                                break;

                            case "x":
                                Secret();
                                break;

                            default:
                                CommentSection(2);
                                break;
                        }
                        break;
                }
            }
        }


        // Section based methods (Comments, actions, dealer hand, player hand, deck)
        public void CommentSection(int Scenario)
        {
            Hand hand = Hand.GetInstance();
            Stats stats = Stats.GetInstance();

            if (Scenario == 0) // Players turn
            {
                CurrentPlayer = hand.playerList[index].PlayerName;
                Console.SetCursorPosition(5, 26);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 26);
                Console.Write("It's ");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(CurrentPlayer + "'s ");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("turn!");
            }

            else if (Scenario == 1) // Bet + input
            {
                for (int j = 0; j < 1;)
                {
                    Console.ForegroundColor = ConsoleColor.White;
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

                    else if (CommandInputNums > hand.playerList[index].Saldo)
                    {
                        Console.CursorLeft = 81;
                        Console.CursorTop = hand.playerList.Count() + 8;
                        Console.Write("           ");
                        Console.SetCursorPosition(5, 26);
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write("You do not have enough money!              ");
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
                        j++;
                    }
                }
            }

            else if (Scenario == 2)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Choose one of the actions above!           ");
            }

            else if (Scenario == 3)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Invalid input!                          ");
                Console.SetCursorPosition(119, 29);
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (Scenario == 4)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Dealer hit!                                 ");
                Console.SetCursorPosition(119, 29);
            }

            else if (Scenario == 5)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("Dealer stands!               ");
                Console.SetCursorPosition(119, 29);
            }

            else if (Scenario == 6)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(hand.playerList[index].PlayerName + "went over 21 points and lost!              ");
                Console.SetCursorPosition(119, 29);
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (Scenario == 7)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Dealer went over 21 points " + hand.playerList[index].PlayerName + " won!");
                Console.SetCursorPosition(119, 29);
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (Scenario == 8)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Dealer and " + hand.playerList[index].PlayerName + " both stayed at " + totalValue + " points and tied!");
                Console.SetCursorPosition(119, 29);
                Console.ForegroundColor = ConsoleColor.White;
            }

            else if (Scenario == 9)
            {
                Console.SetCursorPosition(5, 26);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("Dealer and " + hand.playerList[index].PlayerName + " both have blackjack and tied!");
                Console.SetCursorPosition(119, 29);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void ActionSection(int Scenario)
        {
            Console.ForegroundColor = ConsoleColor.White;

            if (Scenario == 0)
            {
                Console.SetCursorPosition(5, 21);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 21);
                Console.Write("No actions available.");
            }

            else if (Scenario == 1)
            {
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
            }

            else if (Scenario == 2)
            {
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
                Console.Write("q");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Quit | ");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write("x");
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(": Secret");
            }
        }

        public void PlayerHandSection(int Scenario)
        {
            Hand hand = Hand.GetInstance();

            if (Scenario == 0) // Hand hidden
            {
                // Change section (Player's) to actual username
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.SetCursorPosition(5, 7);
                Console.Write("-------------------------------");
                Console.ForegroundColor = ConsoleColor.Green;
                Console.SetCursorPosition(5, 7);
                Console.Write(hand.playerList[index].PlayerName + "'s Hand & Bets");
                Console.SetCursorPosition(119, 29);

                // Hand hidden
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(5, 9);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 9);
                Console.Write("Hand hidden.");
            }

            else if (Scenario == 1) // Hand shown + update
            {
                int suitValue = 0;
                int totalValue = 0;
                int valueInt = 0;

                Console.SetCursorPosition(5, 9);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 9);

                for (int n = 0; n < hand.playerList[index].CardDraw.Count(); n++)
                {
                    suitValue = hand.playerList[index].CardDraw[n].SuitInt;

                    if (suitValue == 1 || suitValue == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if (suitValue == 2 || suitValue == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    if (hand.playerList[index].CardDraw[n].ValueInt >= 11 && hand.playerList[index].CardDraw[n].ValueInt <= 12)
                    {
                        valueInt = 10;
                    }

                    else if (hand.playerList[index].CardDraw[n].ValueInt == 13 && hand.playerList[index].CardDraw.Count() == 2)
                    {
                        valueInt = 11;
                    }

                    else if (hand.playerList[index].CardDraw[n].ValueInt == 13 && hand.playerList[index].CardDraw.Count() != 2)
                    {
                        valueInt = 1;
                    }

                    else
                    {
                        valueInt = hand.playerList[index].CardDraw[n].ValueInt;
                    }

                    totalValue = totalValue + valueInt;
                    Console.Write(hand.playerList[index].CardDraw[n].CardName);
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.Write(", ");
                }

                Console.ForegroundColor = ConsoleColor.White;
                Console.Write("(" + totalValue + "), (");
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("$" + Bet);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(")");
            }
        }

        public void DealerHandSection(int Scenario)
        {
            Hand hand = Hand.GetInstance();

            if (Scenario == 0) // Hand hidden
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.SetCursorPosition(5, 15);
                Console.Write(EmptyLeft);
                Console.SetCursorPosition(5, 15);
                Console.Write("Hand hidden.");
            }

            else if (Scenario == 1) // Show first card, hide second and total
            {
                int valueInt2 = 0;

                Console.SetCursorPosition(5, 15);
                int suitValue = hand.dealerHand[0].CardDraw[0].SuitInt;

                if (suitValue == 1 || suitValue == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                else if (suitValue == 2 || suitValue == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (hand.dealerHand[0].CardDraw[0].ValueInt >= 11)
                {
                    valueInt2 = 10;
                }

                else
                {
                    valueInt2 = hand.dealerHand[0].CardDraw[0].ValueInt;
                }

                totalValue2 = valueInt2 + totalValue2;
                Console.Write(hand.dealerHand[index].CardDraw[0].CardName);
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(", xX, (hidden)");
            }

            else if (Scenario == 2) // Show full hand + total
            {
                int valueInt2 = 0;
                int totalValue2 = 0;

                Console.SetCursorPosition(5, 15);
                for (int n = 0; n < hand.dealerHand[0].CardDraw.Count(); n++)
                {
                    int suitValue = hand.dealerHand[0].CardDraw[n].SuitInt;

                    if (suitValue == 1 || suitValue == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if (suitValue == 2 || suitValue == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    if (hand.dealerHand[0].CardDraw[n].ValueInt >= 11)
                    {
                        valueInt2 = 10;
                    }

                    else
                    {
                        valueInt2 = hand.dealerHand[0].CardDraw[n].ValueInt;
                    }

                    totalValue2 = valueInt2 + totalValue2;
                    Console.Write(hand.dealerHand[index].CardDraw[n].CardName + ", ");
                }
            }

            else if (Scenario == 3) // Hit
            {

            }

            else if (Scenario == 4) // Stand
            {

            }
        }

        public void DeckSection(int Scenario)
        {
            if (Scenario == 0) // Show deck count)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.SetCursorPosition(5, 3);
                Console.Write("Remaining cards in deck:");
                Console.SetCursorPosition(30, 3);
                Console.Write(Deck.GetInstance().shuffledDeck.Count());
                Console.SetCursorPosition(7, 4);
                Console.ForegroundColor = ConsoleColor.White;
            }
        }

        public void GameLogSection(int Scenario)
        {
            Hand hand = Hand.GetInstance();

            Console.CursorLeft = 78;
            Console.CursorTop = hand.playerList.Count() + 9 + GameLog;

            if (hand.playerList.Count() + 9 <= 26)
            {
                if (Scenario == 0)
                {
                    int suitValue = hand.dealerHand[0].CardDraw.Last().SuitInt;

                    Console.Write(hand.playerList[index].PlayerName + " dealt ");

                    if (suitValue == 1 || suitValue == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if (suitValue == 2 || suitValue == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.Write(hand.playerList[index].CardDraw.Last().CardName);
                    Console.ForegroundColor = ConsoleColor.White;
                }

                else if (Scenario == 1)
                {
                    int suitValue = hand.dealerHand[0].CardDraw.Last().SuitInt;

                    Console.CursorLeft = 77;
                    Console.Write(" Dealer dealt ");

                    if (suitValue == 1 || suitValue == 4)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                    }

                    else if (suitValue == 2 || suitValue == 3)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkGray;
                    }

                    Console.Write(hand.dealerHand[0].CardDraw.Last().CardName);
                    Console.ForegroundColor = ConsoleColor.White;
                }
                else
                {
                    GameLog = -1; // Clear game log here
                }

                GameLog++;
            }
        }

        // Action methods
        // Possible Actions (Later when I can make it, split, surrender, Insurance, InurancePayout, Splithand
        public void Hit()
        {
            // Get instances
            Hand hand = Hand.GetInstance();
            Deck deck = Deck.GetInstance();

            // Comment
            Console.SetCursorPosition(5, 26);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(CurrentPlayer);
            Console.ForegroundColor = ConsoleColor.White;
            Console.Write(" hits.                                  ");

            // Get new card and add to hand

            Card = deck.DrawCard(1);
            hand.playerList[index].CardDraw.Add(Card[0]);
            Console.SetCursorPosition(5, 9);
            Console.Write(EmptyLeft);
            Console.SetCursorPosition(5, 9);

            for (int n = 0; n < hand.playerList[index].CardDraw.Count(); n++)
            {
                int suitValue = hand.playerList[index].CardDraw[n].SuitInt;

                if (suitValue == 1 || suitValue == 4)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                }

                else if (suitValue == 2 || suitValue == 3)
                {
                    Console.ForegroundColor = ConsoleColor.DarkGray;
                }

                if (hand.playerList[index].CardDraw[n].ValueInt >= 11)
                {
                    valueInt = 10;
                }
                else
                {
                    valueInt = hand.playerList[index].CardDraw[n].ValueInt;
                }
                totalValue = valueInt + totalValue;
                Console.Write(hand.playerList[index].CardDraw[n].CardName + ", ");
            }

            Console.ForegroundColor = ConsoleColor.White;
            Console.Write("(" + totalValue + "), ($" + Bet + ")");

            if (totalValue > 21)
            {
                CommentSection(7);

            }

            Console.SetCursorPosition(119, 29);
            ActionCase = "1";
            Thread.Sleep(3000);
            ActionCase = "3";
        }

        public void Stand()
        {
            Console.WriteLine("Test");
        }

        public void DoubleDown()
        {
            Console.WriteLine("Test");
        }

        public void Quit()
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.SetCursorPosition(5, 3);
            Console.Write(EmptyLeft);
            Console.SetCursorPosition(5, 9);
            Console.Write(EmptyLeft);
            Console.SetCursorPosition(5, 15);
            Console.Write(EmptyLeft);
            Console.SetCursorPosition(5, 21);
            Console.Write(EmptyLeft);
            Console.SetCursorPosition(5, 26);
            Console.Write(EmptyLeft);
            Console.SetCursorPosition(5, 3);
            Console.Write("Quitting blackjack.....");
            Console.SetCursorPosition(5, 9);
            Console.Write("Quitting blackjack.....");
            Console.SetCursorPosition(5, 15);
            Console.Write("Quitting blackjack.....");
            Console.SetCursorPosition(5, 21);
            Console.Write("Quitting blackjack.....");
            Console.SetCursorPosition(5, 26);
            Console.Write("Quitting blackjack.....");
            Console.SetCursorPosition(119, 29);
            Thread.Sleep(3000);
            Console.Clear();
            Console.SetCursorPosition(45, 15);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Quitted blackjack succesfully.");
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 29);
            System.Environment.Exit(0);
        }

        public void Secret()
        {
            Console.WriteLine("Test");
        }

        public void InvalidKey()
        {
            Console.SetCursorPosition(5, 26);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("Invalid input!                          ");
            Console.SetCursorPosition(119, 29);
            Console.ForegroundColor = ConsoleColor.White;
            Thread.Sleep(3000);
        }

        public void GetKeyInput()
        {
            Hand hand = Hand.GetInstance();

            Console.CursorLeft = 81;
            Console.CursorTop = hand.playerList.Count() + 8;
            Console.ForegroundColor = ConsoleColor.Green;
            KeyInput = Console.ReadKey();
            Console.CursorLeft = 81;
            Console.CursorTop = hand.playerList.Count() + 8;
            Console.Write("           ");
            KeyInputCase = KeyInput.KeyChar.ToString();
        }

        // Rounds
        public void Lost(int Scenario)
        {

        }

        public void Win(int Scenario)
        {

        }

        public void Tie(int Scenario)
        {

        }
    }
}


