using System;

class Program
{
    static void Main(string[] args)
    {
        GoalManager manager = new GoalManager();
        bool running = true;

        while (running) {
            Console.WriteLine($"\nYou have {manager.GetTotalPoints()} points.");
            Console.WriteLine("\nEternal Quest Menu:");
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Event");
            Console.WriteLine("6. Exit");

            Console.Write("Select a choice from the menu: ");
            string choice = Console.ReadLine();

            switch (choice) {
                case "1":
                    Console.WriteLine("The types of Goals are:");
                    Console.WriteLine("1. Simple Goal");
                    Console.WriteLine("2. Eternal Goal");
                    Console.WriteLine("3. Checklist Goal");
                    Console.Write("Which type of goal would you like to create? ");
                    string type = Console.ReadLine();
                    Console.Write("What is the name of your goal? ");
                    string name = Console.ReadLine();
                    Console.Write("Enter a short description: ");
                    string description = Console.ReadLine();
                    Console.Write("How many points is this worth? ");
                    int points = int.Parse(Console.ReadLine());
                    if (type == "1") manager.AddGoal(new SimpleGoal(name, description, points));
                    else if (type == "2") manager.AddGoal(new EternalGoal(name, description, points));
                    else if (type == "3")
                    {
                        Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                        int target = int.Parse(Console.ReadLine());
                        Console.Write("How many bonus points is awarded for completing this goal? ");
                        int bonusPoints = int.Parse(Console.ReadLine());
                        manager.AddGoal(new ChecklistGoal(name, description, points, target, bonusPoints));
                    }
                    break;
                case "2":
                    manager.DisplayGoals();
                    break;
                case "3":
                    manager.SaveGoals();
                    break;
                case "4":
                    manager.LoadGoals();
                    break;
                case "5":
                    manager.RecordGoal();
                    break;
                case "6":
                    running = false;
                    break;
            }
        }
    }
}