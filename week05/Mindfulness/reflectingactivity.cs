using System;
using System.Collections.Generic;
using System.Diagnostics;

public class ReflectingActivity : Activity
{
    private List<string> _prompts = new List<string>()
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
    };

    private List<string> _questions = new List<string>()
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    // To avoid repeating prompts/questions until all are used within a session
    private Queue<string> _promptQueue;
    private Queue<string> _questionQueue;
    private Random _rng = new Random();

    public ReflectingActivity() : base(
        "Reflecting Activity",
        "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        _promptQueue = new Queue<string>(ShuffleList(_prompts));
        _questionQueue = new Queue<string>(ShuffleList(_questions));
    }

    // Helper to shuffle and return a list
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

    private string DequeueOrRefillQuestion()
    {
        if (_questionQueue.Count == 0)
            _questionQueue = new Queue<string>(ShuffleList(_questions));
        return _questionQueue.Dequeue();
    }

    public override void Run()
    {
        DisplayStartingMessage();

        // Show random prompt
        string prompt = DequeueOrRefillPrompt();
        Console.WriteLine();
        Console.WriteLine("Consider the following prompt:");
        Console.WriteLine($"> {prompt}");
        Console.WriteLine();
        Console.WriteLine("When you are ready, press Enter to continue.");
        Console.ReadLine();

        Stopwatch sw = Stopwatch.StartNew();

        while (sw.ElapsedMilliseconds / 1000 < _duration)
        {
            string question = DequeueOrRefillQuestion();
            Console.WriteLine();
            Console.WriteLine($"> {question}");
            // Pause with spinner for reflective time (e.g., 7 seconds)
            int pauseSeconds = 7;
            if (_duration - (int)(sw.ElapsedMilliseconds / 1000) < pauseSeconds)
            {
                pauseSeconds = Math.Max(1, _duration - (int)(sw.ElapsedMilliseconds / 1000));
            }
            ShowSpinner(pauseSeconds);

            if (sw.ElapsedMilliseconds / 1000 >= _duration) break;
        }

        DisplayEndingMessage();

        Program.LogActivity(Name, _duration);
    }
}
