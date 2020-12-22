using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day06;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day06
    {
        private static readonly string[] Delimiter = {Environment.NewLine + Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day6InputText.txt", Delimiter);

        private static readonly List<GroupResponse>
            ConvertedInputList = InputList.ConvertAll(item => new GroupResponse(item));

        public static void SolvePartOne()
        {
            var totalUniqueYesQuestionsCount =
                ConvertedInputList.Sum(eachGroupResponse => eachGroupResponse.UniqueYesQuestions.Count);

            Console.WriteLine(totalUniqueYesQuestionsCount);
        }

        public static void SolvePartTwo()
        {
            var totalCommonYesQuestionsCount =
                ConvertedInputList.Sum(eachGroupResponse => eachGroupResponse.CommonYesQuestions.Count);

            Console.WriteLine(totalCommonYesQuestionsCount);
        }
    }
}