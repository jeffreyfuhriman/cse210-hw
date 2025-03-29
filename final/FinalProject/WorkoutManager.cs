using System;
using System.Dynamic;

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
        GetSummary();
    }
    public void AddExercise(Exercise exercise) 
    {
        ExerciseList.Add(exercise);
        Console.WriteLine($"Exercise added: {exercise.Name}");
    }

    public void SaveWorkout() 
    {
        Console.WriteLine("Workout saved!");
    }

    public void GetSummary() 
    {
        Console.WriteLine("Getting workout summary...");
    }
}

class UserProfile 
    {
    public string Name { get; private set; }
    public  int Age { get; private set; }
    public double Weight { get; private set; }
    private List<WorkoutManager> WorkoutHistory;

    public UserProfile(string name, int age, double weight) 
    {
        Name = name;
        Age = age;
        Weight = weight;
        WorkoutHistory = new List<WorkoutManager>();
    }

    public void AddWorkout() 
    {
        Console.WriteLine("Workout added to history: ");
    }

    public void ViewStats() 
    {
        Console.WriteLine("Displaying stats...");
    }
}

class Exercise 
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

    public void DisplayExercise() 
    {
        Console.WriteLine($"Exercise: {Name}, {Sets} sets x {Reps} reps @ {Weight} lbs");
    }
}


