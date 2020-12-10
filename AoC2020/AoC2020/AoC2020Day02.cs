using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day02;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day02
    {
        private static readonly string[] Delimiter = {"\r\n"};
        private static readonly List<string> InputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day2InputText.txt", Delimiter);
        private static readonly List<PasswordItem> ConvertedInputList = InputList.ConvertAll(x => new PasswordItem(x)).ToList();

        public static void SolvePartOne()
        {
            var validPasswordsCount = ConvertedInputList.Count(passwordItem => passwordItem.ValidateFirstAttempt());
            Console.WriteLine(validPasswordsCount);
        }

        public static void SolvePartTwo()
        {
            var validPasswordsCount = ConvertedInputList.Count(passwordItem => passwordItem.ValidateOtcas());
            Console.WriteLine(validPasswordsCount);
        }


    }
}