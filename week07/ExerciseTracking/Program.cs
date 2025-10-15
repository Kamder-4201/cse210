using System;

class Program
{
    // testing activity.cs
    static void Main(string[] args)
    {
        // // Create a sample Activity object
        // Activity test = new Activity(DateTime.Now, 30);
        // // Print the summary (will use placeholder values from base class)
        // Console.WriteLine(test.GetSummary());
        // Console.WriteLine();

        // Test the Running class
        Running run = new Running(new DateTime(2025, 10, 13), 30, 3.0); // 3 miles in 30 min
        Console.WriteLine(run.GetSummary());
    }
    
}