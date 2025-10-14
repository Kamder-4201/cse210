using System;

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points)
        : base(name, description, points) { }

    public override void RecordEvent()
    {
        Console.WriteLine($"Eternal goal '{Name}' recorded! You earned {Points} points!");
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{Name}|{Description}|{Points}";
    }

    // Always show as incomplete to symbolize “never finished.”
    public override string GetStatus() => "[∞]";
}
