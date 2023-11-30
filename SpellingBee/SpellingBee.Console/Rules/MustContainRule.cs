namespace SpellingBee.Console.Rules
{
    public class MustContainRule : IWordRule
    {
        private readonly char[] mustContainChars;

        public MustContainRule(params char[] mustContainChars)
        {
            this.mustContainChars = mustContainChars
                .Select(c => char.ToLower(c))
                .ToArray();
        }

        public bool CheckWord(string word)
        {
            var wordLower = word.ToLower();

            foreach (var c in this.mustContainChars)
            {
                if (!wordLower.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
