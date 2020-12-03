namespace AoC2020Classes.Day2
{
    public class PasswordPolicy
    {
        public PasswordPolicy(int lowerBound, int upperBound, char letter)
        {
            LowerBound = lowerBound;
            UpperBound = upperBound;
            Letter = letter;
        }

        public PasswordPolicy(string passwordPolicyString)
        {
            var convertedPasswordPolicy = ConvertStringToPasswordPolicy(passwordPolicyString);

            LowerBound = convertedPasswordPolicy.LowerBound;
            UpperBound = convertedPasswordPolicy.UpperBound;
            Letter = convertedPasswordPolicy.Letter;
        }

        private PasswordPolicy ConvertStringToPasswordPolicy(string passwordPolicyString)
        {
            var slittedPasswordPolicy = passwordPolicyString.Split(' ');
            var slittedBound = slittedPasswordPolicy[0].Split('-');

            var lowerBound = int.Parse(slittedBound[0]);
            var upperBound = int.Parse(slittedBound[1]);
            var letter = char.Parse(slittedPasswordPolicy[1]);

            return new PasswordPolicy(lowerBound, upperBound, letter);
        }

        public int LowerBound { get; set; }
        public int UpperBound { get; set; }
        public char Letter { get; set; }
    }
}