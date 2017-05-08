namespace Roulette.Table
{
    public class ThirdThirdColumnsBet : Bet
    {
        public ThirdThirdColumnsBet(double amount)
        {
            Amount = amount;
            StartingNumber = 25;
            EndingNumber = 36;
            PayoutMultiplier = 3;
        }
    }
}