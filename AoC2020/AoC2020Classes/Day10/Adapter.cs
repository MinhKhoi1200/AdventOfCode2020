using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day10
{
    public class Adapter
    {
        public Adapter(int outputJoltage)
        {
            OutputJoltage = outputJoltage;
        }

        public override string ToString()
        {
            return $"{OutputJoltage} jolts Adapter";
        }

        public int OutputJoltage { get; }

        public static List<Adapter> GenerateSortedListOfAdaptersJoltage(List<int> rawJoltageList)
        {
            var convertedList = rawJoltageList.ConvertAll(item => new Adapter(item));

            var inputAndOutputsJoltage = new List<Adapter>()
                {new Adapter(0), new Adapter(convertedList.Max(item => item.OutputJoltage) + 3)};

            convertedList.AddRange(inputAndOutputsJoltage);

            var sortedList = convertedList.OrderBy(item => item.OutputJoltage).ToList();

            return sortedList;
        }
    }
}