// TestGoal 
// class Program
// {
//     static void Main()
//     {
//         // Create a test goal object
//         TestGoal goal = new TestGoal("Run a Marathon", "Finish a 42 km race", 1000);

//         // Show the initial state
//         Console.WriteLine("Before completing:");
//         goal.DisplayDetails();    // should show [ ] Run a Marathon (Finish a 42 km race)

//         // Record the event
//         goal.RecordEvent();       // mark as complete

//         // Show the updated state
//         Console.WriteLine("\nAfter completing:");
//         goal.DisplayDetails();    // should show [X] Run a Marathon (Finish a 42 km race)

//         // Print how it would look when saved
//         Console.WriteLine($"\nSave format: {goal.GetStringRepresentation()}");
//     }
// }

class Program
{
    static void Main()
    {
        Goal g1 = new SimpleGoal("Run Marathon", "Finish a 42 km race", 1000);
        Goal g2 = new EternalGoal("Read Scriptures", "Daily reading habit", 100);
        Goal g3 = new ChecklistGoal("Temple Visits", "Attend temple 10 times", 50, 10, 500);

        g1.DisplayDetails();
        g2.DisplayDetails();
        g3.DisplayDetails();

        Console.WriteLine("\n--- Recording Events ---");
        g1.RecordEvent();
        g2.RecordEvent();
        g3.RecordEvent(); // 1/10
        g3.RecordEvent(); // 2/10

        GoalManager gm = new GoalManager();

        // (Imagine the user already added goals)
        gm.CreateGoal();  // add one
        gm.DisplayGoals();
        gm.RecordEvent();  // complete one
        gm.DisplayGoals();
        gm.ClearGoals();  // gm.ClearGoals();  // reset
        gm.DisplayGoals(); // should show "No goals yet"
        gm.DisplayProgressSummary(); // gm.DisplayGoals(); // should now show "No goals yet"
    }
}
