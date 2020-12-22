namespace AoC2020Classes.Day13
{
    public class CrtAlgebraicExp
    {
        public CrtAlgebraicExp(long multiplier, long xIndex, long remainder)
        {
            Multiplier = multiplier;
            XIndex = xIndex;
            Remainder = remainder;
        }


        public long Multiplier { get; }
        public long XIndex { get; }
        public long Remainder { get; }

        public override string ToString()
        {
            return $"{Multiplier} x_{XIndex} + {Remainder}";
        }

        /// <summary>
        ///     Substitute lower level algebraic expression into current expression. For Chinese Remainder theorem uses only.
        /// </summary>
        /// <param name="lowLevelAlgebraicExp">Lower level expression</param>
        /// <returns>New substituted expression</returns>
        public CrtAlgebraicExp Substitute(CrtAlgebraicExp lowLevelAlgebraicExp)
        {
            var newMultiplier = Multiplier * lowLevelAlgebraicExp.Multiplier;

            var newRemainder = lowLevelAlgebraicExp.Remainder * Multiplier + Remainder;

            return new CrtAlgebraicExp(newMultiplier, lowLevelAlgebraicExp.XIndex, newRemainder);
        }
    }
}