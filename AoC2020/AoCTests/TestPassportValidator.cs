using AoC2020Classes.Day04;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AoCTests
{
    [TestClass]
    public class TestPassportValidator
    {
        [TestMethod]
        [DataRow(1910, false)]
        [DataRow(1920, true)]
        [DataRow(1975, true)]
        [DataRow(2002, true)]
        [DataRow(2012, false)]
        public void BirthYear_should_be_in_between_1920_and_2002_inclusive(int year, bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidateBirthYear(year);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [DataRow(2003, false)]
        [DataRow(2010, true)]
        [DataRow(2016, true)]
        [DataRow(2020, true)]
        [DataRow(2022, false)]
        public void IssueYear_should_be_in_between_2010_and_2020_inclusive(int year, bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidateIssueYear(year);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [DataRow(2003, false)]
        [DataRow(2020, true)]
        [DataRow(2025, true)]
        [DataRow(2030, true)]
        [DataRow(2040, false)]
        public void ExpiryYear_should_be_in_between_2020_and_2030_inclusive(int year, bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidateExpiryYear(year);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [DataRow("163cm", true)]
        [DataRow("123cm", false)]
        [DataRow("200cm", false)]
        [DataRow("69in", true)]
        [DataRow("100in", false)]
        [DataRow("23in", false)]
        [DataRow("129cn", false)]
        [DataRow("d29cn", false)]
        public void Height_should_be_in_in_or_cm_and_with_in_range(string height, bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidateHeight(height);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [DataRow("#123456", true)]
        [DataRow("#abcdef", true)]
        [DataRow("#123abc", true)]
        [DataRow("#123abc1", false)]
        [DataRow("#1", false)]
        [DataRow("#qwerty", false)]
        [DataRow("123456", false)]
        public void Hair_Color_should_have_a_hashtag_followed_by_exactly_six_characters_0_9_or_a_f(string hairColor,
            bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidateHairColor(hairColor);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [DataRow("brn", true)]
        [DataRow("wat", false)]
        public void Eye_Color_only_has_certain_valid_values(string eyeColor, bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidateEyeColor(eyeColor);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        [DataRow("000000001", true)]
        [DataRow("0123456789", false)]
        public void PassportId_should_have_nine_digits_including_leading_zeroes(string passportId, bool expectedOutput)
        {
            // Act
            var actualOutput = PassportValidator.ValidatePassportId(passportId);

            // Assert
            Assert.AreEqual(expectedOutput, actualOutput);
        }
    }
}