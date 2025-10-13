using System;
// Exceed requirement: added session log feature(Assisted by AI how to do)
class Program
{
    static void Main()
    {
        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine("Mindfulness Program");
            Console.WriteLine("-------------------");
            Console.WriteLine("1. Breathing Activity");
            Console.WriteLine("2. Reflection Activity");
            Console.WriteLine("3. Listing Activity");
            Console.WriteLine("4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    var breathing = new BreathingActivity();
                    breathing.Run();
                    break;

                case "2":
                    var reflection = new ReflectionActivity();
                    reflection.Run();
                    break;

                case "3":
                    var listing = new ListingActivity();
                    listing.Run();
                    break;

                case "4":
                    Console.WriteLine("Thank you for practicing mindfulness today!");
                    running = false;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }

            if (running)
            {
                Console.WriteLine("\nPress any key to return to the menu...");
                Console.ReadKey();
            }
        }
    }
}
