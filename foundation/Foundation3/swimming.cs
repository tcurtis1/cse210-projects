using System;

public class Swimming : Activity
{
    private int _laps;
    private const double LapDistance = 50 / 1000.0 * 0.62; // distance per lap in miles if using miles

    public Swimming(DateTime date, int duration, int laps) : base(date, duration)
    {
        _laps = laps;
    }

    public override double GetDistance()
    {
        return _laps * LapDistance;
    }

    public override double GetSpeed()
    {
        return (GetDistance() / Duration) * 60;
    }

    public override double GetPace()
    {
        return Duration / GetDistance();
    }
}
