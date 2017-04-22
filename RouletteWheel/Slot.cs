namespace Roulette.Table
{
    public class Slot
    {
        public int Number { get; set; }
        public SlotColor Color {get; set; }
    }

    public enum SlotColor
    {
        Red,
        Black,
        Green
    }
}