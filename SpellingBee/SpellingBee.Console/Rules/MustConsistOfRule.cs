
using SpellingBee.Base.RuntimeChecks;

namespace SpellingBee.Console.Rules
{
    public class MustConsistOfRule : IWordRule
    {
        private readonly char[] mustConsistOfChars;

        public MustConsistOfRule(params char[] mustConsistOfChars)
        {
            this.mustConsistOfChars = mustConsistOfChars
                .Select(c => char.ToLower(c))
                .ToArray();
        }

        public string GetDescription()
        {
            return $"Must consist of the following characters: {string.Join(", ", this.mustConsistOfChars)}";
        }

        public bool CheckWord(string word)
        {
            Argument.AssertNotEmpty(word, nameof(word));

            var wordLower = word.ToLower();

            foreach (var c in wordLower)
            {
                if (!this.mustConsistOfChars.Contains(c))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
