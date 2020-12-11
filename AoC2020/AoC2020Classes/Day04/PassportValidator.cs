using System.Linq;
using System.Text.RegularExpressions;

namespace AoC2020Classes.Day04
{
    public class PassportValidator
    {
        public static bool ValidateBirthYear(int? year)
        {
            return ValidateYear(year, 1920, 2002);
        }

        public static bool ValidateIssueYear(int? year)
        {
            return ValidateYear(year, 2010, 2020);
        }
        public static bool ValidateExpiryYear(int? year)
        {
            return ValidateYear(year, 2020, 2030);
        }

        public static bool ValidateHeight(string height)
        {
            if (string.IsNullOrEmpty(height))
            {
                return false;
            }

            var heightNumberRegex = new Regex(@"^\d+");
            var heightUnitRegex = new Regex(@"(cm|in)$");
            
            var isHeightNumberValid = heightNumberRegex.IsMatch(height);
            var isHeightUnitValid = heightUnitRegex.IsMatch(height);

            if (!isHeightUnitValid || !isHeightNumberValid) return false;

            var heightNumber = int.Parse(heightNumberRegex.Match(height).Value);
            var heightUnit = heightUnitRegex.Match(height).Value;

            var isHeightNumberWithinRange = heightUnit == "cm"
                ? (heightNumber >= 150 && heightNumber <= 193)
                : (heightNumber >= 59 && heightNumber <= 76);

            return isHeightNumberWithinRange;
        }

        public static bool ValidateHairColor(string hairColor)
        {
            if (string.IsNullOrEmpty(hairColor))
            {
                return false;
            }

            var hairColorRegex = new Regex(@"^#[0-9a-f]{6}$");
            return hairColorRegex.IsMatch(hairColor.Trim());
        }

        public static bool ValidateEyeColor(string eyeColor)
        {
            if (string.IsNullOrEmpty(eyeColor))
            {
                return false;
            }

            var validEyeColor = new string[]{ "amb", "blu", "brn", "gry", "grn", "hzl", "oth" };
            return validEyeColor.Contains(eyeColor);
        }

        public static bool ValidatePassportId(string passportId)
        {
            if (string.IsNullOrEmpty(passportId))
            {
                return false;
            }

            return passportId.Length == 9;
        }

        private static bool ValidateYear(int? year, int lowerBound, int upperBound)
        {
            if (!year.HasValue)
            {
                return false;
            }
            return year <= upperBound && year >= lowerBound;
        }
    }
}