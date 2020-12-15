using System.Text.RegularExpressions;

namespace AoC2020Classes.Day14
{
    public class MemoryInstruction
    {
        public MemoryInstruction(string rawMemoryInstruction)
        {
            var memoryAddress = new Regex(@"(?<=\[)\d+(?=\])");
            var memoryContentRegex = new Regex(@"(?<=mem\[\d+\]\s=\s)\d+");

            Address = long.Parse(memoryAddress.Match(rawMemoryInstruction).Value);
            Content = long.Parse(memoryContentRegex.Match(rawMemoryInstruction).Value);
        }

        public override string ToString()
        {
            return $"mem [{Address}] = {Content}";
        }

        public long Address { get; }
        public long Content { get; }
    }
}