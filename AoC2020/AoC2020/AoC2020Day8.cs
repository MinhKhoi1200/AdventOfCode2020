using System;
using System.Collections.Generic;
using System.Diagnostics;
using AoC2020Classes.Day8;
using AoC2020Core;
using Debugger = AoC2020Classes.Day8.Debugger;

namespace AoC2020
{
    public class AoC2020Day8
    {
        private static readonly string[] Delimiter = { Environment.NewLine };
        private static readonly List<string> InputList = ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day8InputText.txt", Delimiter);

        private static readonly List<Instruction>
            ConvertedInputList = InputList.ConvertAll(item => new Instruction(item));

        private static readonly Compiler LoadedCompiler = new Compiler(ConvertedInputList);
        private static readonly Debugger LoadedDebugger = new Debugger(ConvertedInputList);

        public static void SolvePartOne()
        {
            LoadedCompiler.Execute();
            Console.WriteLine(LoadedCompiler.Accumulator);
        }

        public static void SolvePartTwo()
        {
            LoadedDebugger.Troubleshoot();
        }
    }
}