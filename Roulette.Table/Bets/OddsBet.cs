using System.Linq;

namespace Roulette.Table
{
    public class OddsBet : Bet
    {
        public OddsBet(double amount)
        {
            Amount = amount;
            PayoutMultiplier = 2;
            ContainedSlots = Enumerable.Range(1, 36).Where(x => x % 1 == 0).ToArray();
        }
    }
}