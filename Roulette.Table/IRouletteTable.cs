using System.Collections.Generic;

namespace Roulette.Table
{
    public interface IRouletteTable
    {
        List<Slot> SpinResults { get; }
        Slot LastSpinResult { get; }
        Slot SpinWheel();
        void PlaceBet(Bet bet);
        double PayoutWinnings();
        void StartNewRound();
    }
}