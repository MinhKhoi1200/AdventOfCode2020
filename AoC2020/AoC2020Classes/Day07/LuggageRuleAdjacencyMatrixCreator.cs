using System.Collections.Generic;

namespace AoC2020Classes.Day07
{
    public class LuggageRuleAdjacencyMatrixCreator
    {
        private static Dictionary<string, Dictionary<string, int>> CreateEmptyAdjacencyDictionary(List<string> allColourList)
        {
            var outputDictionary = new Dictionary<string, Dictionary<string, int>>();
            foreach (var colour in allColourList)
            {
                var colourDictionary = new Dictionary<string, int>();
                foreach (var containingColour in allColourList)
                {
                    if (containingColour == colour)
                    {
                        colourDictionary.Add(containingColour, -1);
                    }
                    else
                    {
                        colourDictionary.Add(containingColour, 0);
                    }
                }

                outputDictionary.Add(colour, colourDictionary);
            }

            return outputDictionary;
        }

        public static Dictionary<string, Dictionary<string, int>> CreateAdjacencyDictionary(List<LuggageRule> luggageRuleList)
        {
            var allColourList = luggageRuleList.ConvertAll(eachLuggageRule => eachLuggageRule.Colour);

            var outputDictionary = CreateEmptyAdjacencyDictionary(allColourList);

            foreach (var luggageRule in luggageRuleList)
            {
                var luggageColourRule = luggageRule.Colour;

                foreach (var containingBag in luggageRule.ContainingBags)
                {
                    var containingColour = containingBag.Key;
                    var containingColourCount = containingBag.Value;

                    outputDictionary[luggageColourRule][containingColour] = containingColourCount;
                }
            }

            return outputDictionary;
        }
    }
}