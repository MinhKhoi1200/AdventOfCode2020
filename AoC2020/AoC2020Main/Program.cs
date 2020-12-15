﻿using System;
using System.Diagnostics;
using AoC2020;

namespace AoC2020Main
{
    class Program
    {
        static void Main()
        {
            var watch1 = Stopwatch.StartNew();
            AoC2020Day15.SolvePartOne();
            watch1.Stop();

            var watch2 = Stopwatch.StartNew();
            AoC2020Day15.SolvePartTwo();
            watch2.Stop();

            Console.WriteLine($"Part One took {watch1.ElapsedMilliseconds} ms");
            Console.WriteLine($"Part Two took {watch2.ElapsedMilliseconds} ms");
            Console.ReadLine();
        }
    }
}
