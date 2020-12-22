using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day13
{
    public class CrtSolver
    {
        public bool IsSolvable = true;

        public CrtSolver(Dictionary<long, long> divisorRemainderPairs)
        {
            DivisorRemainderPairs = divisorRemainderPairs;

            foreach (var key in DivisorRemainderPairs.Keys)
                if (!IsPrime(key))
                    IsSolvable = false;
        }

        public Dictionary<long, long> DivisorRemainderPairs { get; }

        public long Solve()
        {
            if (!IsSolvable) return 0;

            var sortedDivisors = DivisorRemainderPairs.Keys.OrderByDescending(i => i).ToList();

            var currentAlgExp = new CrtAlgebraicExp(sortedDivisors[0], 0, DivisorRemainderPairs[sortedDivisors[0]]);

            var xIndex = 0;

            foreach (var divisor in sortedDivisors.GetRange(1, sortedDivisors.Count - 1))
            {
                var currentModulo = divisor;
                var currentRemainder = DivisorRemainderPairs[divisor];

                var newAlgMultiplier = currentModulo;

                var newAlgRemainder = (currentRemainder - currentAlgExp.Remainder) % currentModulo < 0
                    ? currentModulo + (currentRemainder - currentAlgExp.Remainder) % currentModulo
                    : (currentRemainder - currentAlgExp.Remainder) % currentModulo;

                if (newAlgRemainder != 0)
                    for (var i = 1; i < currentModulo; i++)
                    {
                        if (currentAlgExp.Multiplier * i % currentModulo != 1) continue;
                        newAlgRemainder = newAlgRemainder * i < currentModulo
                            ? newAlgRemainder * i
                            : newAlgRemainder * i % currentModulo;

                        break;
                    }

                xIndex += 1;

                var newAlgExp = new CrtAlgebraicExp(newAlgMultiplier, xIndex, newAlgRemainder);

                currentAlgExp = currentAlgExp.Substitute(newAlgExp);
            }

            return currentAlgExp.Remainder;
        }

        private bool IsPrime(long number)
        {
            for (var i = 2; i < Math.Sqrt(number + 1); i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}