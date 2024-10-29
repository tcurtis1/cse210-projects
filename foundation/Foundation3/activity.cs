using System;

public abstract class Activity
{
    private DateTime _date;
    private int _duration; // duration in minutes

    public Activity(DateTime date, int duration)
    {
        _date = date;
        _duration = duration;
    }

    // cool shortform way to createa getter which returns _date and _duration.
    // private DateTime _date;

    // public DateTime Date
    // {
    //     get { return _date; }
    // }
    public DateTime Date => _date;
    public int Duration => _duration;

    // Setting up abstract classes that will get overrode in subclasses
    public abstract double GetDistance();
    public abstract double GetSpeed();
    public abstract double GetPace();

    // GetSummary written such that the subclasses each encapsulate parts that are unique to themselves and thus using the get methods we are able to create a single base class method for this.
    public virtual string GetSummary()
    {
        //03 Nov 2022 Running (30 min)- Distance 3.0 miles, Speed 6.0 mph, Pace: 10.0 min per mile
        return $"{_date.ToString("dd MMM yyyy")} {GetType().Name} ({_duration} min): Distance {GetDistance():0.0} mile(s), Speed {GetSpeed():0.0} mph, Pace {GetPace():0.0} min per mile";
    }
}
