using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Core;

namespace AoC2020
{
    public static class AoC2020Day01
    {
        private static readonly List<int> InputList =
            ReadInput.ConvertInputTextToIntList(@"..\..\..\Inputs\Day1InputText.txt");

        public static void SolvePartOne()
        {
            Console.WriteLine("Day 1 - Part 1");
            if (!InputList.Any()) return;

            for (var firstIndex = 0; firstIndex < InputList.Count - 1; firstIndex++)
            {
                var firstNumber = InputList[firstIndex];

                for (var secondIndex = firstIndex + 1; secondIndex < InputList.Count; secondIndex++)
                {
                    var secondNumber = InputList[secondIndex];
                    if (firstNumber + secondNumber == 2020)
                        Console.WriteLine($"{firstNumber} {secondNumber} {firstNumber * secondNumber}");
                }
            }
        }

        public static void SolvePartTwo()
        {
            Console.WriteLine("Day 1 - Part 2");
            if (!InputList.Any()) return;

            for (var firstIndex = 0; firstIndex < InputList.Count - 2; firstIndex++)
            {
                var firstNumber = InputList[firstIndex];

                for (var secondIndex = firstIndex + 1; secondIndex < InputList.Count - 1; secondIndex++)
                {
                    var secondNumber = InputList[secondIndex];

                    for (var thirdIndex = secondIndex + 1; thirdIndex < InputList.Count; thirdIndex++)
                    {
                        var thirdNumber = InputList[thirdIndex];

                        if (firstNumber + secondNumber + thirdNumber == 2020)
                            Console.WriteLine(
                                $"{firstNumber} {secondNumber} {thirdNumber} {firstNumber * secondNumber * thirdNumber}");
                    }
                }
            }
        }
    }
}