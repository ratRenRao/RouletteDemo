using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Table
{
    public class ColorBet : Bet
    {
        public ColorBet(double amount, SlotColor color)
        {
            BetType = BetType.Color;
            PayoutMultiplier = 2;
            Color = color;
            Amount = amount;
        }
    }
}
