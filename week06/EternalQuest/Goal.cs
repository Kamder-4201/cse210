using System;

public abstract class Goal
{
    //  Private fields (encapsulation)
    private string _name;
    private string _description;
    private int _points;
    private bool _isComplete;

    //  Public properties
    public string Name { get => _name; set => _name = value; }
    public string Description { get => _description; set => _description = value; }
    public int Points { get => _points; set => _points = value; }
    public bool IsComplete { get => _isComplete; set => _isComplete = value; }

    //  Constructor
    public Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
        _isComplete = false;
    }

    //  Virtual / Abstract Methods — for polymorphism later
    public abstract void RecordEvent();              // called when user completes this goal
    public abstract string GetStringRepresentation();// for file saving

    public virtual string GetStatus()
    {
        return IsComplete ? "[X]" : "[ ]";
    }

    public virtual void DisplayDetails()
    {
        Console.WriteLine($"{GetStatus()} {Name} ({Description})");
    }
}
