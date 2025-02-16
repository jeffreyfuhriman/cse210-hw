using System;
// I've done 2 things to exceed the requirements for this assignment. I've gone ahead and created a list of scriptures
// that when the program is ran, will choose one random scripture to display from that list. I've also added a feature where 
// the user can choose how many words they'd like to hide each time they press enter. I feel these two additions will help 
// the program look more official and help the user master memorizing different scriptures. 

class Program
{
    static void Main(string[] args)
    {
        // List of random scriptures
       List<Scripture> scriptures = new List<Scripture>
        {
            new Scripture("2 Nephi", 2, "25", "Adam fell that men might be, and men are that they might have joy."),
            new Scripture("Mosiah", 2, "17", "When ye are in the service of your fellow beings ye are only in the service of your God."),
            new Scripture("1 Nephi", 3, "7", "And it came to pass that I, Nephi, said unto my father: I will go and do the things which the Lord hath commanded, for I know that the Lord giveth no commandments unto the children of men, save he shall prepare a way for them that they may accomplish the thing which he commandeth them."),
            new Scripture("Moroni", 10, "4-5", "And when ye shall receive these things, I would exhort you that ye would ask God, the Eternal Father, in the name of Christ, if these things are not true; and if ye shall ask with a sincere heart, with real intent, having faith in Christ, he will manifest the truth of it unto you, by the power of the Holy Ghost; And by the power of the Holy Ghost ye may know the truth of all things."),
            new Scripture("John", 14, "27", "Peace I leave with you, my peace I give unto you: not as the world giveth, give I unto you. Let not your heart be troubled, neither let it be afraid.")
        };

        Random random = new Random();
        Scripture selectedScripture = scriptures[random.Next(scriptures.Count)];
        
        // Get input from user to see how many words they'd like to disappear at a time
        Console.WriteLine("How many words would you like to hide at a time? ");
        int numWordsHidden;
        numWordsHidden = int.Parse(Console.ReadLine());
        

        while (true)
        {
            Console.Clear();
            Console.WriteLine(selectedScripture.DisplayText());
            Console.WriteLine("Press enter to continue or type 'quit' to finish:");
            string input = Console.ReadLine();

            if (input.ToLower() == "quit")
            {
                break; // Exit the program
            }

            selectedScripture.HideRandomWords(numWordsHidden);
        }
    }
}

class Reference
{
    public string Book;
    public int Chapter;
    public string Verses;
    public string FormattedReference;

    public Reference(string book, int chapter, string verses)
    {
        Book = book;
        Chapter = chapter;
        Verses = verses;
        FormattedReference = $"{Book} {Chapter}:{Verses}";
    }
}

class Word
{
    public string Text;
    public bool IsHidden;

    public Word(string text)
    {
        Text = text;
        IsHidden = false;
    }

    public void Hide()
    {
        IsHidden = true;
    }

    public override string ToString()
    {
        if (IsHidden)
        {
            return "____";
        }
        else
        {
            return Text;
        }
    }
}

class Scripture
{
    private Reference reference;
    private List<Word> words;

    public Scripture(string book, int chapter, string verses, string text)
    {
        reference = new Reference(book, chapter, verses);
        words = new List<Word>();

        string[] splitWords = text.Split(' ');
        foreach (string word in splitWords)
        {
            words.Add(new Word(word));
        }
    }

    public string DisplayText()
    {
        string displayedText = "";
        foreach(Word word in words)
        {
            displayedText += word.ToString() + " ";
        }
        return reference.FormattedReference + " " + displayedText.Trim();
    }

    public void HideRandomWords(int count)
    {
        Random random = new Random();
        int hiddenCount = 0;

        List<Word> nonHiddenWords = new List<Word>();
        foreach (Word word in words)
        {
            if (!word.IsHidden)
            {
                nonHiddenWords.Add(word);
            }
        }

        while (hiddenCount < count && nonHiddenWords.Count > 0)
        {
            int randomIndex = random.Next(nonHiddenWords.Count); // Pick a random word
            Word wordToHide = nonHiddenWords[randomIndex];
            wordToHide.Hide(); // Hide the word

            nonHiddenWords.RemoveAt(randomIndex);
            hiddenCount++;
        }
    }
}
