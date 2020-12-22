using System;
using System.Collections.Generic;
using AoC2020Classes.Day08;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day08
    {
        private static readonly string[] Delimiter = {Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day8InputText.txt", Delimiter);

        private static readonly List<Instruction>
            ConvertedInputList = InputList.ConvertAll(item => new Instruction(item));

        private static readonly Compiler LoadedCompiler = new Compiler(ConvertedInputList);
        private static readonly Troubleshooter LoadedTroubleshooter = new Troubleshooter(ConvertedInputList);

        public static void SolvePartOne()
        {
            LoadedCompiler.Execute();
            Console.WriteLine(LoadedCompiler.Accumulator);
        }

        public static void SolvePartTwo()
        {
            LoadedTroubleshooter.Troubleshoot();
        }
    }
}