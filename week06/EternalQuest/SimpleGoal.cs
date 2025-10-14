using System;

public class SimpleGoal : Goal
{
    public SimpleGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            IsComplete = true;
            Console.WriteLine($"Goal '{Name}' completed! You earned {Points} points!");
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' is already complete.");
        }
    }

    public override string GetStringRepresentation()
    {
        return $"SimpleGoal:{Name}|{Description}|{Points}|{IsComplete}";
    }
}
