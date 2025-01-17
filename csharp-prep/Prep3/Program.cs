using System;

class Program
{
    static void Main(string[] args)
    {
        // Initialize guess.
        int guess = -1;
        Random randomGenerator = new Random();
        int number = randomGenerator.Next(1, 11);
        // Console.Write("What is the magic number? ");
        // string userMagicNumber = Console.ReadLine();
        // int realMagicNumber = int.Parse(userMagicNumber);

        while (guess != number)
        {
            Console.Write("What is your guess? ");
            guess = int.Parse(Console.ReadLine());
            // string userGuess = Console.ReadLine();
            // int realGuess = int.Parse(userGuess);
            // guess = realGuess; // Update the guess variable

            if (number > guess)
            {
                Console.WriteLine("Higher");
            } 
            else if (number < guess)
            {
                Console.WriteLine("Lower");
            }
        }
        Console.WriteLine("You guessed it!");
    }
}