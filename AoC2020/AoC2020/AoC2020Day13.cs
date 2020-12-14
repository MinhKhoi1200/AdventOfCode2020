using System;
using System.Collections.Generic;
using AoC2020Classes.Day13;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day13
    {
        private static readonly string[] Delimiter = {Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day13InputText.txt", Delimiter);

        private static readonly int TimeStamp = int.Parse(InputList[0]);


        public static void SolvePartOne()
        {
            var busNumberList = BusScheduleUtility.ConvertRawBusNumbers(InputList[1]);

            var (busNumber, waitTime) = BusScheduleUtility.FindTheEarliestNextBus(busNumberList, TimeStamp);
            Console.WriteLine(busNumber * waitTime);
        }

        public static void SolvePartTwo()
        {
            var busNumbersWithRemainders = BusScheduleUtility.ConvertRawBusNumbersWithRemainders(InputList[1]);

            var crtSolver = new CrtSolver(busNumbersWithRemainders);

            var testOutput = crtSolver.Solve();

            Console.WriteLine(testOutput);
        }
    }
}