using System;

public abstract class Workout
{
    protected string _name;
    protected int _sets;
    protected int _reps;
    public List<Exercise> Exercises;

    public Workout(string name, int sets, int reps)
    {
        _name = name;
        _sets = sets;
        _reps = reps;
        Exercises = new List<Exercise>();
    }
    public abstract void StartWorkout();
    public abstract void DisplayWorkout();
    public abstract void EndWorkout();
}

public class PushWorkout : Workout
{
    public PushWorkout() : base("Push Workout", 3, 10)
    {
        Exercises = new List<Exercise>
        {
            new Exercise("Bench Press", 3, 10, 0),
            new Exercise("Dumbell Incline Bench Press", 3, 8, 0),
            new Exercise("Triceps Pushdown", 3, 12, 0)
        };
    }
    
    // public PushWorkout(string name, int sets, int reps) : base(name, sets, reps)
    // {
    //     Exercises = new List<Exercise>();
    // }

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
    public LegWorkout() : base("Leg Workout", 3, 10)
    {
        Exercises = new List<Exercise>
        {
            new Exercise("Back Squat", 3, 10, 0),
            new Exercise("Weighted Lunges", 3, 8, 0),
            new Exercise("Calf Raises", 3, 12, 0)
        };
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
    public PullWorkout() : base("Pull Workout", 3, 10)
    {
        Exercises = new List<Exercise>
        {
            new Exercise("Lat Pulldowns", 3, 10, 0),
            new Exercise("Bicep Curls", 3, 8, 0),
            new Exercise("Seated Rows", 3, 12, 0)
        };
    }

    // public PullWorkout(string name, int sets, int reps) : base(name, sets, reps)
    // {
    //     Exercises = new List<Exercise>();
    // }

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