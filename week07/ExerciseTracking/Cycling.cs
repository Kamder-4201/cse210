using System;

public class Cycling : Activity
{
    private double _speed; // in km/h

    public Cycling(DateTime date, int lengthMinutes, double speed)
        : base(date, lengthMinutes)
    {
        _speed = speed;
    }

    // Distance (km) = (speed × minutes) / 60
    public override double GetDistance()
    {
        return (_speed * GetLengthMinutes()) / 60;
    }

    public override double GetSpeed()
    {
        return _speed;
    }

    // Pace (min per km) = 60 / speed
    public override double GetPace()
    {
        return 60 / _speed;
    }
}
