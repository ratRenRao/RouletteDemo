using System;
using System.Collections.Generic;
using Roulette.Table;

namespace Roulette.StrategyDemo
{
    public class DoubleDownStrategy
    {
        public List<BetResult> BetResults = new List<BetResult>();
        private Bet _lastBet = null; 
        public double Funds { get; private set; }
        public RouletteTable Table = new RouletteTable(false);
        private Streak _streak = new Streak();
        private int maxPlannedForLossStreak = 10;

        public void Run(int totalRounds, double funds)
        {
            Funds = funds;

            for(var i = 0; i < totalRounds; i++)
            {
                Table.StartNextRound();
                double betAmount;

                //if (_streak.Length == 0)
                //{
                //    PlaceBet(1d, BetType.Color, SlotColor.Black, 2d);
                //}
                if (_streak.StreakType == BetResult.Win)
                {
                    //if (_streak.Length == 1)
                    betAmount = CalculateMaxStartingBetForPlannedLossStreak();
                    if (betAmount == 0)
                    {
                        Console.WriteLine("Not Enough Funds To Place A Bet Based On Planned Max Loss Streak");
                        return;
                    }
                    //else
                    //{
                    //    if (_streak.Length >= 3)
                    //    {
                    //        betAmount = CalculateMaxStartingBetForPlannedLossStreak();
                    //        _streak.Length = 1;
                    //    }
                    //    else
                    //    {
                    //        betAmount = _lastBet.Amount * 2;
                    //    }
                    //}

                    //if(_streak.Length >= 4)
                    //    Console.WriteLine("Awesome");

                   //PlaceBet(betAmount, BetType.Color, SlotColor.Black, 2d);
                }
                else
                {
                    if (_streak.Length == 1)
                        betAmount = _lastBet.Amount;
                    else
                        betAmount = _lastBet.Amount * 2;
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

        public double CalculateMaxStartingBetForPlannedLossStreak()
        {
            double startingBet = 0;
            double requiredFunds;

            do
            {
                startingBet++;
                requiredFunds = CalculateRequiredFundsForMaxPlannedLossStreak(startingBet, maxPlannedForLossStreak);
            } while (requiredFunds < Funds);

            return --startingBet;
        }

        public double CalculateRequiredFundsForMaxPlannedLossStreak(double startingAmountLost, int maxLossStreak)
        {
            var index = 1;
            double lastAmountBet = startingAmountLost;
            double totalRequiredFunds = startingAmountLost;

            while (index < maxLossStreak)
            {
                lastAmountBet *= 2;
                totalRequiredFunds += lastAmountBet;
                index++;
            }

            return totalRequiredFunds;
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

        public int Length { get; set; }

        public override string ToString()
        {
            var result = _streakType == BetResult.Win ? "W" : "L";
            return $"{result}{Length}";
        }
    }
}
