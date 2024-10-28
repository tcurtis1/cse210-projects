using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _bonus;
    private int _amountCompleted;

    public ChecklistGoal(string name, string description, int points, int target, int bonus) : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _amountCompleted = 0;
    }

    public override int RecordEvent()
    {
        _amountCompleted++;
        if (_amountCompleted >= _target)
        {
            _points = _points + _bonus;
            if(_isSpecial)
            {
                _points = _points * _specialBonusMultiplier;
            }
        }
        return _points;
    }

    public override bool IsComplete()
    {
        return _amountCompleted >= _target; //This returns the result of this evaluation which is a bool.
    }

    public override string GetDetailsString()
    {
        return $"[ {(IsComplete() ? "\u221A" : " ")} ] {_shortName}: {_description} (Completed {_amountCompleted}/{_target} times)";
    }

    public override string GetStringRepresentation()
    {
        return $"ChecklistGoal:{_shortName},{_description},{_points},{_target},{_bonus},{_amountCompleted}";
    }
    public int GetAmountCompleted()
    {
        return _amountCompleted;
    }
    public int GetTarget()
    {
        return _target;
    }
    public int GetBonus()
    {
        return _bonus;
    }
}
