namespace Blackjack
{
    internal class Stats
    {
        private Stats() { }
        private static Stats _instance;
        public static Stats GetInstance()
        {
            if (_instance == null)
            {
                _instance = new Stats();
            }
            return _instance;
        }

        public void showStats()
        {
            // Get instances
            Hand hand = Hand.GetInstance();
            int index = 0;

            // Prints out the stats of the players
            // New line write on 75
            // Playername write on 79
            // Saldo write on 96
            // Wins write on 108
            Console.CursorTop = 1;
            Console.CursorLeft = 75;
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("-----------------------------------------");
            Console.CursorTop = 2;
            Console.CursorLeft = 75;
            Console.Write("|   Playername   |   Saldo   |   Wins   |");
            Console.SetCursorPosition(75, 3);
            Console.Write("-----------------------------------------");

            for (int i = 1; i <= hand.playerList.Count; i++)
            {
                Console.CursorLeft = 75;
                Console.CursorTop = i + 3;
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("|                |           |          |");
                Console.CursorLeft = 79;
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write(hand.playerList[index].PlayerName);
                Console.CursorLeft = 96;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(hand.playerList[index].Saldo);
                Console.CursorLeft = 108;
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(hand.playerList[index].Wins);
                Console.ForegroundColor = ConsoleColor.White;
                index++;

                if (i == hand.playerList.Count)
                {
                    Console.CursorTop = i + 4;
                    Console.CursorLeft = 75;
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.Write("-----------------------------------------");
                    Console.ForegroundColor = ConsoleColor.White;
                }
            }


        }

        public void ChangeStats(int index)
        {
            // Get instances
            Hand hand = Hand.GetInstance();
            Console.CursorTop = 4 + index;
            Console.CursorLeft = 75;
            Console.Write("|                |           |          |");
            Console.CursorLeft = 79;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(hand.playerList[index].PlayerName);
            Console.CursorLeft = 96;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(hand.playerList[index].Saldo);
            Console.CursorLeft = 108;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(hand.playerList[index].Wins);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
