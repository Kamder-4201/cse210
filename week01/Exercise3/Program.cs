using System;

class Program
{
    static void Main()
    {
        var rnd = new Random();

        bool playAgain = true;
        while (playAgain)
        {
            int magic = rnd.Next(1, 50); // 1 to 50
            int guess;
            int attempts = 0;

            Console.WriteLine("I'm thinking of a number between 1 and 50.");

            Console.Write("What is your guess? ");
            while (!int.TryParse(Console.ReadLine(), out guess))
            {
                Console.Write("Please enter a valid number: ");
            }

            while (guess != magic)
            {
                attempts++;
                if (guess < magic)
                    Console.WriteLine("Higher");
                else
                    Console.WriteLine("Lower");

                Console.Write("What is your guess? ");
                while (!int.TryParse(Console.ReadLine(), out guess))
                {
                    Console.Write("Please enter a valid number: ");
                }
            }

            attempts++; // count the successful guess
            Console.WriteLine($"You guessed it in {attempts} attempts!");

            Console.Write("Play again? (y/n): ");
            string response = Console.ReadLine().Trim().ToLower();
            playAgain = (response == "y" || response == "yes");
        }

        Console.WriteLine("Thanks for playing!");
    }
}