using System;

public class Swimming : Activity
{
    private int _laps;

    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    // Distance (km) = laps * 50 / 1000
    public override double GetDistance()
    {
        return _laps * 50 / 1000.0;
    }

    // Speed (kph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    // Pace (min per km) = minutes / distance
    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }
}
