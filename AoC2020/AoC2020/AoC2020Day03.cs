using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day03;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day03
    {
        private static readonly string[] Delimiter = {"\r\n"};
        private static readonly List<string> InputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day3InputText.txt", Delimiter);
        private static readonly List<List<char>> ConvertedInputList = InputList.ConvertAll(eachRow => eachRow.ToList());
        private static readonly MapGrid MapGrid = new MapGrid(ConvertedInputList);

        public static void SolvePartOne()
        {
            var traversePath = new TraversePath(3, 1);
            var treesCount = MapGrid.NumberOfTreesEncountered(traversePath);

            Console.WriteLine(treesCount);
        }

        public static void SolvePartTwo()
        {
            var traversePaths = InitialiseTraversePathsList();

            long treeCountsProduct = 1;

            foreach (var traversePath in traversePaths)
            {
                var treesCount = MapGrid.NumberOfTreesEncountered(traversePath);
                Console.WriteLine(treesCount);
                treeCountsProduct *= treesCount;
            }

            Console.WriteLine(treeCountsProduct);

        }

        private static List<TraversePath> InitialiseTraversePathsList()
        {
            var traversePaths = new List<TraversePath>();

            for (var i = 1; i <= 7; i += 2)
            {
                traversePaths.Add(new TraversePath(i, 1));
            }

            traversePaths.Add(new TraversePath(1, 2));
            return traversePaths;
        }
    }
}