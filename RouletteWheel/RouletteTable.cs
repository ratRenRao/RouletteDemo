using System;
using System.Collections.Generic;

namespace Roulette.Table
{
    public class RouletteTable : IRouletteTable
    {
        private static readonly Random Random = new Random();
        private readonly List<Bet> _bets = new List<Bet>();
        public Slot LastSpinResult => SpinResults[SpinResults.Count - 1];
        public List<Slot> SpinResults { get; private set; } = new List<Slot>();
        private readonly Func<int> _getRandomSlot;

        public RouletteTable(bool includeGreenSlot)
        {
            _getRandomSlot = () => Random.Next(1, (includeGreenSlot ? 37 : 36));
        }

        public Slot SpinWheel()
        {
            var slotInt = _getRandomSlot.Invoke();

            var result = new Slot
            {
                Number = slotInt,
                Color = DetermineSlotColor(slotInt)
            };

            SpinResults.Add(result);

            return result;
        }

        private SlotColor DetermineSlotColor(int slotInt)
        {
            if(slotInt == 37)
                return SlotColor.Green;

            return slotInt % 2 == 1 ? SlotColor.Red : SlotColor.Black;
        }

        public void PlaceBet(Bet bet)
        {
            _bets.Add(bet);
        }

        public double PayoutWinnings()
        {
            var winnings = 0d;
            var lastSpinNumber = LastSpinResult.Number;
            var lastSpinColor = LastSpinResult.Color;

            _bets.ForEach(bet =>
            {
                if ((bet.BetType == BetType.Number
                    && lastSpinNumber >= bet.StartingNumber
                    && lastSpinNumber <= bet.EndingNumber)
                    || (lastSpinColor == bet.Color))
                    {
                        winnings += bet.Amount * bet.PayoutMultiplier;
                    }
            });

            return winnings;
        }

        public void StartNextRound()
        {
            _bets.Clear();
        }

    }
}
