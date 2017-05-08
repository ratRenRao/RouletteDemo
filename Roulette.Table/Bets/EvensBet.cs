using System;
using System.Linq;

namespace Roulette.Table
{
    public class EvensBet : Bet
    {
        public EvensBet(double amount)
        {
            Amount = amount;
            PayoutMultiplier = 2;
            ContainedSlots = Enumerable.Range(1, 36).Where(x => x % 2 == 0).ToArray();
        }
    }
}