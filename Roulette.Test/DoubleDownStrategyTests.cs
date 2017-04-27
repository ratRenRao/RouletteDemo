using System;
using Roulette.StrategyDemo;
using Moq;
using Shouldly;
using Xunit;

namespace Roulette.Test
{
    public class DoubleDownStrategyTests
    {
        private static Random _random = new Random();
        public DoubleDownStrategy DoubleDown = new DoubleDownStrategy();

        [Fact]
        public void funds_change_correctly()
        {
        }

        [Fact]
        public void calculate_max_bet_functions()
        {
            DoubleDown.MaxPlannedForLossStreak = 13;
            DoubleDown.Funds = 100000;
            DoubleDown.CalculateMaxStartingBetForPlannedLossStreak().ShouldBe(8);
        }
    }
}
