// Exceed Requirement: Added summary screen for save/load + motivational quote when using load/save
using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        string filename = "goals.txt";
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("==============================");
            Console.WriteLine(" 🌟 Eternal Quest Tracker 🌟 ");
            Console.WriteLine("==============================");
            manager.DisplayScore();
            manager.DisplayGoals();
            manager.DisplayProgressSummary();   

            Console.WriteLine("\nMenu Options:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Record Event");
            Console.WriteLine("4. Save Goals");
            Console.WriteLine("5. Load Goals");
            Console.WriteLine("6. Clear All Goals");
            Console.WriteLine("7. Quit");

            Console.Write("\nSelect an option (1–7): ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Console.Clear();
                    manager.CreateGoal();
                    Pause();
                    break;

                case "2":
                    Console.Clear();
                    manager.DisplayGoals();
                    Pause();
                    break;

                case "3":
                    Console.Clear();
                    manager.RecordEvent();
                    Pause();
                    break;

                case "4":
                    Console.Clear();
                    Console.WriteLine("Saving goals...");
                    manager.SaveGoals(filename);
                    Pause();
                    break;

                case "5":
                    Console.Clear();
                    Console.WriteLine("Loading goals...");
                    manager.LoadGoals(filename);
                    Pause();
                    break;

                case "6":
                    Console.Clear();
                    manager.ClearGoals();
                    Pause();
                    break;

                case "7":
                    running = false;
                    Console.WriteLine("Goodbye! Keep striving for greatness!");
                    break;

                default:
                    Console.WriteLine("Invalid option, please try again.");
                    Pause();
                    break;
            }
        }
    }

    // Simple utility pause
    static void Pause()
    {
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
    }
}


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

// test prgram.cs to check progress so far...
// class Program
// {
//     static void Main()
//     {
//         Goal g1 = new SimpleGoal("Run Marathon", "Finish a 42 km race", 1000);
//         Goal g2 = new EternalGoal("Read Scriptures", "Daily reading habit", 100);
//         Goal g3 = new ChecklistGoal("Temple Visits", "Attend temple 10 times", 50, 10, 500);

//         g1.DisplayDetails();
//         g2.DisplayDetails();
//         g3.DisplayDetails();

//         Console.WriteLine("\n--- Recording Events ---");
//         g1.RecordEvent();
//         g2.RecordEvent();
//         g3.RecordEvent(); // 1/10
//         g3.RecordEvent(); // 2/10

//         GoalManager gm = new GoalManager();

//         // (Imagine the user already added goals)
//         gm.CreateGoal();  // add one
//         gm.DisplayGoals();
//         gm.RecordEvent();  // complete one
//         gm.DisplayGoals();
//         gm.ClearGoals();  // gm.ClearGoals();  // reset
//         gm.DisplayGoals(); // should show "No goals yet"
//         gm.DisplayProgressSummary(); // gm.DisplayGoals(); // should now show "No goals yet"
//     }
// }
