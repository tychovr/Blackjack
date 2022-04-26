namespace Blackjack
{
    class Program
    {
        // Blackjack options in-game
        // https://www.casinostrategy.org/blackjack/blackjack-terminology.htm
        static void Main(string[] args)
        {
            Game Game = Game.GetInstance();
            //Initialize - Let the games begin!
            Game.Initialize();
            Game.Intro();
            Game.Rules();
            Game.WinLose();
            Game.Controls();
            Game.ToGame();

            // Add new users
            Hand hand = Hand.GetInstance();
            hand.PlayerHand();

            // Start of the game
            Game.StartGame();
            Game.Blackjack();
        }
    }
}