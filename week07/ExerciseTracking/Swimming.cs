using System;

public class Swimming : Activity
{
    // 🔒 Private field unique to Swimming
    private int _laps;

    // 🧩 Constructor
    public Swimming(DateTime date, int lengthMinutes, int laps)
        : base(date, lengthMinutes)
    {
        _laps = laps;
    }

    // ⚙️ Overridden methods

    // Distance (miles) = laps * 50 / 1000 * 0.62
    public override double GetDistance()
    {
        double distance = _laps * 50 / 1000.0 * 0.62;
        return distance;
    }

    // Speed (mph) = (distance / minutes) * 60
    public override double GetSpeed()
    {
        return (GetDistance() / GetLengthMinutes()) * 60;
    }

    // Pace (min per mile) = minutes / distance
    public override double GetPace()
    {
        return GetLengthMinutes() / GetDistance();
    }
}
