using System;

public class ChecklistGoal : Goal
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points,
                         int targetCount, int bonusPoints)
        : base(name, description, points)
    {
        _targetCount = targetCount;
        _bonusPoints = bonusPoints;
        _currentCount = 0;
    }

    public override void RecordEvent()
    {
        if (!IsComplete)
        {
            _currentCount++;
            Console.WriteLine($"Progress: {_currentCount}/{_targetCount}. You earned {Points} points!");

            if (_currentCount >= _targetCount)
            {
                IsComplete = true;
                Console.WriteLine($"🎉 Goal '{Name}' completed! Bonus {_bonusPoints} points awarded!");
            }
        }
        else
        {
            Console.WriteLine($"Goal '{Name}' already finished!");
        }
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{Name}|{Description}|{Points}|{_targetCount}|{_currentCount}|{_bonusPoints}|{IsComplete}";
    }

    public override void DisplayDetails()
    {
        Console.WriteLine($"{GetStatus()} {Name} ({Description}) — Completed {_currentCount}/{_targetCount} times");
    }
}
