using System;
using System.Diagnostics;
using System.Threading;

public class BreathingActivity : Activity
{
    // No extra protected data needed here; use base members
    public BreathingActivity() : base(
        "Breathing Activity",
        "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Override Run to implement breathing behavior
    public override void Run()
    {
        DisplayStartingMessage();

        Stopwatch sw = Stopwatch.StartNew();
        bool inhale = true;

        // Choose pace: for clarity use 4 seconds inhale, 6 seconds exhale pattern OR adjust if short duration
        int inhaleSeconds = 4;
        int exhaleSeconds = 6;

        // If total duration is short, shrink times proportionally
        if (_duration < 10)
        {
            inhaleSeconds = Math.Max(1, _duration / 4);
            exhaleSeconds = Math.Max(1, _duration / 3);
        }

        while (sw.ElapsedMilliseconds / 1000 < _duration)
        {
            if (inhale)
            {
                Console.WriteLine();
                Console.Write("Breathe in... ");
                ShowCountdown(inhaleSeconds);
                Console.WriteLine();
            }
            else
            {
                Console.WriteLine();
                Console.Write("Breathe out... ");
                ShowCountdown(exhaleSeconds);
                Console.WriteLine();
            }

            inhale = !inhale;

            // If next breath would overshoot duration, break
            if (sw.ElapsedMilliseconds / 1000 >= _duration) break;
        }

        DisplayEndingMessage();

        // Log activity (Program will use a public helper method if available)
        Program.LogActivity(Name, _duration);
    }
}
