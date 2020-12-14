using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day13
{
    public class BusScheduleUtility
    {
        public static List<int> ConvertRawBusNumbers(string busNumbers)
        {
            var busNumbersList = new List<int>();

            var rawBusNumberList = busNumbers.Split(',').ToList();

            foreach (var rawBusNumber in rawBusNumberList)
            {
                if (int.TryParse(rawBusNumber, out var convertedBusNumber))
                {
                    busNumbersList.Add(convertedBusNumber);
                }
            }

            return busNumbersList;
        }

        public static (int busNumber, int waitTime) FindTheEarliestNextBus(List<int> busNumbersList, int currentTimeStamp)
        {
            var currentMinNextBus = busNumbersList[0];
            var currentMinWaitTime = CalculateWaitingTime(currentMinNextBus, currentTimeStamp);

            foreach (var busNumber in busNumbersList.GetRange(1, busNumbersList.Count - 1))
            {
                if (currentMinWaitTime <= CalculateWaitingTime(busNumber, currentTimeStamp)) continue;
                currentMinNextBus = busNumber;
                currentMinWaitTime = CalculateWaitingTime(busNumber, currentTimeStamp);
            }

            return (currentMinNextBus, currentMinWaitTime);
        }

        public static Dictionary<long, long> ConvertRawBusNumbersWithRemainders(string busNumbers)
        {
            var busNumbersWithRemainders = new Dictionary<long, long>();

            var rawBusNumberList = busNumbers.Split(',').ToList();

            var timesUntilNextBus = 0;

            foreach (var rawBusNumber in rawBusNumberList)
            {
                timesUntilNextBus += 1;
                if (!long.TryParse(rawBusNumber, out var convertedBusNumber)) continue;

                var currentBusNumber = convertedBusNumber;
                var currentRemainder = currentBusNumber - (timesUntilNextBus - 1) % currentBusNumber == currentBusNumber
                    ? 0
                    : currentBusNumber - (timesUntilNextBus - 1) % currentBusNumber;

                busNumbersWithRemainders.Add(currentBusNumber, currentRemainder);
            }

            return busNumbersWithRemainders;
        }

        private static int CalculateWaitingTime(int busNumber, int currentTimeStamp)
        {
            return busNumber - (currentTimeStamp % busNumber);
        }
    }
}