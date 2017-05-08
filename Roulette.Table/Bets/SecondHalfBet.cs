namespace Roulette.Table
{
    public class SecondHalfBet : Bet
    {
        public SecondHalfBet(double amount)
        {
            Amount = amount;
            StartingNumber = 25;
            EndingNumber = 36;
            PayoutMultiplier = 2;
        }
    }
}