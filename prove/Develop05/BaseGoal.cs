using System;

public abstract class Goal 
{
    protected string _name;
    protected string _description;
    protected int _points;
    protected bool _isCompleted;

    public bool IsCompleted
    {
        get { return _isCompleted; }
        set { _isCompleted = value; } 
    }
    public Goal(string name, string description, int points) 
    {
        _name = name;
        _description = description;
        _points = points;
        _isCompleted = false;
    }

    public string Name => _name;
    public string Description => _description;

    public abstract int GetPoints();
    public abstract void RecordEvent();
    public abstract string GetStatus();

    public override string ToString()
    {
        return $"{GetType().Name},{_name},{_description},{_points},{IsCompleted}";
    }
}

public class SimpleGoal : Goal 
{
    public SimpleGoal(string name, string description, int points, bool isCompleted = false) : base(name, description, points)
    {
        _isCompleted = isCompleted;
    }
    public override int GetPoints()
    {
        return _points;
    }
    public override void RecordEvent()
    {
        _isCompleted = true;
    }
    public override string GetStatus()
    {
        return (_isCompleted ? "[X] " + Name : "[ ] ") + Name + $" ({_description})";
    }
}

public class EternalGoal : Goal
{
    public EternalGoal(string name, string description, int points) : base(name, description, points)
    {}

    public override int GetPoints()
    {
        return _points;
    }

    public override void RecordEvent()
    {
    }
    public override string GetStatus()
    {
        return "[∞]" + Name + $" ({_description})";
    }
}

public class ChecklistGoal : Goal 
{
    private int _targetCount;
    private int _currentCount;
    private int _bonusPoints;

    public ChecklistGoal(string name, string description, int points, int targetCount, int bonusPoints)
    : base(name, description, points)
    {
        _targetCount = targetCount;
        _currentCount = 0;
        _bonusPoints = bonusPoints;
    }

    public override int GetPoints()
    {
        return (_currentCount >= _targetCount) ? (_points + _bonusPoints) : _points;
    }
    public override void RecordEvent()
    {
        if (_currentCount < _targetCount)
        {
            _currentCount++;
            Console.WriteLine($"Progrss: [{_currentCount}/{_targetCount}]");
            if (_currentCount == _targetCount)
            {
                _isCompleted = true;
                Console.WriteLine($"Goal '{_name}' completed! You earned {_bonusPoints} bonus points!");
            }
        }
    }

    public override string GetStatus()
    {
        return (_isCompleted ? "[X] " : "[ ] ") + _name + $" ({_description})" + $" Currently completed {_currentCount}/{_targetCount}";
    }
    public override string ToString()
    {
        return $"ChecklistGoal,{Name},{_description},{_points},{_currentCount},{_targetCount},{IsCompleted}";
    }
}