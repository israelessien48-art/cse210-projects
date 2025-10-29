using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        PromptGenerator promptGenerator = new PromptGenerator();

        Console.WriteLine("Welcome to the Journal Program!");

        while (true)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Edit an entry");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                string prompt = promptGenerator.GetRandomPrompt();
                Console.WriteLine($"\nPrompt: {prompt}");
                Console.Write("Your response: ");
                string response = Console.ReadLine();

                Entry newEntry = new Entry(prompt, response);
                journal.AddEntry(newEntry);

                Console.WriteLine("Entry added successfully!");
            }
            else if (choice == "2")
            {
                journal.DisplayAll();
            }
            else if (choice == "3")
            {
                Console.Write("Enter filename to save (e.g., journal.csv): ");
                string filename = Console.ReadLine();
                journal.SaveToFile(filename);
            }
            else if (choice == "4")
            {
                Console.Write("Enter filename to load (e.g., journal.csv): ");
                string filename = Console.ReadLine();
                journal.LoadFromFile(filename);
            }
            else if (choice == "5")
            {
                Console.Write("Enter the date of the entry to edit (format: MM/dd/yyyy): ");
                string dateToEdit = Console.ReadLine();
                journal.EditEntry(dateToEdit);
            }
            else if (choice == "6")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice. Please try again.");
            }
        }
    }
}

/*
 * EXTRA FEATURE (CREATIVITY):
 * - Added ability to EDIT entries by date.
 * - Entries are saved in CSV format compatible with Excel.
 * - Each entry automatically records full timestamp (DateTime.Now).
 */
