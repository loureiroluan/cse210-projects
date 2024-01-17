using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job();
        job1._jobTitle = "Sales Manager";
        job1._company= "Flor de Iris";
        job1._startYear= 2019;
        job1._endYear= 2023;

        Job job2 = new Job();
        job2._jobTitle = "Sales Agent";
        job2._company = "USA Containers";
        job2._startYear = 2023;
        job2._endYear = 2024;

        Resume myResume = new Resume();
        myResume._name = "Luan Loureiro";

        myResume._jobs.Add(job1);
        myResume._jobs.Add(job2);

        myResume.Display();
    }
}