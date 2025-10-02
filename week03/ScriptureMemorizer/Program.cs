// Exceed: upgraded scripture.cs to only hide words not yet hidden, avoids re-hiding already hidden words.
using System;

class Program
{
    static void Main(string[] args)
    {
        Reference reference = new Reference("Proverbs", 3, 5, 6);

        string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";

        Scripture scripture = new Scripture(reference, text);

        while (true)
        {
            Console.Clear();
            scripture.Display();  // ✅ instead of GetDisplayText()

            if (scripture.AllWordsHidden())  // ✅ instead of IsCompletelyHidden()
            {
                Console.WriteLine("All words are hidden. Program ending...");
                break;
            }

            Console.WriteLine("Press Enter to hide more words or type 'quit' to exit.");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break;
            }

            scripture.HideRandomWords(3);  // ✅ hide 3 words each time
        }
    }
}
