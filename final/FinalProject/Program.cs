using System;

class WorkoutTracker
{
    static void Main(string[] args)
    {
        bool running = true;
        while(running)
        {
            Console.WriteLine("Workout Tracker Menu");
            Console.WriteLine("1. Display Workouts");
            Console.WriteLine("2. Start a New Workout");
            Console.WriteLine("3. Save User Data");
            Console.WriteLine("4. Load User Data");
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
                    SaveUser();
                    break;
                case "4":
                    LoadUser();
                    break;
                case "5":
                    ViewStatistics();
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

    static void DisplayWorkouts()
    {
        Console.WriteLine("\nAll Workouts:");
        Console.WriteLine("Push Workouts:");
        Console.WriteLine("1. ~~~~");
        Console.WriteLine("2. ~~~~");
        Console.WriteLine("3. ~~~~");
        Console.WriteLine("Pull Workouts:");
        Console.WriteLine("1. ~~~~");
        Console.WriteLine("2. ~~~~");
        Console.WriteLine("3. ~~~~");
        Console.WriteLine("Leg Workouts:");
        Console.WriteLine("1. ~~~~");
        Console.WriteLine("2. ~~~~");
        Console.WriteLine("3. ~~~~\n");
    }

    static void StartWorkout()
    {
        Console.WriteLine("\nSelect Workout Type:");
        Console.WriteLine("1. Push Workout:");
        Console.WriteLine("2. Pull Workout:");
        Console.WriteLine("3. Leg Workout:\n");
        Console.Write("Enter your choice:");
        string workout_choice = Console.ReadLine();
    }

    static void SaveUser()
    {
        Console.WriteLine("\nSaving user data...\n");
    }

    static void LoadUser()
    {
        Console.WriteLine("\nLoading user data...\n");
    }

    static void ViewStatistics()
    {
        Console.WriteLine("\nStatistics: \n");
    }
    
}
