using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;  // needed for Thread.Sleep


public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    // ===== Display Goals =====
    public void DisplayGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet. Create one first!");
            return;
        }

        Console.WriteLine("\nYour Goals:");
        int index = 1;
        foreach (Goal goal in _goals)
        {
            Console.Write($"{index}. ");
            goal.DisplayDetails();
            index++;
        }

        // Show progress summary after displaying goals
        DisplayProgressSummary();
    }

    // ===== Create New Goal =====
    public void CreateGoal()
    {
        Console.WriteLine("\nChoose a goal type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Select choice: ");
        int choice = int.Parse(Console.ReadLine());

        Console.Write("Enter name: ");
        string name = Console.ReadLine();
        Console.Write("Enter description: ");
        string description = Console.ReadLine();
        Console.Write("Enter points: ");
        int points = int.Parse(Console.ReadLine());

        Goal newGoal = null;

        switch (choice)
        {
            case 1:
                newGoal = new SimpleGoal(name, description, points);
                break;
            case 2:
                newGoal = new EternalGoal(name, description, points);
                break;
            case 3:
                Console.Write("Enter target count: ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("Enter bonus points: ");
                int bonus = int.Parse(Console.ReadLine());
                newGoal = new ChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                return;
        }

        _goals.Add(newGoal);
        Console.WriteLine("Goal added successfully!");
    }

    // ===== Record a Goal Event =====
    public void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record!");
            return;
        }

        Console.WriteLine("\nSelect the goal you completed:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].Name}");
        }

        Console.Write("Enter number: ");
        int index = int.Parse(Console.ReadLine()) - 1;

        if (index < 0 || index >= _goals.Count)
        {
            Console.WriteLine("Invalid choice.");
            return;
        }

        Goal selectedGoal = _goals[index];
        selectedGoal.RecordEvent();  // Polymorphism in action

        // Add points to total score
        _score += selectedGoal.Points;

        Console.WriteLine($"Current score: {_score}");
    }

    // ===== Display Total Score =====
    public void DisplayScore()
    {
        Console.WriteLine($"\nTotal Score: {_score} points");
    }

    // ===== Exercise 1: Clear Goals =====
    public void ClearGoals()
    {
        _goals.Clear();
        _score = 0;
        Console.WriteLine("All goals cleared and score reset to 0.");
    }

    // ===== Exercise 2: Display Progress Summary =====
    public void DisplayProgressSummary()
    {
        if (_goals.Count == 0)
            return;

        int completed = 0;
        foreach (Goal g in _goals)
        {
            if (g.IsComplete)
                completed++;
        }

        Console.WriteLine($"Progress: {completed}/{_goals.Count} goals completed.");
    }


    // ===== Save Goals =====
    // public void SaveGoals(string filename)
    // {
    //     using (StreamWriter writer = new StreamWriter(filename))
    //     {
    //         writer.WriteLine($"Score:{_score}");
    //         foreach (Goal g in _goals)
    //         {
    //             writer.WriteLine(g.GetStringRepresentation());
    //         }
    //     }
    //     Console.WriteLine("Goals saved!");
    // }
    // old code - not deleting for reference.

    // ===== Save Goals =====
    public void SaveGoals(string filename)
    {
        try
        {
            ShowSpinner("Saving goals... ");

            using (StreamWriter writer = new StreamWriter(filename))
            {
                writer.WriteLine($"Score:{_score}");
                foreach (Goal g in _goals)
                    writer.WriteLine(g.GetStringRepresentation());
            }

            Console.WriteLine($"✅ Goals successfully saved to '{filename}'.");
            //show your summary (and motivational quote)
            ShowSummary("Save");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error saving goals: {ex.Message}");
        }
    }


    // ===== Load Goals =====
    // public void LoadGoals(string filename)
    // {
    //     if (!File.Exists(filename))
    //     {
    //         Console.WriteLine("No saved goals found.");
    //         return;
    //     }

    //     string[] lines = File.ReadAllLines(filename);
    //     _goals.Clear();

    //     if (lines.Length > 0 && lines[0].StartsWith("Score:"))
    //     {
    //         _score = int.Parse(lines[0].Split(':')[1]);
    //     }

    //     for (int i = 1; i < lines.Length; i++)
    //     {
    //         string[] parts = lines[i].Split(':');
    //         string type = parts[0];
    //         string[] data = parts[1].Split('|');

    //         switch (type)
    //         {
    //             case "SimpleGoal":
    //                 _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]))
    //                 {
    //                     IsComplete = bool.Parse(data[3])
    //                 });
    //                 break;

    //             case "EternalGoal":
    //                 _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
    //                 break;

    //             case "ChecklistGoal":
    //                 ChecklistGoal cg = new ChecklistGoal(
    //                     data[0], data[1], int.Parse(data[2]),
    //                     int.Parse(data[3]), int.Parse(data[5])
    //                 );
    //                 for (int j = 0; j < int.Parse(data[4]); j++) cg.RecordEvent();
    //                 _goals.Add(cg);
    //                 break;
    //         }
    //     }

    //     Console.WriteLine("Goals loaded successfully!");
    // }
    // old code - not deleting for reference.

    // ===== Load Goals =====
    public void LoadGoals(string filename)
    {
        if (!File.Exists(filename))
        {
            Console.WriteLine($"⚠️ No save file found at '{filename}'.");
            return;
        }

        try
        {
            ShowSpinner("Loading goals... ");

            string[] lines = File.ReadAllLines(filename);
            if (lines.Length == 0)
            {
                Console.WriteLine("⚠️ Save file is empty.");
                return;
            }

            _goals.Clear();
            _score = 0;

            if (lines[0].StartsWith("Score:"))
                _score = int.Parse(lines[0].Split(':')[1]);

            for (int i = 1; i < lines.Length; i++)
            {
                string[] parts = lines[i].Split(':');
                if (parts.Length < 2) continue;

                string type = parts[0];
                string[] data = parts[1].Split('|');

                switch (type)
                {
                    case "SimpleGoal":
                        _goals.Add(new SimpleGoal(data[0], data[1], int.Parse(data[2]))
                        { IsComplete = bool.Parse(data[3]) });
                        break;

                    case "EternalGoal":
                        _goals.Add(new EternalGoal(data[0], data[1], int.Parse(data[2])));
                        break;

                    case "ChecklistGoal":
                        ChecklistGoal cg = new ChecklistGoal(
                            data[0], data[1], int.Parse(data[2]),
                            int.Parse(data[3]), int.Parse(data[5])
                        );
                        for (int j = 0; j < int.Parse(data[4]); j++) cg.RecordEvent();
                        if (bool.Parse(data[6])) cg.IsComplete = true;
                        _goals.Add(cg);
                        break;
                }
            }

            Console.WriteLine($"✅ Goals loaded successfully from '{filename}'.");
            // show your summary (and motivational quote)
            ShowSummary("Load");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"⚠️ Error loading goals: {ex.Message}");
        }
    }

    // ===== Spinner Animation =====
    private void ShowSpinner(string message, int durationSeconds = 2)
    {
        Console.Write(message);
        char[] spinner = { '|', '/', '-', '\\' };

        // Each spin frame lasts 200 ms
        int totalFrames = durationSeconds * 5;

        for (int i = 0; i < totalFrames; i++)
        {
            Console.Write(spinner[i % spinner.Length]);
            Thread.Sleep(200);
            Console.Write("\b"); // backspace to erase spinner char
        }

        Console.WriteLine(" Done!");
    }

    // ===== Summary Screen =====
    private void ShowSummary(string action)
    {
        Console.WriteLine("\n==============================");
        Console.WriteLine($"📊 {action} Summary");
        Console.WriteLine("==============================");

        // Show total score
        Console.WriteLine($"Total Score: {_score} points");

        // Count total and completed goals
        int completed = 0;
        foreach (Goal g in _goals)
        {
            if (g.IsComplete)
                completed++;
        }

        Console.WriteLine($"Goals Completed: {completed}/{_goals.Count}");

        // Display a motivational message
        if (completed == 0)
            Console.WriteLine("Let's get started on your first goal!");
        else if (completed < _goals.Count)
            Console.WriteLine("You're making great progress! Keep it up!");
        else
            Console.WriteLine("🎉 All goals completed! Time to set new ones!");

        Console.WriteLine("==============================\n");

        //Add motivation at the end
        ShowMotivation();
    }

    // ===== Random Motivational Quote =====
    private void ShowMotivation()
    {
        string[] quotes = {
            "Keep going — progress is progress!",
            "Small steps lead to big changes!",
            "You’re closer than you think!",
            "Faith and effort always pay off!",
            "Consistency beats intensity!",
            "Every goal achieved begins with a single step.",
            "You’re leveling up your real-life XP!",
            "Stay steady — greatness builds quietly."
        };

        Random rand = new Random();
        int index = rand.Next(quotes.Length);
        Console.WriteLine($"\n💬 {quotes[index]}");
    }

}
