using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace AoC2020Classes.Day14
{
    public class InitProgram
    {
        public InitProgram(List<string> rawProgram)
        {
            var rawProgramUnit = new List<string> {rawProgram[0]};

            var programUnitList = new List<InitProgramUnit>();

            var memoryInstructionRegex = new Regex(@"^mem");
            var bitMaskRegex = new Regex(@"^mask");

            foreach (var command in rawProgram.GetRange(1, rawProgram.Count - 1))
                if (memoryInstructionRegex.IsMatch(command))
                {
                    rawProgramUnit.Add(command);
                }
                else if (bitMaskRegex.IsMatch(command))
                {
                    programUnitList.Add(new InitProgramUnit(rawProgramUnit));
                    rawProgramUnit = new List<string> {command};
                }

            programUnitList.Add(new InitProgramUnit(rawProgramUnit));

            InitProgramUnits = programUnitList;

            MemoryHashTable = new Dictionary<long, long>();
        }

        public List<InitProgramUnit> InitProgramUnits { get; }
        public Dictionary<long, long> MemoryHashTable { get; }

        public void ExecuteV1()
        {
            FlushMemory();
            foreach (var initProgramUnit in InitProgramUnits)
            {
                var currentBitMask = initProgramUnit.BitMask;

                foreach (var memoryInstruction in initProgramUnit.MemoryInstructions)
                {
                    var currentAddress = memoryInstruction.Address;
                    var currentContent = memoryInstruction.Content;

                    var contentToBeAdded = BitMaskUtility.ApplyBitMaskToMemoryContent(currentBitMask, currentContent);

                    if (!MemoryHashTable.ContainsKey(currentAddress))
                        MemoryHashTable.Add(currentAddress, contentToBeAdded);
                    else
                        MemoryHashTable[currentAddress] = contentToBeAdded;
                }
            }
        }

        public void ExecuteV2()
        {
            FlushMemory();
            foreach (var initProgramUnit in InitProgramUnits)
            {
                var currentBitMask = initProgramUnit.BitMask;

                foreach (var memoryInstruction in initProgramUnit.MemoryInstructions)
                {
                    var currentAddress = memoryInstruction.Address;
                    var currentContent = memoryInstruction.Content;

                    var addressesToBeAdded = BitMaskUtility.ApplyBitMaskToMemoryAddress(currentBitMask, currentAddress);

                    foreach (var address in addressesToBeAdded)
                        if (!MemoryHashTable.ContainsKey(address))
                            MemoryHashTable.Add(address, currentContent);
                        else
                            MemoryHashTable[address] = currentContent;
                }
            }
        }

        private void FlushMemory()
        {
            MemoryHashTable.Clear();
        }
    }
}