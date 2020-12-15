using System.Collections.Generic;

namespace AoC2020Classes.Day15
{
    public class MemoryGame
    {
        private int _lastNumber;
        public MemoryGame(IReadOnlyList<int> numberSeries)
        {
            _lastNumber = numberSeries[numberSeries.Count - 1];
            StartingTurn = numberSeries.Count;

            RecentNumbersAndTurns = new Dictionary<int, (int, int)>();

            var turn = 1;

            foreach (var number in numberSeries)
            {
                RecentNumbersAndTurns.Add(number, (0, turn));
                turn += 1;
            }
        }

        public int Play(int turnNumbers)
        {
            var nextNumber = _lastNumber;

            for (var index = StartingTurn; index < turnNumbers; index++)
            {
                _lastNumber = nextNumber;
                
                if (IsNumberRepeatedMoreThanOnce(_lastNumber))
                {
                    nextNumber = RecentNumbersAndTurns[_lastNumber].lastTurn -
                                 RecentNumbersAndTurns[_lastNumber].earlierTurn;
                }
                else
                {
                    nextNumber = 0;
                }

                UpdateRecentNumbersAndTurns(nextNumber, index + 1);

            }

            return nextNumber;

        }
        
        private int StartingTurn { get; }

        private Dictionary<int, (int earlierTurn, int lastTurn)> RecentNumbersAndTurns { get; set; }

        private bool IsNumberRepeatedMoreThanOnce(int number) =>
            RecentNumbersAndTurns[number].earlierTurn > 0;
        
        private void UpdateRecentNumbersAndTurns(int nextNumber, int turnNumber)
        {
            if (RecentNumbersAndTurns.ContainsKey(nextNumber))
            {
                RecentNumbersAndTurns[nextNumber] = (earlierTurn: RecentNumbersAndTurns[nextNumber].lastTurn,
                    lastTurn: turnNumber);
            }
            else
            {
                RecentNumbersAndTurns.Add(nextNumber, (earlierTurn: 0, lastTurn: turnNumber));
            }
        }

    }
}