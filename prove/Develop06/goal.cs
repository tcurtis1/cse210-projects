using System;

public abstract class Goal
{
    protected string _shortName;
    protected string _description;
    protected int _points;
    protected int _specialBonusMultiplier = 2;
    protected bool _isSpecial = false;
    protected List<string> specialWords = new List<string> {"prayer","scriptures","service","kindness"};

    public Goal(string name, string description, int points)
    {
        _shortName = name;
        _description = description;
        _points = points;
        _isSpecial = CheckIfSpecial(description);

    }

    public string GetShortName()
    {
        return _shortName;
    }
    private bool CheckIfSpecial(string tmpString)
    {
        //string tmpDescription = GetDetailsString();
        bool matches = specialWords.Any(s => tmpString.Contains(s));
        return matches;

    }
    public bool IsThisSpecial()
    {
        return _isSpecial;
    }
    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetDetailsString();
    public abstract string GetStringRepresentation();
}
