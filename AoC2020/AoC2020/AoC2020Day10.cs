using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day10;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day10
    {
        private static readonly List<int> InputList = ReadInput.ConvertInputTextToIntList(@"..\..\..\Inputs\Day10InputText.txt");

        private static readonly List<Adapter>
            ConvertedInputList = Adapter.GenerateSortedListOfAdaptersJoltage(InputList);

        public static void SolvePartOne()
        {
            var diffList = new List<int>();
            for (var firstIndex = 0; firstIndex < ConvertedInputList.Count - 1; firstIndex++)
            {
                var firstAdapter = ConvertedInputList[firstIndex];
                var secondAdapter = ConvertedInputList[firstIndex + 1];

                diffList.Add(firstAdapter.OutputJoltage - secondAdapter.OutputJoltage);
            }

            var threeJoltsDiffCount = diffList.Count(joltDiff => joltDiff == -3);
            var oneJoltsDiffCount = diffList.Count(joltDiff => joltDiff == -1);

            Console.WriteLine(threeJoltsDiffCount * oneJoltsDiffCount);

        }

        public static void SolvePartTwo()
        {

        }
    }
}