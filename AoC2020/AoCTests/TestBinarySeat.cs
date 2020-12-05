using AoC2020Classes.Day5;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCTests
{
    [TestClass]
    public class TestBinarySeat
    {
        [TestMethod]
        [DataRow("FBFBBFFRLR", 44, 5, 357)]
        [DataRow("BFFFBBFRRR", 70, 7, 567)]
        [DataRow("FFFBBBFRRR", 14, 7, 119)]
        [DataRow("BBFFBBFRLL", 102, 4, 820)]
        public void Test_BinarySeat_Row_number_Column_number_and_Seat_Id(string seatCode, int expectedRowNumber,
            int expectedColumnNumber, int expectedSeatId)
        {
            // Arrange
            var testSeat = new BinarySeat(seatCode);

            // Act
            var actualRowNumber = testSeat.RowNumber;
            var actualColumnNumber = testSeat.ColumnNumber;
            var actualSeatId = testSeat.SeatId;

            // Arrange
            Assert.AreEqual(expectedColumnNumber, actualColumnNumber);
            Assert.AreEqual(expectedRowNumber, actualRowNumber);
            Assert.AreEqual(expectedSeatId, actualSeatId);
        }
    }
}