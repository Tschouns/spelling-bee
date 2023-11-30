﻿
using SpellingBee.Console.Rules;

namespace SpellingBee.Console
{
    public class WordFileProcessor
    {
        public void ProcessFile(string filePath, IEnumerable<IWordRule> rules, Action<string> foundWordCallback, Func<bool> cancel)
        {
            using var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            using var reader = new StreamReader(fileStream);

            var line = reader.ReadLine();

            while (line != null && !cancel())
            {
                var word = line.Trim();
                if (rules.All(r => r.CheckWord(word)))
                {
                    foundWordCallback(word);
                }

                line = reader.ReadLine();
            }
        }
    }
}
