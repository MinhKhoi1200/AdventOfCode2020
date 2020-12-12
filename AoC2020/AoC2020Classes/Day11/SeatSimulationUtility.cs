using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day11
{
    public class SeatSimulationUtility
    {
        public static void UpdateSeatLayout(List<List<Tile>> seatLayout)
        {
            var rowsCount = seatLayout.Count;
            var columnsCount = seatLayout[0].Count;

            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {
                    var currentTile = seatLayout[rowIndex][columnIndex];

                    if (currentTile.ToBeSwapped)
                    {
                        switch (currentTile.TileStatus)
                        {
                            case TileStatus.Unknown:
                                break;
                            case TileStatus.Floor:
                                break;
                            case TileStatus.SeatEmpty:
                                seatLayout[rowIndex][columnIndex].TileStatus = TileStatus.SeatOccupied;
                                seatLayout[rowIndex][columnIndex].ToBeSwapped = false;
                                break;
                            case TileStatus.SeatOccupied:
                                seatLayout[rowIndex][columnIndex].TileStatus = TileStatus.SeatEmpty;
                                seatLayout[rowIndex][columnIndex].ToBeSwapped = false;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                }
            }
        }

        public static int CountAllVisibleOccupiedSeats(int currentRowIndex, int currentColumnIndex, List<List<Tile>> seatLayout)
        {
            return VisibleOccupiedSeatCountInDiagonalDir(currentRowIndex, currentColumnIndex, seatLayout) +
                   VisibleOccupiedSeatCountInHorizontalDir(currentRowIndex, currentColumnIndex, seatLayout) +
                   VisibleOccupiedSeatCountInVerticalDir(currentRowIndex, currentColumnIndex, seatLayout);
        }

        public static int CountAdjacentOccupiedSeat(int currentRowNumber, int currentColumnNumber,
            IReadOnlyList<List<Tile>> seatLayout)
        {
            var adjacentTiles = GetAdjacentTiles(currentRowNumber, currentColumnNumber, seatLayout);

            var neighbourOccupiedSeats = adjacentTiles.Count(tile => tile.TileStatus == TileStatus.SeatOccupied);

            return neighbourOccupiedSeats;
        }

        private static IEnumerable<Tile> GetAdjacentTiles(int currentRowNumber, int currentColumnNumber,
            IReadOnlyList<List<Tile>> seatLayout)
        {
            var adjacentTiles = new List<Tile>();
            var rowsCount = seatLayout.Count;
            var columnsCount = seatLayout[0].Count;

            for (var dRow = (currentRowNumber > 0 ? -1 : 0); dRow <= (currentRowNumber < rowsCount - 1 ? 1 : 0); dRow++)
            {
                for (var dColumn = (currentColumnNumber > 0 ? -1 : 0);
                    dColumn <= (currentColumnNumber < columnsCount - 1 ? 1 : 0);
                    dColumn++)
                {
                    if (dRow != 0 || dColumn != 0)
                    {
                        adjacentTiles.Add(seatLayout[currentRowNumber + dRow][currentColumnNumber + dColumn]);
                    }
                }
            }

            return adjacentTiles;
        }

        private static int VisibleOccupiedSeatCountInVerticalDir(int currentRowIndex, int currentColumnIndex,
            List<List<Tile>> seatLayout)
        {
            var rowsCount = seatLayout.Count;

            var visibleOccupiedSeatsCount = 0;

            // Look North
            for (var row = currentRowIndex - 1; row >= 0; row--)
            {
                if (LookingForwardUntilSeatIsEncountered(currentColumnIndex, seatLayout, row, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            // Look South
            for (var row = currentRowIndex + 1; row < rowsCount; row++)
            {
                if (LookingForwardUntilSeatIsEncountered(currentColumnIndex, seatLayout, row, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            return visibleOccupiedSeatsCount;
        }

        private static int VisibleOccupiedSeatCountInHorizontalDir(int currentRowIndex, int currentColumnIndex,
            List<List<Tile>> seatLayout)
        {
            var columnsCount = seatLayout[0].Count;

            var visibleOccupiedSeatsCount = 0;

            // Look West
            for (var column = currentColumnIndex - 1; column >= 0; column--)
            {
                if (LookingForwardUntilSeatIsEncountered(column, seatLayout, currentRowIndex, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            // Look East
            for (var column = currentColumnIndex + 1; column < columnsCount; column++)
            {
                if (LookingForwardUntilSeatIsEncountered(column, seatLayout, currentRowIndex, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            return visibleOccupiedSeatsCount;
        }

        private static int VisibleOccupiedSeatCountInDiagonalDir(int currentRowIndex, int currentColumnIndex,
            List<List<Tile>> seatLayout)
        {
            var rowsCount = seatLayout.Count;
            var columnsCount = seatLayout[0].Count;

            var northStepsLimit = currentRowIndex;
            var southStepsLimit = rowsCount - currentRowIndex - 1;

            var westStepsLimit = currentColumnIndex;
            var eastStepsLimit = columnsCount - currentColumnIndex - 1;

            var visibleOccupiedSeatsCount = 0;

            // Go North East
            var northEastStepsLimit = northStepsLimit > eastStepsLimit ? eastStepsLimit : northStepsLimit;
            for (var steps = 1; steps <= northEastStepsLimit; steps++)
            {
                if (LookingForwardUntilSeatIsEncountered(currentColumnIndex + steps, seatLayout,
                    currentRowIndex - steps, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            // Go North West
            var northWestStepsLimit = northStepsLimit > westStepsLimit ? westStepsLimit : northStepsLimit;
            for (var steps = 1; steps <= northWestStepsLimit; steps++)
            {
                if (LookingForwardUntilSeatIsEncountered(currentColumnIndex - steps, seatLayout,
                    currentRowIndex - steps, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            // Go South East
            var southEastStepsLimit = southStepsLimit > eastStepsLimit ? eastStepsLimit : southStepsLimit;
            for (var steps = 1; steps <= southEastStepsLimit; steps++)
            {
                if (LookingForwardUntilSeatIsEncountered(currentColumnIndex + steps, seatLayout,
                    currentRowIndex + steps, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            // Go South East
            var southWestStepsLimit = southStepsLimit > westStepsLimit ? westStepsLimit : southStepsLimit;
            for (var steps = 1; steps <= southWestStepsLimit; steps++)
            {
                if (LookingForwardUntilSeatIsEncountered(currentColumnIndex - steps, seatLayout,
                    currentRowIndex + steps, ref visibleOccupiedSeatsCount))
                    continue;
                break;
            }

            return visibleOccupiedSeatsCount;
        }

        private static bool LookingForwardUntilSeatIsEncountered(int currentColumnIndex, List<List<Tile>> seatLayout, int row,
            ref int visibleOccupiedSeatsCount)
        {
            switch (seatLayout[row][currentColumnIndex].TileStatus)
            {
                case TileStatus.Unknown:
                    break;
                case TileStatus.Floor:
                    return true;
                case TileStatus.SeatEmpty:
                    break;
                case TileStatus.SeatOccupied:
                    visibleOccupiedSeatsCount += 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return false;
        }

    }
}