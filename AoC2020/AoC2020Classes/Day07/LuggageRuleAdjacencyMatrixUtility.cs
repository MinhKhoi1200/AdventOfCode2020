using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day07
{
    public class LuggageRuleAdjacencyMatrixUtility
    {
        public static int CountNumberOfBugsInsideALuggageOfGivenColour(string requiredColour,
            Dictionary<string, Dictionary<string, int>> luggageRuleAdjacencyMatrix)
        {
            var outputCount = 0;
            var firstLevelLuggage =
                luggageRuleAdjacencyMatrix[requiredColour].Where(eachLuggage => eachLuggage.Value > 0).ToList();

            foreach (var luggage in firstLevelLuggage)
            {
                var luggageCountInsideRequiredColour = luggage.Value;
                outputCount += luggageCountInsideRequiredColour *
                               CountNumberOfBugsInsideALuggageOfGivenColour(luggage.Key, luggageRuleAdjacencyMatrix) +
                               luggage.Value;
            }

            return outputCount;
        }

        public static List<string> FindMultiLevelLuggageContainingColour(string requiredColour,
            Dictionary<string, Dictionary<string, int>> luggageRuleAdjacencyMatrix)
        {
            var outputList = new List<string>();
            var firstLevelLuggage = FindFirstLevelLuggageContainingColour(requiredColour, luggageRuleAdjacencyMatrix);

            foreach (var luggage in firstLevelLuggage)
            {
                outputList.Add(luggage);

                var nextLevelsLuggage = FindMultiLevelLuggageContainingColour(luggage, luggageRuleAdjacencyMatrix);
                outputList.AddRange(nextLevelsLuggage);
            }

            return outputList.Distinct().ToList();
        }

        public static List<string> FindFirstLevelLuggageContainingColour(string requiredColour,
            Dictionary<string, Dictionary<string, int>> luggageRuleAdjacencyMatrix)
        {
            return (from luggageRule in luggageRuleAdjacencyMatrix
                let currentColour = luggageRule.Key
                where luggageRule.Value[requiredColour] > 0
                select currentColour).ToList();
        }
    }
}