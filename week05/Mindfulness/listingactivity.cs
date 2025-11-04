using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;

public class ListingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private Queue<string> _promptQueue;
    private Random _rng = new Random();

    public ListingActivity() : base(
        "Listing Activity",
        "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        _promptQueue = new Queue<string>(ShuffleList(_prompts));
    }

    private List<string> ShuffleList(List<string> source)
    {
        List<string> copy = new List<string>(source);
        int n = copy.Count;
        while (n > 1)
        {
            n--;
            int k = _rng.Next(n + 1);
            string temp = copy[k];
            copy[k] = copy[n];
            copy[n] = temp;
        }
        return copy;
    }

    private string DequeueOrRefillPrompt()
    {
        if (_promptQueue.Count == 0)
            _promptQueue = new Queue<string>(ShuffleList(_prompts));
        return _promptQueue.Dequeue();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        string prompt = DequeueOrRefillPrompt();
        Console.WriteLine();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine($"> {prompt}");
        Console.WriteLine();

        // Give user a short countdown to start thinking
        Console.Write("You may begin in: ");
        ShowCountdown(5);
        Console.WriteLine();
        Console.WriteLine("Start listing items (press ENTER after each item):");

        List<string> entries = new List<string>();

        Stopwatch sw = Stopwatch.StartNew();

        // Read items until duration expires.
        // We use Console.KeyAvailable to avoid blocking (user can type and press enter).
        while (sw.ElapsedMilliseconds / 1000 < _duration)
        {
            // If user has typed some input and pressed enter, Console.KeyAvailable becomes true.
            if (Console.KeyAvailable)
            {
                string? line = Console.ReadLine();
                if (!string.IsNullOrWhiteSpace(line))
                    entries.Add(line.Trim());
            }
            else
            {
                // Small sleep to avoid busy loop and allow KeyAvailable to be set
                Thread.Sleep(100);
            }
        }

        Console.WriteLine();
        Console.WriteLine($"You listed {entries.Count} items:");
        foreach (var item in entries)
        {
            Console.WriteLine($"- {item}");
        }

        DisplayEndingMessage();

        Program.LogActivity(Name, _duration);
    }
}
