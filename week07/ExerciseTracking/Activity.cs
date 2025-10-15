using System;

public class Activity
{
    //  Encapsulated member variables
    private DateTime _date;
    private int _lengthMinutes;

    //  Constructor
    public Activity(DateTime date, int lengthMinutes)
    {
        _date = date;
        _lengthMinutes = lengthMinutes;
    }

    //  Getters and Setters (encapsulation)
    public DateTime GetDate() => _date;
    public int GetLengthMinutes() => _lengthMinutes;

    //  Virtual methods to be overridden by child classes
    public virtual double GetDistance()
    {
        return 0; // Placeholder — child classes will override
    }

    public virtual double GetSpeed()
    {
        return 0;
    }

    public virtual double GetPace()
    {
        return 0;
    }

    // 🧾 Shared summary method
    public virtual string GetSummary()
    {
        string summary = $"{GetDate():dd MMM yyyy} {this.GetType().Name} " +
                        $"({GetLengthMinutes()} min): " +
                        $"Distance {GetDistance():0.0} km, " +
                        $"Speed {GetSpeed():0.0} kph, " +
                        $"Pace: {GetPace():0.00} min per km";
        return summary;
    }

}
