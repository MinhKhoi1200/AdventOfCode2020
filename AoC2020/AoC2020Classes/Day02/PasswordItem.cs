using System.Linq;

namespace AoC2020Classes.Day02
{
    public class PasswordItem
    {
        public PasswordPolicy PwPolicy { get; set; }
        public string Password { get; set; }

        public PasswordItem(PasswordPolicy pwPolicy, string password)
        {
            PwPolicy = pwPolicy;
            Password = password;
        }

        public PasswordItem(string inputString)
        {
            var convertedPasswordItem = ConvertStringToPasswordItem(inputString);
            PwPolicy = convertedPasswordItem?.PwPolicy;
            Password = convertedPasswordItem?.Password;
        }

        public bool ValidateFirstAttempt()
        {
            var count = Password.Count(letter => letter.Equals(PwPolicy.Letter));

            return count <= PwPolicy.UpperBound && count >= PwPolicy.LowerBound;
        }

        public bool ValidateOtcas()
        {
            var lowerLetter = Password[PwPolicy.LowerBound - 1];
            var upperLetter = Password[PwPolicy.UpperBound - 1];

            var isLowerLetterMatched = lowerLetter == PwPolicy.Letter;
            var isUpperLetterMatched = upperLetter == PwPolicy.Letter;

            var isValid = (isLowerLetterMatched && !isUpperLetterMatched) ||
                          (isUpperLetterMatched && !isLowerLetterMatched);

            return isValid;
        }

        private PasswordItem ConvertStringToPasswordItem(string inputString)
        {
            var slittedPasswordItemString = inputString.Split(':');
            var passwordPolicy = new PasswordPolicy(slittedPasswordItemString[0]);
            var password = slittedPasswordItemString[1].Trim();
            return new PasswordItem(passwordPolicy, password);
        }
    }
}
