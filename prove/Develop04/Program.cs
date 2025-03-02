// I added creativity by keeping track of how many activites were done before quitting
// the program. I display it each time the user views the menu and also when the user quits
// the program!

using System;

abstract class Activity  // Activity parent class
{
    protected string Name { get; set; }
    protected string Description { get; set; }
    protected int Duration { get; set; }

    protected Activity(string name, string description)
    {
        Name = name;
        Description = description;
    }

    protected void Start()
    {
        Console.Clear();
        Console.WriteLine($"Welcome to the {Name} Activity!");
        Console.WriteLine();
        Console.WriteLine(Description);
        Console.WriteLine();
        Console.Write("How long, in seconds, would you like for your session? ");
        Duration = int.Parse(Console.ReadLine() ?? "10");
        Console.WriteLine("Get ready...");
        Pause(3);
    }

    protected void End()
    {
        Console.WriteLine("Great work!");
        Console.WriteLine($"You completed another {Duration} seconds of the {Name}.");
        ShowAnimation();
        Console.Clear();
    }

    protected void Pause(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000);
            Console.Write("\b \b");
        }
        Console.WriteLine();
    }

    protected void ShowAnimation() // Spinning wheel animation
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
    protected abstract void Run();

    public void Execute() 
    {
        Run();
    }
}

class BreathingActivity : Activity
{
    public BreathingActivity() : base("Breathing Activity", "This activity will help you relax by guiding your breathing through inhaling and exhaling with a timer.") { }

    protected override void Run()
    {
        ShowAnimation();
        Start();
        int elapsed = 0;
        while (elapsed <= Duration)
        {
            Console.WriteLine();
            Console.Write("Breathe in...");
            Pause(5);
            elapsed += 5;
            if (elapsed >= Duration) break;
            Console.Write("Breathe out...");
            Pause(5);
            elapsed += 5;
        }
        End();
    }
}

class ReflectionActivity : Activity
{
    private static readonly string[] Prompts =
{
    "--- Think of a time when you stood up for someone else. ---",
    "--- Think of a time when you did something really difficult. ---",
    "--- Think of a time when you helped someone in need. ---",
    "--- Think of a time when you overcame a fear. ---",
    "--- Think of a time when you worked as part of a team to achieve a goal. ---",
    "--- Think of a time when you made a tough decision and learned from it. ---"
};


    private static readonly string[] Questions =
{
    "> Why was this experience meaningful to you?",
    "> How did you feel when it was complete?",
    "> What could you learn from this experience?",
    "> What challenges did you face and how did you overcome them?",
    "> How did this experience shape your perspective or values?",
    "> If you could go back, would you do anything differently?"
};


    public ReflectionActivity() : base("Reflection Activity", "This activiy will help you reflect on different times in your life by asking a couple of simple questions to ponder.") { }

    protected override void Run()
    {
        ShowAnimation();
        Console.Clear();
        Start();
        Console.Clear();
        Random rand = new Random();
        string selectedPrompt = Prompts[rand.Next(Prompts.Length)]; // Pick the prompt once
        Console.WriteLine(selectedPrompt);

        Console.WriteLine("When you have something in mind, press enter to continue.");
        Console.ReadLine();

        Console.WriteLine("Now ponder the following questions as they relate to this experience:");
        Console.Write("You may begin in: ");
        Pause(3);

        Console.Clear();

        int elapsed = 0;
        while (elapsed < Duration)
        {
            Console.Write(Questions[rand.Next(Questions.Length)]);
            ShowAnimation();
            Thread.Sleep(5000);
            elapsed += 5;
        }
        End();
    }
}

class ListingActivity : Activity
{
    private static readonly string[] Prompts =
    {
        "--- Who are people that you appreciate? ---",
        "--- What are personal strengths of yours? ---",
        "--- Who are people that you have helped this week? ---"
    };

    public ListingActivity() : base("Listing Activity", "This activity helps you list as many positive things as you can in your life.") { }

    protected override void Run()
    {
        ShowAnimation();
        Start();
        Random rand = new Random();
        Console.WriteLine("List as many responses as you can to the following prompt:");
        Console.WriteLine(Prompts[rand.Next(Prompts.Length)]);
        Pause(3);

        List<string> responses = new List<string>();

        DateTime startTime = DateTime.Now;
        DateTime endTime = startTime.AddSeconds(Duration);
        
        while (DateTime.Now < endTime)
        {
            Console.Write("> ");
            string response = Console.ReadLine();
            responses.Add(response);  // Add the response to the list
        }

        Console.WriteLine($"You listed {responses.Count} items.");
        End();
    }
}

class Program
{
    private static int activityCount = 0;
    static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("Menu Options:");
            Console.WriteLine("   1. Start breathing activity");
            Console.WriteLine("   2. Start reflection activity");
            Console.WriteLine("   3. Start listing activity");
            Console.WriteLine("   4. Quit");
            Console.Write("Select a choice from the menu: ");

            string choice = Console.ReadLine();

            Activity activity = choice switch
            {
                "1" => new BreathingActivity(),
                "2" => new ReflectionActivity(),
                "3" => new ListingActivity(),
                "4" => null,
                _ => null
            }; 

            if (choice == "4")
            {
                Console.WriteLine($"Goodbye! You completed {activityCount} activities, great work!");
                break;
            }

            if (activity != null)
            {
                activity.Execute();
                activityCount++;
                Console.WriteLine($"You have completed {activityCount} activities so far!");
            }
        }
    }
}
