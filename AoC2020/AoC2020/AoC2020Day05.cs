using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day05;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day05
    {
        private static readonly string[] Delimiter = {"\r\n"};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day5InputText.txt", Delimiter);

        private static readonly List<BinarySeat>
            ConvertedInputList = InputList.ConvertAll(item => new BinarySeat(item));

        public static void SolvePartOne()
        {
            var sortedBinarySeats = ConvertedInputList.OrderByDescending(seat => seat.SeatId).ToList();

            Console.WriteLine(sortedBinarySeats.First().SeatId);

            foreach (var binarySeat in sortedBinarySeats) Console.WriteLine(binarySeat);
        }

        public static void SolvePartTwo()
        {
            // See Day5InputText_Vis.txt in Inputs folder. Look for seat Id 560.
            // The missing seat is 559.
        }
    }
}