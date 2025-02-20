using System;

class Program
{
    static void Main(string[] args)
    {
        Assignment assignment1 = new Assignment();
        assignment1.SetName("Samuel Bennett");
        assignment1.SetTopic("Multiplication");

        Console.WriteLine(assignment1.GetSummary());

        MathAssignment assignment2 = new MathAssignment();
        assignment2.SetName("Roberto Rodriguez");
        assignment2.SetTopic("Fractions");
        assignment2.SetSection("7.3");
        assignment2.SetProblems("8-19");

        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetHomeworkList());

        WritingAssignment assignment3 = new WritingAssignment();
        assignment3.SetName("Mary Waters");
        assignment3.SetTopic("European History");
        assignment3.SetTitle("The Causes of World War II");

        Console.WriteLine(assignment3.GetSummary());
        Console.WriteLine(assignment3.GetWritingInformation());
    }
}