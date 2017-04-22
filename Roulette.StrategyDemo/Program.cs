using System;
using Roulette.StrategyDemo;

namespace RouletteStrategyDemo
{
    class Program
    {
        static void Main()
        {
            new DoubleDownStrategy().Run(20, 10000d);
            Console.ReadKey();
        }
    }
}