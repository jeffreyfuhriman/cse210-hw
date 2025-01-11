using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {
        string letter = "";
        Console.Write("What is your grade percentage? ");
        string grade = Console.ReadLine();
        int gradePercentage = int.Parse(grade);
        if (gradePercentage >= 90)
        {
            letter = "A";
            Console.WriteLine($"You have an {letter}");
        }
        else if (gradePercentage >= 80)
        {
            letter = "B";
            Console.WriteLine($"You have a {letter}");
        }
        else if (gradePercentage >= 70)
        {
            letter = "C";
            Console.WriteLine($"You have a {letter}");
        }
        else if (gradePercentage >= 60)
        {
            letter = "D";
            Console.WriteLine($"You have a {letter}");
        }
        else
        {
            letter = "F";
            Console.WriteLine($"You have an {letter}");
        }
        if (gradePercentage >=70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Sorry! You did not pass the class.");
        }
    }
}