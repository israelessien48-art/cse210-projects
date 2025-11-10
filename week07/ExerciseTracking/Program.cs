using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>()
        {
            new Running(new DateTime(2025, 11, 1), 30, 4.5),
            new Cycling(new DateTime(2025, 11, 2), 45, 18),
            new Swimming(new DateTime(2025, 11, 3), 40, 20)
        };

        foreach (Activity activity in activities)
        {
            Console.WriteLine(activity.GetSummary());
        }
    }
}
