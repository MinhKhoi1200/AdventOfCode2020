using System;
using System.Collections.Generic;
using AoC2020Classes.Day12;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day12
    {
        private static readonly string[] Delimiter = {Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day12InputText.txt", Delimiter);

        private static readonly List<ShipInstruction> ShipInstructionsList =
            InputList.ConvertAll(eachItem => new ShipInstruction(eachItem));

        public static void SolvePartOne()
        {
            var ship = new Ship();

            ship.ExecuteInstructionsList(ShipInstructionsList);

            Console.WriteLine(ship.ManhattanDistFromOrigin);
        }

        public static void SolvePartTwo()
        {
            var ship = new Ship();

            ship.ExecuteInstructionsListWithWayPoint(ShipInstructionsList);

            Console.WriteLine(ship.ManhattanDistFromOrigin);
        }
    }
}