using SpellingBee.Console;
using SpellingBee.Console.Rules;

// Init.
var wordFilePath = "Data\\words_alpha.txt";
var rules = new IWordRule[]
{
    new MustHaveMinimumLengthRule(4),
    new MustContainRule('f'),
    //new MustContainRule('b', 'e', 'f', 'l', 'o', 't', 'u'),
    new MustConsistOfRule('b', 'e', 'f', 'l', 'o', 't', 'u'),
};

// Write rules.
foreach (var rule in rules)
{
    Console.WriteLine(rule.GetDescription());
}

var processor = new WordFileProcessor();
var isCancelled = false;
var count = 0;

//var task = Task.Run(() =>
//    {
//        processor.ProcessFile(
//            wordFilePath,
//            rules,
//            w =>
//            {
//                count++;
//                Console.WriteLine($"{count} > " + w);

//                // Slow down -- for testing the distributed IDE (WIPRO).
//                Thread.Sleep(200);
//            },
//            () => isCancelled);

//        Console.WriteLine("All done.");
//    });

processor.ProcessFile(
    wordFilePath,
    rules,
    w =>
    {
        count++;
        Console.WriteLine($"{count} > " + w);

        // Slow down -- for testing the distributed IDE (WIPRO).
        Thread.Sleep(200);
    },
    () => isCancelled);

Console.WriteLine("All done.");

//// Wait for user:
//Console.ReadLine();

//Console.WriteLine("User cancelled...");
//isCancelled = true;

//task.Wait();
//Console.WriteLine("Done.");

// Wait for user:
Thread.Sleep(2000);