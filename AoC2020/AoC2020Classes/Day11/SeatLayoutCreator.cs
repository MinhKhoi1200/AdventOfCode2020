using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day11
{
    public class SeatLayoutCreator
    {
        public static List<List<Tile>> CreateSeatPlan(List<string> rawSeatPlanRows)
        {
            return rawSeatPlanRows.ConvertAll(ConvertToSeatRowList);
        }

        private static List<Tile> ConvertToSeatRowList(string rawSeatRow)
        {
            var charTileList = rawSeatRow.ToCharArray().ToList();

            var tileList = charTileList.ConvertAll(eachChar => new Tile(eachChar));

            return tileList;
        }
    }
}