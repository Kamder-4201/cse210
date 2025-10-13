using System;
using System.Threading;
using System.IO;

public class Activity
{
    // 🔒 Private backing fields
    private string _name;
    private string _description;
    private int _duration;

    // 🔓 Public properties
    public string Name
    {
        get { return _name; }
        set { _name = value; }
    }

    public string Description
    {
        get { return _description; }
        set { _description = value; }
    }

    public int Duration
    {
        get { return _duration; }
        set { _duration = value; }
    }

    // Constructor
    public Activity(string name, string description)
    {
        _name = name;
        _description = description;
    }

    // Common start message
    public void Start()
    {
        Console.WriteLine($"\nStarting: {Name}");
        Console.WriteLine(Description);
        Console.Write("Enter duration (seconds): ");
        Duration = int.Parse(Console.ReadLine());
        Console.WriteLine("Prepare to begin...");
        ShowSpinner(3);
    }

    // Common end message
    public void End()
    {
        Console.WriteLine("\nGood job! You’ve completed the activity!");
        Console.WriteLine($"Activity: {Name} | Duration: {Duration} seconds");
        ShowSpinner(3);
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

    protected void ShowSpinner(int seconds)
{
    string[] spinner = { "|", "/", "-", "\\" };
    DateTime endTime = DateTime.Now.AddSeconds(seconds);
    int i = 0;

    while (DateTime.Now < endTime)
    {
        Console.Write(spinner[i]);
        Thread.Sleep(200);
        Console.Write("\b \b"); // erase spinner
        i = (i + 1) % spinner.Length;
    }
}

    // Inside the Activity class
    protected void LogSession()
    {
        string logFile = "session_log.txt";
        string logEntry = $"{DateTime.Now:G} - Completed: {Name} ({Duration} seconds)";
        File.AppendAllText(logFile, logEntry + Environment.NewLine);
    }
}
