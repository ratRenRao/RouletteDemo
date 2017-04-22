namespace Roulette.Table
{
    public class Bet
    {
        public double Amount { get; set; }
        public BetType BetType { get; set; }
        public int StartingNumber { get; private set; }
        public int EndingNumber { get; private set; }
        public SlotColor Color { get; set; }
        public double PayoutMultiplier { get; set; }
    }

    public enum BetType
    {
        Number,
        Color
    }
}