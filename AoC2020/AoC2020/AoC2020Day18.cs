using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day18;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day18
    {
        private static readonly string[] Delimiter = { Environment.NewLine };

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day18InputText.txt", Delimiter);

        public static void SolvePartOne()
        {
            var operatorPrecedence = new Dictionary<string, int>{{"*", 0}, {"+", 0}};
            var sumList = InputList.ConvertAll(i => ExpressionUtility.EvaluateExpression(i, operatorPrecedence));
            Console.WriteLine(sumList.Sum());
        }

        public static void SolvePartTwo()
        {
            var operatorPrecedence = new Dictionary<string, int>{{"*", 0}, {"+", 1}};
            var sumList = InputList.ConvertAll(i => ExpressionUtility.EvaluateExpression(i, operatorPrecedence));
            Console.WriteLine(sumList.Sum());        }

    }
}