using System;

// A test subclass just to experiment with the abstract Goal class
public class TestGoal : Goal
{
    public TestGoal(string name, string description, int points)
        : base(name, description, points)
    {
    }

    // Implement the abstract methods
    public override void RecordEvent()
    {
        // For testing, just mark this goal as complete
        IsComplete = true;
        Console.WriteLine($"Goal '{Name}' marked complete! You earned {Points} points!");
    }

    public override string GetStringRepresentation()
    {
        // A simple way to visualize saving
        return $"TestGoal:{Name}|{Description}|{Points}|{IsComplete}";
    }
}
