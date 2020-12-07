using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC2020Classes.Day7
{
    public class LuggageRule
    {
        public LuggageRule(string rawBagString)
        {
            Colour = GetColourFromBagString(rawBagString);
            ContainingBags = GetContainingBagsFromBagString(rawBagString);
        }

        public string Colour { get; }
        public Dictionary<string, int> ContainingBags { get; }

        private static string GetColourFromBagString(string rawString)
        {
            var bagColourRegex = new Regex(@"^[\w\s]+(?=\sbags\scontain)");
            var outputColour = bagColourRegex.Match(rawString).Value;

            return outputColour;
        }

        private static Dictionary<string, int> GetContainingBagsFromBagString(string rawString)
        {
            var containingBagRegex = new Regex(@"\d[\w\s]+(?=\s)");
            var matches = containingBagRegex.Matches(rawString);

            var containingBagsDictionary = new Dictionary<string, int>();

            foreach (Match match in matches)
            {
                var matchString = match.Value;
                var number = int.Parse(matchString[0].ToString());
                var colour = matchString.Substring(2);

                containingBagsDictionary.Add(colour, number);
            }

            return containingBagsDictionary;
        }
        

        // get color from ^[\w\s]+(?=\sbags\scontain)
        // get containing bags from \d[\w\s]+(?=\s), what colours it contain (?<=\d\s)[\w\s]+(?=\s)
    }
}