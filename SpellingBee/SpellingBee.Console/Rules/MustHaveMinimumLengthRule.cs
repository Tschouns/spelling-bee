namespace SpellingBee.Console.Rules
{
    public class MustHaveMinimumLengthRule : IWordRule
    {
        private readonly int minimumLength;

        public MustHaveMinimumLengthRule(int minimumLength)
        {
            this.minimumLength = minimumLength;
        }

        public bool CheckWord(string word)
        {
            return word.Length >= this.minimumLength;
        }
    }
}
