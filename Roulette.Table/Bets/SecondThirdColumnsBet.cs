namespace Roulette.Table
{
    public class SecondThirdColumnsBet : Bet
    {
        public SecondThirdColumnsBet(double amount)
        {
            Amount = amount;
            StartingNumber = 13;
            EndingNumber = 24;
            PayoutMultiplier = 3;
        }
    }
}