using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day11
{
    public class SeatSimulation
    {
        public SeatSimulation(List<List<Tile>> seatLayout)
        {
            SeatLayout = seatLayout;
            IsSimulationStable = false;
        }

        public void RunFullSimulation()
        {
            while (IsSimulationStable == false)
            {
                Scan();
                Update();
            }
        }

        public void Scan()
        {
            IsSimulationStable = true;

            var rowsCount = SeatLayout.Count;
            var columnsCount = SeatLayout[0].Count;

            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {
                    var currentTile = SeatLayout[rowIndex][columnIndex];
                    var neighbourOccupiedSeats = CountAdjacentOccupiedSeat(rowIndex, columnIndex);

                    if (currentTile.TileStatus == TileStatus.SeatEmpty && neighbourOccupiedSeats == 0 ||
                        currentTile.TileStatus == TileStatus.SeatOccupied && neighbourOccupiedSeats >= 4)
                    {
                        SeatLayout[rowIndex][columnIndex].ToBeSwapped = true;
                        IsSimulationStable = false;
                    }
                }
            }
        }

        public void Update()
        {
            var rowsCount = SeatLayout.Count;
            var columnsCount = SeatLayout[0].Count;

            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {
                    var currentTile = SeatLayout[rowIndex][columnIndex];

                    if (currentTile.ToBeSwapped)
                    {
                        switch (currentTile.TileStatus)
                        {
                            case TileStatus.Unknown:
                                break;
                            case TileStatus.Floor:
                                break;
                            case TileStatus.SeatEmpty:
                                SeatLayout[rowIndex][columnIndex].TileStatus = TileStatus.SeatOccupied;
                                SeatLayout[rowIndex][columnIndex].ToBeSwapped = false;
                                break;
                            case TileStatus.SeatOccupied:
                                SeatLayout[rowIndex][columnIndex].TileStatus = TileStatus.SeatEmpty;
                                SeatLayout[rowIndex][columnIndex].ToBeSwapped = false;
                                break;
                            default:
                                throw new ArgumentOutOfRangeException();
                        }
                    }

                }
            }

        }

        public List<List<Tile>> SeatLayout { get; }
        public bool IsSimulationStable { get; set; }

        private int CountAdjacentOccupiedSeat(int currentRowNumber, int currentColumnNumber)
        {
            var neighbourOccupiedSeats = 0;

            var adjacentTiles = GetAdjacentTiles(currentRowNumber, currentColumnNumber);

            neighbourOccupiedSeats = adjacentTiles.Count(tile => tile.TileStatus == TileStatus.SeatOccupied);

            return neighbourOccupiedSeats;
        }

        private IEnumerable<Tile> GetAdjacentTiles(int currentRowNumber, int currentColumnNumber)
        {
            var adjacentTiles = new List<Tile>();
            var rowsCount = SeatLayout.Count;
            var columnsCount = SeatLayout[0].Count;

            for (var dRow = (currentRowNumber > 0 ? -1 : 0); dRow <= (currentRowNumber < rowsCount - 1 ? 1 : 0); dRow++)
            {
                for (var dColumn = (currentColumnNumber > 0 ? -1 : 0); dColumn <= (currentColumnNumber < columnsCount - 1 ? 1 : 0); dColumn++)
                {
                    if (dRow != 0 || dColumn != 0)
                    {
                        adjacentTiles.Add(SeatLayout[currentRowNumber + dRow][currentColumnNumber + dColumn]);
                    }
                }
            }

            return adjacentTiles;
        }
    }
}