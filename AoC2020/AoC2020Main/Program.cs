using System;
using System.Diagnostics;
using AoC2020;

namespace AoC2020Main
{
    internal class Program
    {
        private static void Main()
        {
            var watch1 = Stopwatch.StartNew();
            AoC2020Day22.SolvePartOne();
            watch1.Stop();

            var watch2 = Stopwatch.StartNew();
            AoC2020Day22.SolvePartTwo();
            watch2.Stop();

            Console.WriteLine($"Part One took {watch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Part Two took {watch2.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}