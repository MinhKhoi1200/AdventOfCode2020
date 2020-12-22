using System;
using System.Collections.Generic;
using System.Linq;
using AoC2020Classes.Day14;
using AoC2020Core;

namespace AoC2020
{
    public class AoC2020Day14
    {
        private static readonly string[] Delimiter = {Environment.NewLine};

        private static readonly List<string> InputList =
            ReadInput.ConvertInputTextToStringList(@"..\..\..\Inputs\Day14InputText.txt", Delimiter);

        private static readonly InitProgram InitialiseProgram = new InitProgram(InputList);

        public static void SolvePartOne()
        {
            InitialiseProgram.ExecuteV1();
            Console.WriteLine(InitialiseProgram.MemoryHashTable.Values.ToList().Sum());
        }

        public static void SolvePartTwo()
        {
            // InitialiseProgram.ExecuteV2();
            InitialiseProgram.ExecuteV2();
            Console.WriteLine(InitialiseProgram.MemoryHashTable.Values.ToList().Sum());
        }
    }
}