using System;
using System.Collections.Generic;
using Roulette.Table;

namespace Roulette.StrategyDemo
{
    public class DoubleDownStrategy : IDoubleDownStrategy
    {
        public List<BetResult> BetResults = new List<BetResult>();
        private Bet _lastBet = null; 
        public double Funds { get; set; }
        public RouletteTable Table = new RouletteTable(false);
        private Streak _streak = new Streak();
        public int MaxPlannedForLossStreak = 10;
        private double _betIncrement = 0.5d;

        public void Run(int totalRounds, double funds)
        {
            Funds = funds;

            for(var i = 0; i < totalRounds; i++)
            {
                Table.StartNextRound();
                double betAmount;

                if (_streak.StreakType == BetResult.Win)
                {
                    betAmount = CalculateMaxStartingBetForPlannedLossStreak();
                    if (betAmount == 0)
                    {
                        Console.WriteLine("Not Enough Funds To Place A Bet Based On Planned Max Loss Streak");
                        return;
                    }
                }
                else
                {
                    if (_streak.Length == 1)
                        betAmount = _lastBet.Amount;
                    else
                    {
                        if(Funds - (_lastBet.Amount * 2) > 0)
                            betAmount = _lastBet.Amount * 2;
                        else
                        {
                            Console.WriteLine("Loss streak exceeded planned streak length");
                            return;
                        }
                    }
                }

                PlaceBet(betAmount, BetType.Color, SlotColor.Black, 2d);

                var spinResult = Table.SpinWheel();
                var winnings = Table.PayoutWinnings();
                Funds += winnings;

                UpdateStats(spinResult);
                Console.WriteLine($"{_streak} : ${betAmount} : ${Funds}");
            }
        }

        private void UpdateStats(Slot spinResult)
        {
            if (spinResult.Color == _lastBet.Color)
            {
                if(_streak.StreakType != BetResult.Win)
                    _streak.StreakType = BetResult.Win;
                else
                    _streak.Length++;
            }
            else
            {
                if (_streak.StreakType != BetResult.Loss)
                    _streak.StreakType = BetResult.Loss;
                else
                    _streak.Length++;
            }
        }

        public void PlaceBet(double amount, BetType betType, SlotColor color, double payoutMultiplier)
        {
            Funds -= amount;
            var bet = new Bet
                    {
                        Amount = amount,
                        BetType = betType,
                        Color = color,
                        PayoutMultiplier = payoutMultiplier
                    };
            Table.PlaceBet(bet);
            _lastBet = bet;
        }

        public double CalculateMaxStartingBetForPlannedLossStreak(double startingBet = 1)
        {
            while (true)
            {
                var requiredFunds = CalculateRequiredFundsForMaxPlannedLossStreak(startingBet);

                if (requiredFunds > Funds)
                {
                    startingBet -= _betIncrement;
                    return startingBet;
                }
                else
                {
                    startingBet += _betIncrement;
                }
            }
        }

        public double CalculateRequiredFundsForMaxPlannedLossStreak(double currentAmountLost = 0.5, int lossStreakLength = 0)
        {
            while (true)
            {
                currentAmountLost *= 2;
                if (lossStreakLength + 1 == MaxPlannedForLossStreak) return currentAmountLost;
                lossStreakLength = ++lossStreakLength;
            }
        }
    }

    public enum BetResult
    {
        Win,
        Loss
    }

    public class Streak
    {
        private BetResult _streakType = BetResult.Win;
        public BetResult StreakType
        {
            get
            {
                return _streakType;
            }
            set
            {
                Length = 1;
                _streakType = value;
            }
        }

        public static int LongestLossStreak { get; set; }
        public  static int LongestWinStreak { get; set; }

        private int _length;
        public int Length
        {
            get { return _length; }
            set
            {
                if (_streakType == BetResult.Win
                    && _length > LongestWinStreak)
                    LongestWinStreak = _length;
                if (_streakType == BetResult.Loss
                    && _length > LongestWinStreak)
                    LongestLossStreak = _length;

                _length = value;
            } 
        }

        public override string ToString()
        {
            var result = _streakType == BetResult.Win ? "W" : "L";
            return $"{result}{Length}";
        }
    }
}
