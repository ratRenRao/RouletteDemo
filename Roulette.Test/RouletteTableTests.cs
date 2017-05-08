using System;
using Roulette.Table;
using Shouldly;
using Xunit;

namespace Roulette.Test
{
    public class RouletteTableTests
    {
        public RouletteTable Table = new RouletteTable(false);

        [Fact]
        public void colored_payout_correct()
        {
            Table.SpinResults.Add(new Slot
            {
                Color = SlotColor.Red,
                Number = 1
            });

            Table.PlaceBet(new ColorBet(2, SlotColor.Red));

            var payout = Table.PayoutWinnings();
            
            payout.ShouldBe(4);
        }
    }
}
