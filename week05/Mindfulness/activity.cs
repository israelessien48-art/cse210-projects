using System;
using System.Diagnostics;
using System.Threading;

public class Activity
{
    // Private member variables (encapsulation)
    private string _name;
    private string _description;
    protected int _duration; // seconds - protected so derived classes can access

    // Constructor requires parameters (ensures objects are populated)
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
        _duration = 0;
    }

    // Public accessor for name (TitleCase naming)
    public string Name
    {
        get { return _name; }
    }

    // Get duration from user; validates input
    public void GetDurationFromUser()
    {
        Console.Write("Enter duration in seconds: ");
        while (true)
        {
            string? input = Console.ReadLine();
            if (int.TryParse(input, out int seconds) && seconds > 0)
            {
                _duration = seconds;
                break;
            }
            Console.Write("Please enter a positive integer for seconds: ");
        }
    }

    // Standard starting message used by every activity
    public void DisplayStartingMessage()
    {
        Console.Clear();
        Console.WriteLine($"--- {_name} ---");
        Console.WriteLine();
        Console.WriteLine(_description);
        Console.WriteLine();
        GetDurationFromUser();
        Console.WriteLine();
        Console.WriteLine("Get ready...");
        ShowSpinner(3);
    }

    // Standard ending message used by every activity
    public void DisplayEndingMessage()
    {
        Console.WriteLine();
        Console.WriteLine("Well done!");
        Console.WriteLine();
        Console.WriteLine($"You have completed the {_name} for {_duration} seconds.");
        ShowSpinner(3);
    }

    // Spinner animation for the given number of seconds
    public void ShowSpinner(int seconds)
    {
        Stopwatch sw = Stopwatch.StartNew();
        string[] sequence = { "|", "/", "-", "\\" };
        int i = 0;
        while (sw.ElapsedMilliseconds < seconds * 1000)
        {
            Console.Write(sequence[i % sequence.Length]);
            Thread.Sleep(250);
            Console.Write("\b");
            i++;
        }
        Console.WriteLine();
    }

    // Show a numeric countdown (1..seconds)
    public void ShowCountdown(int seconds)
    {
        for (int i = seconds; i >= 1; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
    }

    // Virtual Run method to be overridden by derived classes
    public virtual void Run()
    {
        // Base does nothing by itself
    }
}
