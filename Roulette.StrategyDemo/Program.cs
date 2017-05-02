using System;

namespace Roulette.StrategyDemo
{
    class Program
    {
        static void Main()
        {
            var looper = new StrategyLooper(10, 200, 10000d);
            looper.Run();
            Console.WriteLine($"Largest funds: {looper.MaxFunds}");
            Console.WriteLine($"Smallest funds: {looper.MinFunds}");
            Console.WriteLine("=================================================");
            Console.WriteLine($"Longest loss streak: {Streak.LongestLossStreak}");
            Console.WriteLine($"Longest win streak: {Streak.LongestWinStreak}");
            Console.WriteLine("GAME OVER");
            Console.ReadKey();
        }
    }
}