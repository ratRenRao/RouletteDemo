using System;
using Roulette.StrategyDemo;
using Moq;
using Roulette.Table;
using Shouldly;
using Xunit;

namespace Roulette.Test
{
    public class DoubleDownStrategyTests
    {
        private static Random _random = new Random();
        public DoubleDownStrategy DoubleDown = new DoubleDownStrategy();
        public Mock<IRouletteTable> Table = new Mock<IRouletteTable>();

        [Fact]
        public void calculate_max_bet_functions()
        {
            DoubleDown.MaxPlannedForLossStreak = 13;
            DoubleDown.Funds = 32800;
            DoubleDown.CalculateMaxStartingBetForPlannedLossStreak().ShouldBe(8);
        }

        [Fact]
        public void calculate_max_starting_bet_functions()
        {
            DoubleDown.MaxPlannedForLossStreak = 14;
            DoubleDown.Funds = 100000;
            var result = DoubleDown.CalculateRequiredFundsForMaxPlannedLossStreak(8);
            result.ShouldBe(65536);
        }

        [Fact]
        public void demo_ends_when_max_loss_streak_exceeded()
        {
            Table.Setup(x => x.SpinWheel()).Returns(new Slot {Color = SlotColor.Black});
            DoubleDown.MaxPlannedForLossStreak = 6;
            DoubleDown.Table = Table.Object;
            DoubleDown.Run(16, 10000);
            
            DoubleDown.RoundNumber.ShouldBe(6);
        }
    }
}
