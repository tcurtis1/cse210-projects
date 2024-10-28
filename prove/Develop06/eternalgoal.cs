using System;

public class EternalGoal : Goal
{
    //private bool isSpecialGoal = false;
    public EternalGoal(string name, string description, int points) : base(name, description, points) 
    { 

    }

    public override int RecordEvent()
    {
        if(_isSpecial)
        {
            _points = _points * _specialBonusMultiplier;
        }
        return _points;
    }

    public override bool IsComplete()
    {
        return false; // Eternal goals are never complete
    }

    public override string GetDetailsString()
    {
        return $"[   ] {_shortName}: {_description} (Eternal)";
    }

    public override string GetStringRepresentation()
    {
        return $"EternalGoal:{_shortName},{_description},{_points}";
    }
}
