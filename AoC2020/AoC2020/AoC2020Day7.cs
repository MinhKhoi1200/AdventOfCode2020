using System;
using System.Collections.Generic;
using AoC2020Classes.Day7;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day7
    {

        private static readonly string[] Delimiter = { Environment.NewLine };
        private static readonly List<string> InputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day7InputText.txt", Delimiter);

        private static readonly List<LuggageRule>
            ConvertedInputList = InputList.ConvertAll(item => new LuggageRule(item));

        private static readonly Dictionary<string, Dictionary<string, int>> AdjacencyMatrix =
            LuggageRuleAdjacencyMatrixCreator.CreateAdjacencyDictionary(ConvertedInputList);

        public static void SolvePartOne()
        {
            const string colourToFind = "shiny gold";
            var allMultiLevelLuggage = LuggageRuleAdjacencyMatrixUtility.FindMultiLevelLuggageContainingColour(colourToFind, AdjacencyMatrix);
            Console.WriteLine(allMultiLevelLuggage.Count);
        }

        public static void SolvePartTwo()
        {
            const string colourToFind = "shiny gold";
            var numberOfLuggage = LuggageRuleAdjacencyMatrixUtility.CountNumberOfBugsInsideALuggageOfGivenColour(colourToFind, AdjacencyMatrix);
            Console.WriteLine(numberOfLuggage);
        }
    }
}