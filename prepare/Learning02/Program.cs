using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._company = "Apple";
        job1._jobTitle = "Computer Engineer";
        job1._startYear = 2015;
        job1._endYear = 2020;
        // job1.Display();

        Job job2 = new Job();
        job2._company = "Minecraft";
        job2._jobTitle = "Software Engineer";
        job2._startYear = 2020;
        job2._endYear = 2024;
        // job2.Display();

        Resume theResume = new Resume();
        theResume._name = "Jeffrey Fuhriman";

        theResume._jobs.Add(job1);
        theResume._jobs.Add(job2);

        theResume.Display();

    }
}