using System;
using System.IO;

class Program
{
    // Path for simple activity log (creative/exceeding requirement implemented)
    private static string _logFilePath = "mindfulness_log.txt";

    static void Main(string[] args)
    {
        Console.Title = "Mindfulness Program";
        bool quit = false;

        while (!quit)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("===================");
            Console.WriteLine("Please choose an option:");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflecting Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. View Activity Log");
            Console.WriteLine("5. Quit");
            Console.Write("Enter choice (1-5): ");

            string? choice = Console.ReadLine();
            if (choice == null) continue;

            switch (choice.Trim())
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.Run();
                    PauseBeforeContinue();
                    break;
                case "2":
                    var reflecting = new ReflectingActivity();
                    reflecting.Run();
                    PauseBeforeContinue();
                    break;
                case "3":
                    var listing = new ListingActivity();
                    listing.Run();
                    PauseBeforeContinue();
                    break;
                case "4":
                    ShowLog();
                    PauseBeforeContinue();
                    break;
                case "5":
                    quit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number from 1 to 5.");
                    Thread.Sleep(1200);
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void PauseBeforeContinue()
    {
        Console.WriteLine();
        Console.WriteLine("Press Enter to return to the menu.");
        Console.ReadLine();
    }

    // Appends a simple log line to the log file. This satisfies the 'exceeding requirements' idea.
    public static void LogActivity(string activityName, int duration)
    {
        try
        {
            string timestamp = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            string line = $"{timestamp} - {activityName} - {duration} seconds";
            File.AppendAllText(_logFilePath, line + Environment.NewLine);
        }
        catch
        {
            // If logging fails, do not crash the program.
        }
    }

    private static void ShowLog()
    {
        Console.Clear();
        Console.WriteLine("Activity Log");
        Console.WriteLine("=============");
        if (File.Exists(_logFilePath))
        {
            string[] lines = File.ReadAllLines(_logFilePath);
            if (lines.Length == 0)
            {
                Console.WriteLine("(log is empty)");
            }
            else
            {
                foreach (var line in lines)
                {
                    Console.WriteLine(line);
                }
            }
        }
        else
        {
            Console.WriteLine("(no log file found)");
        }
    }
}

/*
 * Creativity & Exceeding Core Requirements:
 * - Implemented a simple activity logging system that appends a timestamped line to mindfulness_log.txt
 *   so the user (or instructor) can see what activities were completed and when.
 * - Ensured that prompts/questions are not repeated until they have all been used once in the session
 *   by shuffling them and using a queue (so randomness without immediate repeats).
 * - Implemented animations (spinner and countdown) used across activities (placed in the base class).
 *
 * Note: Each class is in its own file and file names exactly match class names (Activity.cs, BreathingActivity.cs,
 * ReflectingActivity.cs, ListingActivity.cs, Program.cs). Member variables are private or protected as appropriate.
 */
