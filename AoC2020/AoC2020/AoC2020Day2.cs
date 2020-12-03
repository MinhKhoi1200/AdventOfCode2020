using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day2;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day2
    {
        private static List<string> inputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day2InputText.txt");
        private static List<PasswordItem> convertedInputList = inputList.ConvertAll(x => new PasswordItem(x)).ToList();

        public static void SolvePartOne()
        {
            var validPasswordsCount = convertedInputList.Count(passwordItem => passwordItem.ValidateFirstAttempt());
            Console.WriteLine(validPasswordsCount);
        }

        public static void SolvePartTwo()
        {
            var validPasswordsCount = convertedInputList.Count(passwordItem => passwordItem.ValidateOtcas());
            Console.WriteLine(validPasswordsCount);
        }


    }
}