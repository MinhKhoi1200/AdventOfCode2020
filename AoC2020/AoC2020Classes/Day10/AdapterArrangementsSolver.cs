using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day10
{
    public class AdapterArrangementsSolver
    {
        private static readonly Dictionary<string, long> RecursionStateCache = new Dictionary<string, long>();

        public static long CountAllArrangements(Adapter startAdapter, List<Adapter> middleAdapters, Adapter endAdapter)
        {
            long output;

            var currentRecursionState = GetRecursionStateString(startAdapter, middleAdapters, endAdapter);

            if (RecursionStateCache.ContainsKey(currentRecursionState))
            {
                return RecursionStateCache[currentRecursionState];
            }

            if (!middleAdapters.Any())
            {
                var startEndDiff = endAdapter.OutputJoltage - startAdapter.OutputJoltage;
                output = startEndDiff > 3 ? 0 : 1;
            }
            else
            {
                if (!IsAdapterArrangementLegal(startAdapter, middleAdapters, endAdapter)) return 0;

                var nextLevelMiddleAdapter = middleAdapters.GetRange(0, middleAdapters.Count - 1);

                var leftArrangementsCount = CountAllArrangements(startAdapter, nextLevelMiddleAdapter, endAdapter);
                var rightArrangementCount = CountAllArrangements(startAdapter, nextLevelMiddleAdapter,
                    middleAdapters[middleAdapters.Count - 1]);

                output = leftArrangementsCount + rightArrangementCount;

                RecursionStateCache.Add(currentRecursionState, output);
            }

            return output;

        }

        private static bool IsAdapterArrangementLegal(Adapter startAdapter, List<Adapter> middleAdapters,
            Adapter endAdapter)
        {
            if (middleAdapters[0].OutputJoltage - startAdapter.OutputJoltage > 3)
            {
                return false;
            }

            if (endAdapter.OutputJoltage - middleAdapters[middleAdapters.Count - 1].OutputJoltage  > 3)
            {
                return false;
            }

            for (var firstIndex = 0; firstIndex < middleAdapters.Count - 1; firstIndex++)
            {
                var firstAdapter = middleAdapters[firstIndex];
                var secondAdapter = middleAdapters[firstIndex + 1];

                if (secondAdapter.OutputJoltage - firstAdapter.OutputJoltage > 3)
                    return false;
            }

            return true;
        }

        private static string GetRecursionStateString(Adapter startAdapter, List<Adapter> middleAdapters,
            Adapter endAdapter)
        {
            var middleAdaptersString =
                string.Join(" ", middleAdapters.ConvertAll(item => item.OutputJoltage.ToString()));

            return $"{startAdapter.OutputJoltage} {middleAdaptersString} {endAdapter.OutputJoltage}";
        }
    }
}