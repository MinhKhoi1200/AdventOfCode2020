using System;
using System.Collections.Generic;

namespace AoC2020Classes.Day08
{
    public class Compiler
    {
        public Compiler(List<Instruction> instructions)
        {
            Instructions = instructions;
            Accumulator = 0;
            Index = 0;
            ExitCode = -99;
        }

        public List<Instruction> Instructions { get; }
        public int Accumulator { get; set; }
        public int Index { get; set; }
        public int ExitCode { get; set; }

        public void Execute()
        {
            var instructionsCount = Instructions.Count;

            while (Index < instructionsCount || Index < 0)
            {
                var currentInstruction = Instructions[Index];
                currentInstruction.TimesExecuted += 1;

                if (currentInstruction.TimesExecuted > 1) break;

                ExecuteOneInstruction(currentInstruction);
            }

            ExitCode = GetExitCode();
            ResetAllInstructionsTimesExecuted();
        }

        private void ExecuteOneInstruction(Instruction currentInstruction)
        {
            switch (currentInstruction.Operation)
            {
                case OpCode.Unknown:
                    throw new ArgumentOutOfRangeException($"Unknown instruction - {currentInstruction} ");
                case OpCode.Nop:
                    Index += 1;
                    break;
                case OpCode.Acc:
                    Accumulator += currentInstruction.Argument;
                    Index += 1;
                    break;
                case OpCode.Jmp:
                    Index += currentInstruction.Argument;
                    break;
                default:
                    throw new ArgumentOutOfRangeException($"Unexpected error when  executing {currentInstruction} ");
            }
        }

        private int GetExitCode()
        {
            int exitCode;

            if (Index < Instructions.Count)
                exitCode = 1;
            else if (Index == Instructions.Count)
                exitCode = 0;
            else if (Index > Instructions.Count)
                exitCode = -1;
            else
                exitCode = -99;

            return exitCode;
        }

        private void ResetAllInstructionsTimesExecuted()
        {
            foreach (var instruction in Instructions) instruction.ResetTimesExecuted();
        }
    }
}