// See https://aka.ms/new-console-template for more information
using SpellingBee.Console;
using SpellingBee.Console.Rules;

Console.WriteLine("Hello, World!");

var wordFilePath = "Data\\words_alpha.txt";
var rules = new IWordRule[]
{
    new MustHaveMinimumLengthRule(4),
    new MustContainRule('i'),
    new MustConsistOfRule('a', 'c', 'i', 'm', 'o', 'r', 't'),
};

var processor = new WordFileProcessor();
var isCancelled = false;
var count = 0;
var task = Task.Run(() =>
    {
        processor.ProcessFile(
            wordFilePath,
            rules,
            w =>
            {
                count++;
                Console.WriteLine($"{count} > " + w);
            },
            () => isCancelled);

        Console.WriteLine("All done.");
    });

// Wait for user:
Console.ReadLine();

Console.WriteLine("User cancelled...");
isCancelled = true;

task.Wait();
Console.WriteLine("Done.");

// Wait for user:
Console.ReadLine();