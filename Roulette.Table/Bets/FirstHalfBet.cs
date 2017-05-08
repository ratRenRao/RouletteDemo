namespace Roulette.Table
{
    public class FirstHalfBet : Bet
    {
        public FirstHalfBet(double amount)
        {
            Amount = amount;
            StartingNumber = 1;
            EndingNumber = 24;
            PayoutMultiplier = 2;
        }
    }
}