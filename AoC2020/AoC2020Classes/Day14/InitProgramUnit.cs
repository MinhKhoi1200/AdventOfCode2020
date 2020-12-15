using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020Classes.Day14
{
    public class InitProgramUnit
    {
        public InitProgramUnit(List<string> rawProgramUnits)
        {
            var bitMaskRegex = new Regex(@"(?<=mask\s=\s)[1|0|X]+");

            BitMask = bitMaskRegex.Match(rawProgramUnits[0]).Value;

            var convertedMemoryInstruction = rawProgramUnits.GetRange(1, rawProgramUnits.Count - 1)
                .Select(rawProgramUnit => new MemoryInstruction(rawProgramUnit)).ToList();

            MemoryInstructions = convertedMemoryInstruction;
        }

        public string BitMask { get; }
        public List<MemoryInstruction> MemoryInstructions { get; }
    }
}