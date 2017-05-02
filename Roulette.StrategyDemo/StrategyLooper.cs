using System;
using System.Collections.Generic;
using System.Text;

namespace Roulette.StrategyDemo
{
    public class StrategyLooper
    {
        private readonly int _instances;
        public double MaxFunds;
        public double MinFunds;
        private readonly int _rounds;
        private double _funds;

        public StrategyLooper(int instances, int rounds, double funds)
        {
            _instances = instances;
            _rounds = rounds;
            _funds = funds;
        }

        public void Run()
        {
            for (int i = 0; i < _instances; i++)
            {
                var doubleDown = new DoubleDownStrategy();
                doubleDown.Run(_rounds, _funds);

                if (doubleDown.LargestFundSnapshot > MaxFunds)
                    MaxFunds = doubleDown.LargestFundSnapshot;
                if (doubleDown.SmallestFundSnapshot < MinFunds)
                    MinFunds = doubleDown.SmallestFundSnapshot;
            }
        }
    }
}
