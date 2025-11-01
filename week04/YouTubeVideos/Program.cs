using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        // Create a list of videos
        List<Video> videos = new List<Video>();

        // --- First Video ---
        Video video1 = new Video("Learning C# in 10 Minutes", "Code Academy", 600);
        video1.AddComment(new Comment("Alice", "This video helped me understand loops!"));
        video1.AddComment(new Comment("John", "Great tutorial, very clear explanation."));
        video1.AddComment(new Comment("Mary", "Thanks! I finally know what classes do."));
        videos.Add(video1);

        // --- Second Video ---
        Video video2 = new Video("Mastering Object-Oriented Programming", "Tech Guru", 1200);
        video2.AddComment(new Comment("Sam", "OOP makes sense now. Thank you!"));
        video2.AddComment(new Comment("Rita", "This example was amazing."));
        video2.AddComment(new Comment("Paul", "Loved the visual examples."));
        videos.Add(video2);

        // --- Third Video ---
        Video video3 = new Video("Understanding Abstraction in C#", "BYU-Idaho Learning", 900);
        video3.AddComment(new Comment("Bethany", "Very helpful for my CSE210 project!"));
        video3.AddComment(new Comment("Israel", "The examples made it easy to follow."));
        video3.AddComment(new Comment("Michael", "Now I understand why abstraction matters."));
        videos.Add(video3);

        // Display all video information
        Console.WriteLine("=== YouTube Video Summary ===\n");
        foreach (Video video in videos)
        {
            video.DisplayVideoDetails();
        }

        Console.WriteLine("End of program execution.");
    }
}
