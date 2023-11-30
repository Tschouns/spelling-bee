// See https://aka.ms/new-console-template for more information
using SpellingBee.Console;
using SpellingBee.Console.Rules;

Console.WriteLine("Hello, World!");

var wordFilePath = "Data\\words_alpha.txt";
var rules = new IWordRule[]
{
    new MustContainRule('i'),
    new MustConsistOfRule('a', 'c', 'i', 'm', 'o', 'r', 't'),
};

var processor = new WordFileProcessor();
var isCancelled = false;
var task = Task.Run(() =>
    {
        processor.ProcessFile(
            wordFilePath,
            rules,
            w => Console.WriteLine("> " + w),
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