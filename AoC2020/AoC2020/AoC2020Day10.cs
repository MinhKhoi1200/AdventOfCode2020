using System;
using System.Collections.Generic;
using AoC2020Classes.Day9;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day10
    {
        private static readonly List<long> InputList = ReadInput.ConvertInputTextToLongIntList(@"..\..\..\Inputs\Day9InputText.txt");

        public static void SolvePartOne()
        {
            var mismatchNumber = XmasDecrypter.FindMismatch(InputList, 25);
            Console.WriteLine(mismatchNumber);
        }

        public static void SolvePartTwo()
        {
            var weakness = XmasDecrypter.FindWeakness(InputList, 25);
            Console.WriteLine(weakness);
        }
    }
}