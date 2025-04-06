using System;
using System.Dynamic;
using System.Text.Json;

class WorkoutManager
{
    public string WorkoutType { get; private set; }
    private List<Exercise> ExerciseList;
    private DateTime StartTime;
    private DateTime EndTime;

    public WorkoutManager(string workoutType) 
    {
        WorkoutType = workoutType;
        ExerciseList = new List<Exercise>();
    }

    public void StartWorkout()
    {
        StartTime = DateTime.Now;
        Console.WriteLine($"Workout started: {WorkoutType} at {StartTime}");
    }
    public void EndWorkout()
    {
        EndTime = DateTime.Now;
        Console.WriteLine($"Workout ended at {EndTime}");
    }
    public void AddExercise(Exercise exercise) 
    {
        ExerciseList.Add(exercise);
        Console.WriteLine($"Exercise added: {exercise.Name}");
    }
}

public class UserProfile 
    {
    public string Name { get; private set; }
    public  int Age { get; private set; }
    public double Weight { get; private set; }
    public UserStats Stats { get; set; }
    private List<WorkoutSession> WorkoutHistory { get; set; }

    public UserProfile(string name, int age, double weight) 
    {
        Name = name;
        Age = age;
        Weight = weight;
        Stats = new UserStats();
        WorkoutHistory = new List<WorkoutSession>();
    }

    public void AddWorkout(WorkoutSession session) 
    {
        WorkoutHistory.Add(session);
        Console.WriteLine($"Workout added to {Name}'s history.");
    }

    public void ViewStats() 
    {
        Console.WriteLine($"User: {Name}, Age: {Age}, Weight: {Weight} lbs\n");
    }

    public void ViewWorkoutHistory()
    {
        if (WorkoutHistory.Count == 0)
        {
            Console.WriteLine("No workouts recorded yet.");
            return;
        }

        for (int i = 0; i < WorkoutHistory.Count; i++)
        {
            Console.WriteLine($"\nSession {i + 1}:");
            WorkoutHistory[i].DisplaySession();
        }
    }
}

public class Exercise 
    {
    public string Name { get; private set; }
    public int Sets { get; private set; }
    public int Reps { get; private set; }
    public double Weight { get; private set; }

    public Exercise(string name, int sets, int reps, double weight) 
    {
        Name = name;
        Sets = sets;
        Reps = reps;
        Weight = weight;
    }
    public void UpdateWeight(double weight)
{
    Weight = weight;
}


    public void DisplayExercise() 
    {
        Console.WriteLine($"Exercise: {Name}, {Sets} sets x {Reps} reps @ {Weight} lbs");
    }
}

public class WorkoutSession
{
    public string WorkoutType { get; set; }
    public List<Exercise> Exercises { get; set; }
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }

    public WorkoutSession(string workoutType, List<Exercise> exercises, DateTime startTime, DateTime endTime)
    {
        WorkoutType = workoutType;
        Exercises = new List<Exercise>(exercises);
        StartTime = startTime;
        EndTime = endTime;
    }

    public void DisplaySession()
    {
        Console.WriteLine($"\nWorkout Type: {WorkoutType}");
        Console.WriteLine($"Start: {StartTime}");
        Console.WriteLine($"End: {EndTime}");
        foreach (var ex in Exercises)
        {
            ex.DisplayExercise();
        }
        Console.WriteLine($"Duration: {(EndTime - StartTime).TotalMinutes:F2} minutes");
    }
}


