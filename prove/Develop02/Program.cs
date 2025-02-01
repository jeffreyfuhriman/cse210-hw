using System;
using System.Collections.Generic;
using System.IO;
// I tried exceeding the core requirements by creating a try/catch in the SaveJournalToFile
// and LoadJournalFromFile methods and displaying error messages when the load or save doesn't
// work properly. I also added "Journal loaded successfully" and "Journal saved successfully" to 
// provide a better user experience! 

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        string userInput;
        do
        {
            Console.WriteLine("\nPlease select one of the following choices:");
            Console.WriteLine("1. Write");
            Console.WriteLine("2. Display");
            Console.WriteLine("3. Save");
            Console.WriteLine("4. Load");
            Console.WriteLine("5. Quit");
            Console.Write("What would you like to do? ");
            userInput = Console.ReadLine();

            switch (userInput)
            {
                 case "1":
                    journal.AddEntry();
                    break;
                case "2":
                    journal.DisplayJournal();
                    break;
                case "3":
                    journal.SaveJournalToFile();
                    break;
                case "4":
                    journal.LoadJournalFromFile();
                    break;
                case "5":
                    Console.WriteLine("See you next time!");
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        } while (userInput != "5");
    }
}

class Journal
{
    static List<Entry> _entries = new List<Entry>();
    static List<string> _prompts = new List<string>
    {
        "What was my biggest success today?",
        "If I could go back in time today to relive a moment, when would it be?",
        "How did I self improve today?",
        "On a scale of 1-10, rate your day and why you chose that number.",
        "What do you wish you could've done differently today?"
    };

    public void AddEntry()
    {
        Random randomPrompt = new Random();
        string prompt = _prompts[randomPrompt.Next(_prompts.Count)];

        Console.WriteLine($"{prompt}");
        Console.Write("> ");
        string response = Console.ReadLine();

        Entry entry = new Entry(prompt, response);
        _entries.Add(entry);
    }

    public void DisplayJournal()
    {
        foreach (Entry entry in _entries)
        {
            Console.WriteLine(entry.ToString());
        }
    }

    public void SaveJournalToFile()
    {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    writer.WriteLine(entry.ToString());
                }
            }
            Console.WriteLine("Journal saved successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while saving the journal: {ex.Message}");
        }
    }

    public void LoadJournalFromFile()
    {
        Console.WriteLine("What is the filename?");
        string filename = Console.ReadLine();
        try
        {
            using (StreamReader reader = new StreamReader(filename))
            {
                string line;
                _entries.Clear();

                while ((line = reader.ReadLine()) != null)
                {
                    _entries.Add(Entry.FromString(line));
                }
            }
            Console.WriteLine("Journal loaded successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while loading the journal: {ex.Message}");
        }
    }
}

class Entry
{
    public string Prompt { get; set; }
    public string Response { get; set; }
    public DateTime Date { get; set; }

    public Entry(string prompt, string response) : this(prompt, response, DateTime.Now) {}
    public Entry(string prompt, string response, DateTime date)
    {
        Prompt = prompt;
        Response = response;
        Date = date;
    }

    public override string ToString()
    {
        return $"Date: {Date} - Prompt: {Prompt}\n{Response}";
    }
    public static Entry FromString(string line)
    {
        return new Entry("Loaded Prompt", line, DateTime.Now);
    }
}