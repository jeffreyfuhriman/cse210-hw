using System;

public abstract class Workout
{
    protected string _name;
    protected int _duration;
    protected string _difficulty;

    public Workout(string name, int duration, string difficulty)
    {
        _name = name;
        _duration = duration;
        _difficulty = difficulty;
    }
    public abstract void StartWorkout();
    public abstract void DisplayWorkout();
    public abstract void EndWorkout();
}

public class PushWorkout : Workout
{
    private List<Exercise> Exercises;

    public PushWorkout(string name, int duration, string difficulty) : base(name, duration, difficulty)
    {
        Exercises = new List<Exercise>();
    }

    public override void StartWorkout()
    {
        Console.WriteLine($"Starting {_name} workout...");
    }
    public override void DisplayWorkout()
    {
        Console.WriteLine("Display push workout...");
    }
    public override void EndWorkout()
    {
        Console.WriteLine("End push workout...");
    }
}

public class LegWorkout : Workout
{
    private List<Exercise> Exercises;

    public LegWorkout(string name, int duration, string difficulty) : base(name, duration, difficulty)
    {
        Exercises = new List<Exercise>();
    }

    public override void StartWorkout()
    {
        Console.WriteLine("Start leg workout...");
    }
    public override void DisplayWorkout()
    {
        Console.WriteLine("Display leg workout...");
    }
    public override void EndWorkout()
    {
        Console.WriteLine("End leg workout...");
    }
}

public class PullWorkout : Workout
{
    private List<Exercise> Exercises;

    public PullWorkout(string name, int duration, string difficulty) : base(name, duration, difficulty)
    {
        Exercises = new List<Exercise>();
    }

    public override void StartWorkout()
    {
        Console.WriteLine("Start pull workout...");
    }
    public override void DisplayWorkout()
    {
        Console.WriteLine("Display pull workout...");
    }
    public override void EndWorkout()
    {
        Console.WriteLine("End pull workout...");
    }
}