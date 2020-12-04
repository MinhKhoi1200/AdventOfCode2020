﻿using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day4;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day4
    {
        private static readonly string[] Delimiter = { "\n\n" };
        private static readonly List<string> InputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day4InputText.txt", Delimiter);
        private static List<Passport> PassportList = InputList.ConvertAll(item => new Passport(item)).ToList();

        public static void SolvePartOne()
        {
            var passportsWithMandatoryFieldsCounts = PassportList.Count(passport => passport.HasAllMandatoryFields);

            Console.WriteLine(passportsWithMandatoryFieldsCounts);
        }

        public static void SolvePartTwo()
        {
            var passportsWithValidMandatoryFieldsCounts = PassportList.Count(passport => passport.HasAllFieldsValid);

            Console.WriteLine(passportsWithValidMandatoryFieldsCounts);
        }
    }
}