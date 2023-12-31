﻿using SpellingBee.Base.RuntimeChecks;

namespace SpellingBee.Console.Rules
{
    public class MustHaveMinimumLengthRule : IWordRule
    {
        private readonly int minimumLength;

        public MustHaveMinimumLengthRule(int minimumLength)
        {
            this.minimumLength = minimumLength;
        }

        public string GetDescription()
        {
            return $"Must have a minimum length of {this.minimumLength} characters.";
        }

        public bool CheckWord(string word)
        {
            Argument.AssertNotEmpty(word, nameof(word));

            return word.Length >= this.minimumLength;
        }
    }
}
