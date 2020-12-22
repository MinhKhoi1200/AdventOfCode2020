using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020Classes.Day18
{
    public static class ExpressionUtility
    {
        public static long EvaluateExpression(string rawExpression, Dictionary<string, int> operatorPrecedence)
        {
            var tokens = Tokenise(rawExpression);
            var rpnExpression = RpnUtility.ConvertToRpn(tokens, operatorPrecedence);
            var result = RpnUtility.EvaluateRpn(rpnExpression);

            return result;
        }

        private static IEnumerable<string> Tokenise(string rawExpression)
        {
            var firstRoundConversion = rawExpression.Split(' ').ToList();

            var secondRoundConversion = new List<string>();

            foreach (var item in firstRoundConversion) secondRoundConversion.AddRange(SeparateBrackets(item));

            return secondRoundConversion;
        }

        private static IEnumerable<string> SeparateBrackets(string numberWithBrackets)
        {
            if (!(numberWithBrackets.Contains('(') || numberWithBrackets.Contains(')')))
                return new List<string> {numberWithBrackets};
            var outputList = new List<string>();

            var digitsRegex = new Regex(@"\d+");
            var openBracketRegex = new Regex(@"\(+");
            var closeBracketRegex = new Regex(@"\)+");

            var openBrackets = openBracketRegex.Match(numberWithBrackets).Value.ToCharArray().Select(c => c.ToString())
                .ToList();

            var closeBrackets = closeBracketRegex.Match(numberWithBrackets).Value.ToCharArray()
                .Select(c => c.ToString())
                .ToList();

            var digits = digitsRegex.Match(numberWithBrackets).Value.ToCharArray().Select(c => c.ToString())
                .ToList();

            outputList.AddRange(openBrackets);
            outputList.AddRange(digits);
            outputList.AddRange(closeBrackets);

            return outputList;
        }
    }
}