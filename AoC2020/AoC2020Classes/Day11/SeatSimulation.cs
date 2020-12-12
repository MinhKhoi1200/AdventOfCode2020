using System.Collections.Generic;

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

        public void RunFullSimulationNewRules()
        {
            while (IsSimulationStable == false)
            {
                ScanNewRules();
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
                    var neighbourOccupiedSeats =
                        SeatSimulationUtility.CountAdjacentOccupiedSeat(rowIndex, columnIndex, SeatLayout);

                    if (currentTile.TileStatus == TileStatus.SeatEmpty && neighbourOccupiedSeats == 0 ||
                        currentTile.TileStatus == TileStatus.SeatOccupied && neighbourOccupiedSeats >= 4)
                    {
                        SeatLayout[rowIndex][columnIndex].ToBeSwapped = true;
                        IsSimulationStable = false;
                    }
                }
            }
        }

        public void ScanNewRules()
        {
            IsSimulationStable = true;

            var rowsCount = SeatLayout.Count;
            var columnsCount = SeatLayout[0].Count;

            for (var rowIndex = 0; rowIndex < rowsCount; rowIndex++)
            {
                for (var columnIndex = 0; columnIndex < columnsCount; columnIndex++)
                {
                    var currentTile = SeatLayout[rowIndex][columnIndex];
                    var visibleOccupiedSeatsCount = SeatSimulationUtility.CountAllVisibleOccupiedSeats(rowIndex, columnIndex, SeatLayout);

                    if (currentTile.TileStatus == TileStatus.SeatEmpty && visibleOccupiedSeatsCount == 0 ||
                        currentTile.TileStatus == TileStatus.SeatOccupied && visibleOccupiedSeatsCount >= 5)
                    {
                        SeatLayout[rowIndex][columnIndex].ToBeSwapped = true;
                        IsSimulationStable = false;
                    }
                }
            }
        }

        public void Update() => SeatSimulationUtility.UpdateSeatLayout(SeatLayout);


        public List<List<Tile>> SeatLayout { get; }
        public bool IsSimulationStable { get; set; }

    }
}