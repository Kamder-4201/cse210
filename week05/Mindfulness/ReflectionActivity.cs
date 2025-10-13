using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectionActivity : Activity
{
    // Random and lists for prompts/questions
    private Random random = new Random();
    private List<string> prompts;
    private List<string> questions;

    // Constructor — initializes lists and passes name/description to base class
    public ReflectionActivity() 
        : base("Reflection Activity",
               "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
        prompts = new List<string>
        {
            "Think of a time when you stood up for someone else.",
            "Think of a time when you did something really difficult.",
            "Think of a time when you helped someone in need.",
            "Think of a time when you did something truly selfless.",
            "Think of a time when you had to choose, the easy but lazy or hard but worthwhile way"
        };

        questions = new List<string>
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
    }

    // Main logic
    public void Run()
    {
        Start(); // base class method

        // Display a random prompt
        string chosenPrompt = prompts[random.Next(prompts.Count)];
        Console.WriteLine($"\nConsider this prompt:");
        Console.WriteLine($"--- {chosenPrompt} ---");
        Console.WriteLine("\nReflect on it...");
        ShowCountdown(3);

        // Keep asking random questions until time runs out
        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            string question = questions[random.Next(questions.Count)];
            Console.WriteLine($"> {question}");
            ShowCountdown(5); // give time to reflect
        }

        End(); // base class method
    }
}
