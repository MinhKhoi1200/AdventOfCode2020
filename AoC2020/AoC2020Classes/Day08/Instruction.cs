namespace AoC2020Classes.Day08
{
    public class Instruction
    {
        public Instruction(string rawInstruction)
        {
            var splitRawInstruction = rawInstruction.Split(' ');
            Operation = ConvertRawOpCodeToEnumOpCode(splitRawInstruction[0]);
            Argument = int.Parse(splitRawInstruction[1]);
            TimesExecuted = 0;
        }

        public OpCode Operation { get; set; }
        public int Argument { get; }
        public int TimesExecuted { get; set; }

        public override string ToString()
        {
            return Operation + " " + Argument;
        }

        public void ResetTimesExecuted()
        {
            TimesExecuted = 0;
        }

        private static OpCode ConvertRawOpCodeToEnumOpCode(string rawOpCode)
        {
            switch (rawOpCode)
            {
                case "nop":
                    return OpCode.Nop;
                case "acc":
                    return OpCode.Acc;
                case "jmp":
                    return OpCode.Jmp;
                default:
                    return OpCode.Unknown;
            }
        }
    }
}