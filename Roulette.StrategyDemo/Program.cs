using System;

namespace Roulette.StrategyDemo
{
    class Program
    {
        static void Main()
        {
            new DoubleDownStrategy().Run(200, 10000d);
            Console.WriteLine($"Longest loss streak: {Streak.LongestLossStreak}");
            Console.WriteLine($"Longest win streak: {Streak.LongestWinStreak}");
            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }
    }
}