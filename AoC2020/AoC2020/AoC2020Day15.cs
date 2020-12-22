using System;
using System.Collections.Generic;
using AoC2020Classes.Day15;

namespace AoC2020
{
    public class AoC2020Day15
    {
        private static readonly List<int> InputList = new List<int> {13, 16, 0, 12, 15, 1};

        public static void SolvePartOne()
        {
            var memoryChallenge = new MemoryGame(InputList);
            var testResult = memoryChallenge.Play(2020);
            Console.WriteLine(testResult);
        }

        public static void SolvePartTwo()
        {
            var memoryChallenge = new MemoryGame(InputList);
            var testResult = memoryChallenge.Play(30000000);
            Console.WriteLine(testResult);
        }
    }
}