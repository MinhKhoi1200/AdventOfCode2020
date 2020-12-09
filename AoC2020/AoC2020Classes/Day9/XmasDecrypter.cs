using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day9
{
    public class XmasDecrypter
    {
        public static long FindMismatch(List<long> data, int preambleSize)
        {
            long mismatchData = 0;

            for (var preambleStartIndex = 0; preambleStartIndex < data.Count - preambleSize; preambleStartIndex++)
            {
                var preamble = data.GetRange(preambleStartIndex, preambleSize);

                var numberAfterPreamble = data[preambleStartIndex + preambleSize];

                if (IsNumberAfterAPreambleValid(preamble, numberAfterPreamble)) continue;

                mismatchData = numberAfterPreamble;
                break;

            }

            return mismatchData;
        }

        public static long FindWeakness(List<long> data, int preambleSize)
        {
            var mismatchData = FindMismatch(data, preambleSize);

            var testContiguous = FindContiguousSet(data, mismatchData);

            if (!testContiguous.Any()) return default;
            var weakness = testContiguous.Min() + testContiguous.Max();
            return weakness;

        }

        private static List<long> FindContiguousSet(List<long> data, long mismatchData)
        {
            var contiguousSetStartIndex = 0;

            while (data[contiguousSetStartIndex] != mismatchData && contiguousSetStartIndex < data.Count - 2)
            {
                var contiguousSetLength = 2;
                var contiguousSet = data.GetRange(contiguousSetStartIndex, contiguousSetLength);
                var contiguousSetSum = contiguousSet.Sum();

                while (contiguousSetSum < mismatchData && contiguousSetLength + contiguousSetStartIndex < data.Count)
                {
                    contiguousSetLength += 1;
                    contiguousSet = data.GetRange(contiguousSetStartIndex, contiguousSetLength);
                    contiguousSetSum = contiguousSet.Sum();
                }

                if (contiguousSetSum == mismatchData)
                {
                    return contiguousSet;
                }

                contiguousSetStartIndex += 1;
            }

            return null;

        }

        private static bool IsNumberAfterAPreambleValid(IReadOnlyList<long> preamble, long numberAfterPreamble)
        {
            var preambleSize = preamble.Count;
            for (var firstIndex = 0; firstIndex < preambleSize - 1; firstIndex++)
            {
                var firstPreambleNumber = preamble[firstIndex];

                for (var secondIndex = firstIndex + 1; secondIndex < preambleSize; secondIndex++)
                {
                    var secondPreambleNumber = preamble[secondIndex];

                    if (firstPreambleNumber + secondPreambleNumber == numberAfterPreamble)
                    {
                        return true;
                    }
                }
            }

            return false;
        }
    }
}