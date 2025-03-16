using System;

class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _totalPoints = 0; // Track total points
    private int _bonusPoints = 0; // Track bonus total points
    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void DisplayGoals()
    {
        Console.WriteLine("\nYour Goals:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetStatus()}");
        }
    }

    public void RecordGoal()
    {
        DisplayGoals();
        Console.Write("\nWhich goal did you accomplish? ");

        if (int.TryParse(Console.ReadLine(), out int index) && index > 0 && index <= _goals.Count)
    {
        Goal goal = _goals[index - 1]; // Adjust for 0-based index
        if (!goal.IsCompleted)
        {
            int pointsEarned = goal.GetPoints(); // Store points before marking goal
            goal.RecordEvent();
            _totalPoints += pointsEarned; // Add stored points
            Console.WriteLine($"You earned {pointsEarned} points! Total: {_totalPoints}");
        }
        else
        {
            Console.WriteLine("This goal is already completed.");
    }
    }
    }

    public void SaveGoals()
    {
        Console.Write("Enter a filename to save: ");
        string filename = Console.ReadLine();

        List<string> lines = new List<string> { _totalPoints.ToString() }; // Save total points
        foreach (Goal goal in _goals)
        {
            lines.Add(goal.ToString());
        }
        File.WriteAllLines(filename, lines);
    }

    public void LoadGoals()
    {
        Console.Write("Enter a filename to load: ");
        string filename = Console.ReadLine();
        
        string[] lines = File.ReadAllLines(filename);
        _totalPoints = int.Parse(lines[0]); // Load total points
        _goals.Clear();

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split(',');
            string type = parts[0];
            string name = parts[1];
            string description = parts[2];
            int points = int.Parse(parts[3]);
            bool completed = (parts[4] == "1");

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(name, description, points) { IsCompleted = completed });
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(name, description, points));
            }
            else if (type == "ChecklistGoal")
            {
                int count = int.Parse(parts[5]);
                int target = int.Parse(parts[6]);
                _goals.Add(new ChecklistGoal(name, description, points, target, count));
            }
        }
        }
        public int GetTotalPoints()
        {
        return _totalPoints + _bonusPoints;
        }
}