namespace Roulette.Table
{
    public class FirstThirdColumnsBet : Bet
    {
        public FirstThirdColumnsBet(double amount)
        {
            Amount = amount;
            StartingNumber = 1;
            EndingNumber = 12;
            PayoutMultiplier = 3;
        }
    }
}