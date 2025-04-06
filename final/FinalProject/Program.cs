using System;
using System.Text.Json;

class WorkoutTracker
{
    static UserStats userStats = new UserStats();
    static List<WorkoutSession> sessionHistory = new List<WorkoutSession>();
    static UserProfile currentUserProfile;

    static void Main(string[] args)
    {
        Console.WriteLine("Welocme to Workout Tracker!\n");
        Console.WriteLine("1. Load Profile");
        Console.WriteLine("2. Create New Profile");
        Console.Write("Select an option to begin: ");
        string profileChoice = Console.ReadLine();

        if (profileChoice == "1")
        {
            LoadUserData();
        }
        else
        {
            CreateNewProfile();
        }

        bool running = true;
        while(running)
        {
            Console.WriteLine("Workout Tracker Menu");
            Console.WriteLine("1. Display Workouts");
            Console.WriteLine("2. Start a New Workout");
            Console.WriteLine("3. Save Profile Data");
            Console.WriteLine("4. Load Other Profile");
            Console.WriteLine("5. View Statistics");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    DisplayWorkouts();
                    break;
                case "2":
                    StartWorkout();
                    break;
                case "3":
                    SaveUserData();
                    break;
                case "4":
                    LoadUserData();
                    break;
                case "5":
                    userStats.ViewStatistics();
                    currentUserProfile.ViewStats();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("\nSee you next time!\n");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }

    static void CreateNewProfile()
    {
        Console.Write("\nEnter your name: ");
        string name = Console.ReadLine();
        Console.Write("Enter your age: ");
        int age = int.Parse(Console.ReadLine());
        Console.Write("Enter your weight (lbs): ");
        double weight = double.Parse(Console.ReadLine());

        currentUserProfile = new UserProfile(name, age, weight);
        Console.WriteLine($"\nProfile created for {name}!\n");
    }

    static void LoadUserData()
    {
        Console.Write("\nEnter profile filename to load: ");
        string filename = Console.ReadLine();

        if (File.Exists(filename))
        {
            string jsonData = File.ReadAllText(filename);
            UserData userData = JsonSerializer.Deserialize<UserData>(jsonData);
            currentUserProfile = userData.Profile;
            userStats = userData.Stats;

            Console.WriteLine($"Welcome back, {currentUserProfile.Name}!");
            Console.WriteLine("Stats loaded successfully!");
        }
        else
        {
            Console.WriteLine($"Error: File not found. Creating new profile!");
            CreateNewProfile();
        }
    }
    
    static void SaveUserData()
    {
        Console.WriteLine("\nSaving profile and stats data...");

        UserData userData = new UserData
        {
            Profile = currentUserProfile,
            Stats = userStats
        };

        Console.Write("\nEnter a filename to save data: ");
        string filename = Console.ReadLine();

        string jsonData = JsonSerializer.Serialize(userData, new JsonSerializerOptions { WriteIndented = true });

        // Write JSON data to file
        File.WriteAllText(filename, jsonData);
        Console.WriteLine($"Profile data saved to file named: {filename}");
    }
    static void DisplayWorkouts()
    {
        Console.WriteLine("\nAll Workouts:");
        Console.WriteLine("\nPush Workouts:");
        Console.WriteLine("1. Bench press");
        Console.WriteLine("2. Dumbell Incline Bench Press");
        Console.WriteLine("3. Triceps Pushdown");
        Console.WriteLine("Pull Workouts:");
        Console.WriteLine("1. Back Squat");
        Console.WriteLine("2. Weighted Lunges");
        Console.WriteLine("3. Calf Raises");
        Console.WriteLine("Leg Workouts:");
        Console.WriteLine("1. Lat Pulldowns");
        Console.WriteLine("2. Bicep Curls");
        Console.WriteLine("3. Seated Rows\n");
    }

    static void StartWorkout()
    {
        Console.WriteLine("\nSelect Workout Type:");
        Console.WriteLine("1. Push Workout");
        Console.WriteLine("2. Pull Workout");
        Console.WriteLine("3. Leg Workout\n");
        Console.Write("Enter your choice: ");
        string workoutChoice = Console.ReadLine();
        Workout selectedWorkout = null;
        string type = "";

        switch (workoutChoice)
        {
            case "1":
                selectedWorkout = new PushWorkout();
                type = "Push";
                break;
            case "2":
                selectedWorkout = new PullWorkout();
                type = "Pull";
                break;
            case "3":
                selectedWorkout = new LegWorkout();
                type = "Leg";
                break;
            default:
                Console.WriteLine("INvalid choice.");
                return;
        }
        
        DateTime startTime = DateTime.Now;
        Console.WriteLine($"\nStarting {type} Workout!");
        ShowAnimation();

        List<Exercise> completedExercises = new List<Exercise>();
        double totalWeightThisWorkout = 0;
        int totalRepsThisWorkout = 0;
      
        foreach (var exercise in selectedWorkout.Exercises)
        {
            Console.WriteLine($"\nExercise: {exercise.Name}, {exercise.Sets} sets x {exercise.Reps} reps");
            Console.Write("Enter the weight used (lbs): ");
            if (double.TryParse(Console.ReadLine(), out double weight))
            {
                exercise.UpdateWeight(weight);
                completedExercises.Add(exercise);

                double exerciseTotal = exercise.Sets * exercise.Reps * weight;
                totalWeightThisWorkout += exerciseTotal;
                totalRepsThisWorkout += exercise.Sets * exercise.Reps;

                Console.WriteLine($"You lifted {exerciseTotal} lbs total for {exercise.Name}.");
            }
        }

        DateTime endTime = DateTime.Now;
        TimeSpan duration = endTime - startTime;

        userStats.AddWorkout(type, totalRepsThisWorkout, duration.TotalSeconds);
        userStats.TotalWeightLifted += totalWeightThisWorkout;

        WorkoutSession session = new WorkoutSession(type, completedExercises,  startTime, endTime);
        sessionHistory.Add(session);
        Console.WriteLine("\nWorkout complete, awesome job!!");
        Console.WriteLine($"\n--- Workout Breakdown ---");
        Console.WriteLine($"- Duration: {duration.Minutes} min {duration.Seconds} sec");
        Console.WriteLine($"- Weight lifted: {totalWeightThisWorkout} lbs\n");
    }

    static void ShowAnimation() // Spinning wheel animation
    {
        List<string> animationStrings = new List<string>();
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("—");
        animationStrings.Add("\\");
        animationStrings.Add("|");
        animationStrings.Add("/");
        animationStrings.Add("—");
        animationStrings.Add("\\");


        foreach (string s in animationStrings)
        {
            Console.Write(s);
            Thread.Sleep(250);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }
}

public class UserStats
    {
        public int TotalWorkouts { get; set; }
        public int PushWorkouts { get; set; }
        public int PullWorkouts { get; set; }
        public int LegWorkouts { get; set; }
        public int TotalReps { get; set; }
        public double TotalTime { get; set; }
        public double TotalWeightLifted { get; set; }

        public void AddWorkout(string workoutType, int reps, double duration)
        {
            TotalWorkouts++;
            TotalReps += reps;
            TotalTime += duration;
            
            switch (workoutType)
            {
                case "Push":
                    PushWorkouts++;
                    break;
                case "Pull":
                    PullWorkouts++;
                    break;
                case "Leg":
                    LegWorkouts++;
                    break;
            }
        }

        public string GetFormattedWorkoutTime()
        {
            TimeSpan time = TimeSpan.FromSeconds(TotalTime);
            return $"{(int)time.TotalHours:D2}:{time.Minutes:D2}:{time.Seconds:D2}";
        }

        public void ViewStatistics()
        {
        Console.WriteLine("\n--- Workout Statistics ---\n");
        Console.WriteLine($"Total workouts completed: {TotalWorkouts}");
        Console.WriteLine($"Push workouts: {PushWorkouts}");
        Console.WriteLine($"Pull workouts: {PullWorkouts}");
        Console.WriteLine($"Leg workouts: {LegWorkouts}");
        Console.WriteLine($"Total reps completed: {TotalReps}");
        Console.WriteLine($"Total weight lifted: {TotalWeightLifted} lbs\n");
        int totalSeconds = (int)(TotalTime);
        int hours = totalSeconds / 3600;
        int minutes = (totalSeconds % 3600) / 60;
        int seconds = totalSeconds % 60;
        Console.WriteLine($"Total time worked out: {hours}h {minutes}m {seconds}s\n");
        }
    }

public class UserData
{
    public UserProfile Profile { get; set; }
    public UserStats Stats { get; set; }
}