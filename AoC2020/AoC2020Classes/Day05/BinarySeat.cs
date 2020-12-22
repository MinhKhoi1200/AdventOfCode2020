namespace AoC2020Classes.Day05
{
    public class BinarySeat
    {
        public BinarySeat(string seatCode)
        {
            SeatCode = seatCode;

            (RowNumber, ColumnNumber) = ConvertSeatCodeToSeatPosition();

            SeatId = ConvertSeatPositionToSeatId();
        }

        public string SeatCode { get; }
        public int SeatId { get; }
        public int RowNumber { get; }
        public int ColumnNumber { get; }

        public override string ToString()
        {
            var outputString = ConvertSeatItemToString();

            return outputString;
        }

        private (int rowNumber, int columnNumber) ConvertSeatCodeToSeatPosition()
        {
            var frontBackPartition = SeatCode.Substring(0, 7);
            var leftRightPartition = SeatCode.Substring(7);

            var rowNumber = ConvertFrontPackPartitionToRowNumber(frontBackPartition);
            var columnNumber = ConvertLeftRightPartitionToColumnNumber(leftRightPartition);

            return (rowNumber, columnNumber);
        }

        private int ConvertSeatPositionToSeatId()
        {
            return RowNumber * 8 + ColumnNumber;
        }

        private string ConvertSeatItemToString()
        {
            var frontBackPartition = SeatCode.Substring(0, 7);
            var leftRightPartition = SeatCode.Substring(7);

            var outputString = "";
            foreach (var character in frontBackPartition)
            {
                var charToConcat = character == 'F' ? "▓" : "░";
                outputString += charToConcat;
            }

            outputString += ' ';

            foreach (var character in leftRightPartition)
            {
                var charToConcat = character == 'L' ? "▓" : "░";
                outputString += charToConcat;
            }

            outputString += $" {SeatId}";
            return outputString;
        }

        private int ConvertFrontPackPartitionToRowNumber(string frontBackPartition)
        {
            var rowUpperBound = 127;
            var rowLowerBound = 0;
            foreach (var character in frontBackPartition)
            {
                var rowMiddle = (rowUpperBound + rowLowerBound) / 2;
                switch (character)
                {
                    case 'F':
                        rowUpperBound = rowMiddle;
                        break;
                    case 'B':
                        rowLowerBound = rowMiddle + 1;
                        break;
                }
            }

            var rowNumber = rowLowerBound;
            return rowNumber;
        }

        private int ConvertLeftRightPartitionToColumnNumber(string leftRightPartition)
        {
            var columnUpperBound = 7;
            var columnLowerBound = 0;
            foreach (var character in leftRightPartition)
            {
                var rowMiddle = (columnUpperBound + columnLowerBound) / 2;
                switch (character)
                {
                    case 'L':
                        columnUpperBound = rowMiddle;
                        break;
                    case 'R':
                        columnLowerBound = rowMiddle + 1;
                        break;
                }
            }

            var columnNumber = columnLowerBound;
            return columnNumber;
        }
    }
}