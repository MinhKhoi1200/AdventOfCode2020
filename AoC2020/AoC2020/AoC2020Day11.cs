using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day11;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day11
    {
        private static readonly string[] Delimiter = {Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day11InputText.txt", Delimiter);


        public static void SolvePartOne()
        {
            var convertedSeatPlan = SeatLayoutCreator.CreateSeatPlan(InputList);

            var seatSimulation = new SeatSimulation(convertedSeatPlan);

            seatSimulation.RunFullSimulation();

            var occupiedSeatsCount = convertedSeatPlan.Sum(row =>
                row.Count(eachTile => eachTile.TileStatus == TileStatus.SeatOccupied));

            Console.WriteLine(occupiedSeatsCount);
        }

        public static void SolvePartTwo()
        {
            var convertedSeatPlan = SeatLayoutCreator.CreateSeatPlan(InputList);

            var seatSimulation = new SeatSimulation(convertedSeatPlan);

            seatSimulation.RunFullSimulationNewRules();


            var occupiedSeatsCount = convertedSeatPlan.Sum(row =>
                row.Count(eachTile => eachTile.TileStatus == TileStatus.SeatOccupied));

            Console.WriteLine(occupiedSeatsCount);
        }
    }
}