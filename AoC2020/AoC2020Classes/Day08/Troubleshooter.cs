using System;
using System.Collections.Generic;

namespace AoC2020Classes.Day08
{
    public class Troubleshooter
    {
        public List<Instruction> Instructions;

        public Troubleshooter(List<Instruction> instructions)
        {
            Instructions = instructions;
        }

        public void Troubleshoot()
        {
            var compiler = new Compiler(Instructions);
            compiler.Execute();

            var lineNumber = 0;

            foreach (var currentInstruction in Instructions)
            {
                lineNumber += 1;

                if (!SwapNopAndJmp(currentInstruction)) continue;

                var useOnceCompiler = new Compiler(Instructions);
                useOnceCompiler.Execute();

                var exitCode = useOnceCompiler.ExitCode;

                SwapNopAndJmp(currentInstruction);

                if (exitCode != 0) continue;

                Console.WriteLine(
                    $"Line {lineNumber} - {currentInstruction} was swapped. Program exited code 0. Accumulator value {useOnceCompiler.Accumulator}");

                break;
            }
        }

        private static bool SwapNopAndJmp(Instruction instruction)
        {
            if (instruction.Operation == OpCode.Jmp)
            {
                instruction.Operation = OpCode.Nop;
                return true;
            }

            if (instruction.Operation == OpCode.Nop)
            {
                instruction.Operation = OpCode.Jmp;
                return true;
            }

            return false;
        }
    }
}