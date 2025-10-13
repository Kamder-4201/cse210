using System;
using System.Threading;

public class BreathingActivity : Activity
{
    // Constructor passes info to base constructor
    public BreathingActivity() 
        : base("Breathing Activity",
               "This activity will help you relax by walking you through breathing in and out slowly. Clear your mind and focus on your breathing.")
    {
    }

    // Main breathing routine
    public void Run()
    {
        // Call the shared starting behavior
        Start();

        DateTime endTime = DateTime.Now.AddSeconds(Duration);

        while (DateTime.Now < endTime)
        {
            Console.Write("\nBreathe in... ");
            ShowCountdown(4);  // pause for 4 seconds

            Console.Write("Now breathe out... ");
            ShowCountdown(4);
        }

        // Call the shared ending behavior
        End();
    }
}
