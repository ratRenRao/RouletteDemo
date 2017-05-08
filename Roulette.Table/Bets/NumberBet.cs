using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.Table
{
    public class NumberBet : Bet
    {
        public NumberBet(double amount, int startingNum, int endingNum)
        {
            Amount = amount;
            StartingNumber = startingNum;
            EndingNumber = endingNum;
            PayoutMultiplier = 36 / (endingNum - startingNum);
        }
    }

    public enum NumberBetType
    {
        Single,
        Group
    }
}
