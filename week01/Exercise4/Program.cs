using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        List<int> numbers = new List<int>();
        int number;

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        // Collect numbers
        while (true)
        {
            Console.Write("Enter number: ");
            string input = Console.ReadLine();

            if (!int.TryParse(input, out number))
            {
                Console.WriteLine("Please enter a valid number.");
                continue; // Ask again
            }

            if (number == 0)
            {
                break; // Stop loop
            }

            numbers.Add(number);
        }

        // Calculate sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }

        // Calculate average
        double average = (double)sum / numbers.Count;

        // Find max
        int max = int.MinValue;
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }

        // Print results
        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average}");
        Console.WriteLine($"The largest number is: {max}");
    }
}
