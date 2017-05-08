namespace Roulette.Table
{
    public abstract class Bet
    {
        public double Amount { get; set; }
        public BetType BetType { get; set; }
        public int StartingNumber { get; set; }
        public int EndingNumber { get; set; }
        public int[] ContainedSlots { get; set; }
        public SlotColor Color { get; set; }
        public double PayoutMultiplier { get; set; }
    }

    public enum BetType
    {
        Number,
        Color
    }
}