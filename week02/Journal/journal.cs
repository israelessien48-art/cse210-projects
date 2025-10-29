using System;
using System.Collections.Generic;
using System.IO;

public class Journal
{
    private List<Entry> _entries = new List<Entry>();

    public void AddEntry(Entry entry)
    {
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("\nNo journal entries to display.");
            return;
        }

        Console.WriteLine("\n--- Journal Entries ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine("-----------------------");
        }
    }

    public void SaveToFile(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Entry entry in _entries)
            {
                writer.WriteLine($"{entry._date},{entry._prompt.Replace(",", ";")},{entry._response.Replace(",", ";")}");
            }
        }
        Console.WriteLine($"Journal saved to {filename}");
    }

    public void LoadFromFile(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _entries.Clear();
        string[] lines = File.ReadAllLines(filename);
        foreach (string line in lines)
        {
            string[] parts = line.Split(',');
            if (parts.Length >= 3)
            {
                string date = parts[0];
                string prompt = parts[1];
                string response = parts[2];
                Entry entry = new Entry(prompt, response, date);
                _entries.Add(entry);
            }
        }

        Console.WriteLine($"Loaded {_entries.Count} entries from {filename}");
    }

    public void EditEntry(string dateToEdit)
    {
        Entry entryToEdit = _entries.Find(e => e._date.StartsWith(dateToEdit));
        if (entryToEdit != null)
        {
            Console.WriteLine($"Found entry from {entryToEdit._date}");
            Console.WriteLine($"Old response: {entryToEdit._response}");
            Console.Write("Enter new response: ");
            string newResponse = Console.ReadLine();
            entryToEdit._response = newResponse;
            Console.WriteLine("Entry updated successfully!");
        }
        else
        {
            Console.WriteLine("No entry found with that date.");
        }
    }
}
