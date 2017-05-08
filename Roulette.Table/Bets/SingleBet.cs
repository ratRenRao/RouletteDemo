using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Table
{
    public class SingleBet : Bet
    {
        public SingleBet(double amount, int slot)
        {
            Amount = amount;
            StartingNumber = slot;
            EndingNumber = slot;
            PayoutMultiplier = 36;
        }
    }
}
