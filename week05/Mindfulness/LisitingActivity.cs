using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private Random random = new Random();
    private List<string> prompts;

    public ListingActivity() 
        : base("Listing Activity",
               "This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.")
    {
        prompts = new List<string>
        {
            "Who are people that you appreciate?",
            "What are personal strengths of yours?",
            "Who are people that you have helped this week?",
            "When have you felt peace this month?",
            "Who are some of your personal heroes?"
        };
    }

    public void Run()
    {
        Start(); // base class start behavior

        // Display a random prompt
        string chosenPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nList as many responses as you can to this prompt:");
        Console.WriteLine($"--- {chosenPrompt} ---");

        Console.WriteLine("\nYou may begin in:");
        ShowCountdown(3);

        // Start timing and collect responses
        List<string> items = new List<string>();
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            items.Add(response);
        }

        Console.WriteLine($"\nYou listed {items.Count} items!");
        End(); // base class ending message
    }
}
