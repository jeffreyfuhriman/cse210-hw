using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    
    {
        List<int> numbers = new List<int>();
        int user_number;
        Console.WriteLine("Enter a list of numbers, type 0 when finished. ");
        
        do
        {
            Console.Write("Enter a number: ");
            user_number = int.Parse(Console.ReadLine());
            if (user_number != 0)
            {
            numbers.Add(user_number);
            }
        } while (user_number != 0);

        // Compute the sum
        int sum = 0;
        foreach (int number in numbers)
        {
            sum += number;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Compute the average
        float average = ((float)sum) / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Find the max
        int max = numbers[0];
        foreach (int number in numbers)
        {
            if (number > max)
            {
                max = number;
            }
        }

        Console.WriteLine($"The max is: {max}");
    }
}