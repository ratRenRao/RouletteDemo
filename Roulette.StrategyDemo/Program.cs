using System;

namespace Roulette.StrategyDemo
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