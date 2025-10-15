using System;

public class Running : Activity
{
    private double _distance; // in kilometers

    public Running(DateTime date, int lengthMinutes, double distance)
        : base(date, lengthMinutes)
    {
        _distance = distance;
    }

    public override double GetDistance()
    {
        return _distance;
    }

    // Speed (kph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        return (_distance / GetLengthMinutes()) * 60;
    }

    // Pace (min per km) = minutes / distance
    public override double GetPace()
    {
        return GetLengthMinutes() / _distance;
    }
}
