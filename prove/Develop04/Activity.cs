using System;
using System.Collections.Generic;
using System.Threading;

public class Activity
{
    protected string name;
    protected string description;

    public Activity(string name, string description)
    {
        this.name = name;
        this.description = description;
    }

    public string GetName()
    {
        return name;
    }

    public virtual void Run(int duration)
    {
        DisplayStartingMessage();
        DoActivity(duration);
        DisplayEndingMessage(duration);
    }

    protected void DisplayStartingMessage()
    {
        Console.WriteLine($"\n{GetName()} Activity - {description}");
        Console.WriteLine("Get ready to begin...");

        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };

        for (int i = 0; i < 3; i++) 
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(250);
                Console.Write("\b \b");
            }
        }

        Console.WriteLine();
    }

    protected virtual void DoActivity(int duration)
    {
        
    }

    protected void DisplayEndingMessage(int duration)
    {
        Console.WriteLine($"\nGood job! You have completed {GetName()} activity for {duration} seconds.");
        Thread.Sleep(3000);
    }

    protected void ShowSpinner(int seconds)
    {
        Console.WriteLine("Spinner animation (you can replace this with your own animation logic)...");
        Thread.Sleep(seconds * 1000);
    }

    protected void ShowCountDown(int seconds)
    {
        for (int i = seconds; i > 0; i--)
        {
            Console.WriteLine($"Countdown: {i} seconds remaining...");
            Thread.Sleep(1000);
        }
    }
}



