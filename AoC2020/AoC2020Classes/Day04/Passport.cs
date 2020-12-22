using System;
using System.Collections.Generic;
using System.Linq;

namespace AoC2020Classes.Day04
{
    public class Passport
    {
        public Passport(string passportEntry)
        {
            var passportDictionary = ConvertPassportEntryToDictionary(passportEntry);

            BirthYear = passportDictionary.ContainsKey("byr")
                ? ConvertNumeralStringToInt(passportDictionary["byr"])
                : default;

            IssueYear = passportDictionary.ContainsKey("iyr")
                ? ConvertNumeralStringToInt(passportDictionary["iyr"])
                : default;

            ExpiryYear = passportDictionary.ContainsKey("eyr")
                ? ConvertNumeralStringToInt(passportDictionary["eyr"])
                : default;

            Height = passportDictionary.ContainsKey("hgt")
                ? passportDictionary["hgt"].Trim()
                : default;

            HairColor = passportDictionary.ContainsKey("hcl")
                ? passportDictionary["hcl"].Trim()
                : default;

            EyeColor = passportDictionary.ContainsKey("ecl")
                ? passportDictionary["ecl"].Trim()
                : default;

            PassportId = passportDictionary.ContainsKey("pid")
                ? passportDictionary["pid"].Trim()
                : default;

            CountryId = passportDictionary.ContainsKey("cid")
                ? passportDictionary["cid"].Trim()
                : default;
        }

        public bool HasAllMandatoryFields => BirthYear.HasValue && IssueYear.HasValue && ExpiryYear.HasValue &&
                                             !string.IsNullOrEmpty(Height) && !string.IsNullOrEmpty(HairColor) &&
                                             !string.IsNullOrEmpty(EyeColor) &&
                                             !string.IsNullOrEmpty(PassportId);

        public bool HasAllFieldsValid => IsBirthYearInRange && IsIssueYearInRange && IsExpiryYearInRange &&
                                         IsHeightInRangeAndValid && IsHairColorValid && IsEyeColorValid &&
                                         IsPassportIdValid;

        public int? BirthYear { get; set; }
        public int? IssueYear { get; set; }
        public int? ExpiryYear { get; set; }
        public string Height { get; set; }
        public string HairColor { get; set; }
        public string EyeColor { get; set; }
        public string PassportId { get; set; }
        public string CountryId { get; set; }

        private bool IsBirthYearInRange => PassportValidator.ValidateBirthYear(BirthYear);
        private bool IsIssueYearInRange => PassportValidator.ValidateIssueYear(IssueYear);
        private bool IsExpiryYearInRange => PassportValidator.ValidateExpiryYear(ExpiryYear);
        private bool IsHeightInRangeAndValid => PassportValidator.ValidateHeight(Height);
        private bool IsHairColorValid => PassportValidator.ValidateHairColor(HairColor);
        private bool IsEyeColorValid => PassportValidator.ValidateEyeColor(EyeColor);
        private bool IsPassportIdValid => PassportValidator.ValidatePassportId(PassportId);

        private Dictionary<string, string> ConvertPassportEntryToDictionary(string passportEntry)
        {
            var passportDictionary = new Dictionary<string, string>();

            var fieldSeparator = new[] {"\r\n", " "};

            var passportFieldsList =
                passportEntry.Split(fieldSeparator, StringSplitOptions.RemoveEmptyEntries).ToList();

            foreach (var passportField in passportFieldsList)
            {
                var keyValuePairArray = passportField.Split(':');

                var key = keyValuePairArray[0];
                var value = keyValuePairArray[1];

                if (!passportDictionary.ContainsKey(key)) passportDictionary.Add(key, value);
            }

            return passportDictionary;
        }

        private int? ConvertNumeralStringToInt(string inputDigits)
        {
            int result;

            return int.TryParse(inputDigits, out result) ? result : default;
        }
    }
}