using System;

public class Running : Activity
{
    //  Private field unique to Running
    private double _distance; // in miles

    //  Constructor
    public Running(DateTime date, int lengthMinutes, double distance)
        : base(date, lengthMinutes) // call base constructor
    {
        _distance = distance;
    }

    //  Overridden methods

    // Distance is already known (user input)
    public override double GetDistance()
    {
        return _distance;
    }

    // Speed = (distance / minutes) * 60
    public override double GetSpeed()
    {
        return (_distance / GetLengthMinutes()) * 60;
    }

    // Pace = minutes / distance
    public override double GetPace()
    {
        return GetLengthMinutes() / _distance;
    }
}
