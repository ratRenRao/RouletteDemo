using Roulette.Table;

namespace Roulette.StrategyDemo
{
    public interface IDoubleDownStrategy
    {
        double Funds { get; }

        double CalculateMaxStartingBetForPlannedLossStreak(double startingBet);
        double CalculateRequiredFundsForMaxPlannedLossStreak(double currentAmountLost, int lossStreakLength);
        void PlaceBet(double amount, BetType betType, SlotColor color, double payoutMultiplier);
        void Run(int totalRounds, double funds);
    }
}