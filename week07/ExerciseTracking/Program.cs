using System;

class Program
{
    // testing activity.cs
    static void Main(string[] args)
    {
        // Create a sample Activity object
        Activity test = new Activity(DateTime.Now, 30);
        // Print the summary (will use placeholder values from base class)
        Console.WriteLine(test.GetSummary());
        Console.WriteLine();
    }
    
}