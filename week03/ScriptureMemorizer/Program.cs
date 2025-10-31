using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Clear();
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Welcome to the Scripture Memorizer!\n");
        Console.ResetColor();

        // 🌟 CREATIVE FEATURE: Library of scriptures to choose from
        List<(Reference, string)> scriptures = new List<(Reference, string)>()
        {
            (new Reference("John", 3, 16), "For God so loved the world that he gave his one and only Son, that whoever believes in him shall not perish but have eternal life."),
            (new Reference("Proverbs", 3, 5, 6), "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight."),
            (new Reference("Philippians", 4, 13), "I can do all things through Christ which strengthens me.")
        };

        Random random = new Random();
        var chosen = scriptures[random.Next(scriptures.Count)];
        Scripture scripture = new Scripture(chosen.Item1, chosen.Item2);

        // Display loop
        while (true)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine($"\nWords Remaining: {scripture.WordsRemaining()}");
            Console.WriteLine("\nPress ENTER to hide more words, or type 'quit' to end.");
            string input = Console.ReadLine();

            if (input?.ToLower() == "quit")
                break;

            if (!scripture.IsCompletelyHidden())
            {
                scripture.HideRandomWords(3); // hide 3 words at a time
            }

            if (scripture.IsCompletelyHidden())
            {
                Console.Clear();
                Console.WriteLine(scripture.GetDisplayText());
                Console.WriteLine("\nAll words are hidden! Well done!");
                break;
            }
        }

        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("\nProgram ended. Thank you for memorizing!");
        Console.ResetColor();
    }
}

/*
🌟 CREATIVITY EXPLANATION:
1. Added multiple scriptures — randomly selects one each run.
2. Improved hiding — only hides words that are still visible.
3. Displays progress (words remaining) for motivation.
4. Uses color for user experience.
These features exceed the basic requirements.
*/
