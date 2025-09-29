using System;
// code assisted with AI to assist in structuring code and documentation. 
class Program
{
    static void Main(string[] args)
    {
        // Test default constructor
        Fraction f1 = new Fraction();
        Console.WriteLine(f1.GetFractionString());   // 1/1
        Console.WriteLine(f1.GetDecimalValue());     // 1

        // Test constructor with one parameter
        Fraction f2 = new Fraction(5);
        Console.WriteLine(f2.GetFractionString());   // 5/1
        Console.WriteLine(f2.GetDecimalValue());     // 5

        // Test constructor with two parameters
        Fraction f3 = new Fraction(3, 4);
        Console.WriteLine(f3.GetFractionString());   // 3/4
        Console.WriteLine(f3.GetDecimalValue());     // 0.75

        // Another example
        Fraction f4 = new Fraction(1, 3);
        Console.WriteLine(f4.GetFractionString());   // 1/3
        Console.WriteLine(f4.GetDecimalValue());     // 0.333...

        // Using getters and setters
        f4.SetTop(2);
        f4.SetBottom(5);
        Console.WriteLine(f4.GetFractionString());   // 2/5
        Console.WriteLine(f4.GetDecimalValue());     // 0.4
    }
}
