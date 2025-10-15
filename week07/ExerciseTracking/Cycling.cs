using System;

public class Cycling : Activity
{
    // 🔒 Private field unique to Cycling
    private double _speed; // in miles per hour (mph)

    // 🧩 Constructor
    public Cycling(DateTime date, int lengthMinutes, double speed)
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    // ⚙️ Overridden methods

    // Distance = (speed × minutes) / 60
    public override double GetDistance()
    {
        return (_speed * GetLengthMinutes()) / 60;
    }

    // Speed is known
    public override double GetSpeed()
    {
        return _speed;
    }

    // Pace = 60 / speed (minutes per mile)
    public override double GetPace()
    {
        return 60 / _speed;
    }
}
