using System;
using System.Threading;
using System.IO;

public class Activity
{
    // Shared properties
    public string Name { get; set; }
    public string Description { get; set; }
    public int Duration { get; set; }

    // Constructor
    public Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    // Common start message
    public void Start()
    {
        Console.WriteLine($"\nStarting: {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter duration (seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowCountdown(3);
    }

    // Common end message
    public void End()
    {
        Console.WriteLine("\nGood job! You’ve completed the activity!");
        Console.WriteLine($"Activity: {Name} | Duration: {Duration} seconds");
        ShowCountdown(3);
        // Log the session automatically
        LogSession();
    }

    // Shared animation
    protected void ShowCountdown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i + " ");
            Thread.Sleep(1000); // delay 1 sec
        }
        Console.WriteLine();
    }

    // Inside the Activity class
    protected void LogSession()
    {
        string logFile = "session_log.txt";
        string logEntry = $"{DateTime.Now:G} - Completed: {Name} ({Duration} seconds)";
        File.AppendAllText(logFile, logEntry + Environment.NewLine);
    }
}
