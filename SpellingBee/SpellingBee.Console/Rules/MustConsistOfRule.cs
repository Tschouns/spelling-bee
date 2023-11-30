﻿
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

        public bool CheckWord(string word)
        {
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