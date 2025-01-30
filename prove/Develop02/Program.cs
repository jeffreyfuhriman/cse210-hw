using System;

class Program
{
    static List<string> journal = new List<string>();
    static List<string> prompts = new List<string>
    {
        "What was my biggest success today?",
        "If I could go back in time today to relive a moment, when would it be?",
        "How did I self improve today?",
        "On a scale of 1-10, rate your day and why you chose that number.",
        "What do you wish you could've done differently today?"
    };

    static void Main(string[] args)
    {
        bool quit = false;

        while (!quit)
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                 case "1":
                    WriteNewEntry();
                    break;
                case "2":
                    DisplayJournal();
                    break;
                case "3":
                    SaveJournalToFile();
                    break;
                case "4":
                    LoadJournalFromFile();
                    break;
                case "5":
                    quit = true;
                    Console.WriteLine("Peace out Jeff!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void WriteNewEntry()
    {
        Random randomPrompt = new Random();
        string prompt = prompts[randomPrompt.Next(prompts.Count)];
        Console.WriteLine($"{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();
        string entry = $"\nDate: {DateTime.Now} - Prompt: {prompt}\n{response}";
        journal.Add(entry);
    }

    static void DisplayJournal()
    {
        foreach (string entry in journal)
        {
            Console.WriteLine(entry);
        }
    }

    static void SaveJournalToFile()
    {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        File.WriteAllLines(filename, journal);
    }

    static void LoadJournalFromFile()
    {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        journal = new List<string>(File.ReadAllLines(filename));
    }
}