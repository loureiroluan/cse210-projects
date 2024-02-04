using System;
using System.Collections.Generic;
using System.Threading;

public class ListingActivity : Activity
{
    private readonly List<string> prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?"
    };

    private List<string> listedItems = new List<string>();

    public ListingActivity() : base("Listing", "This activity will help you reflect on the good things in your life.")
    {
    }

    protected override void DoActivity(int duration)
    {
        Random random = new Random();
        Console.WriteLine("You may begin in:");
        List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
        {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
        }

        string prompt = GetRandomPrompt();
        Console.WriteLine(prompt);

        int itemsListed = 0;

        while (true)
        {
            string item = GetListFromUser();
            if (item.ToLower() == "done")
                break;

            listedItems.Add(item);
            itemsListed++;
        }

        Console.WriteLine($"\nYou listed {itemsListed} items.");

        Console.Write("Do you want to save the list? (yes/no): ");
        string response = Console.ReadLine().ToLower();

        if (response == "yes")
        {
            SaveListToFile();
            Console.WriteLine("List saved successfully!");
        }
    }

    private string GetRandomPrompt()
    {
        return prompts[new Random().Next(prompts.Count)];
    }

    private string GetListFromUser()
    {
        Console.Write("Enter an answer (or 'done' to finish): ");
        return Console.ReadLine();
    }

    private void SaveListToFile()
    {
        Console.Write("Enter a filename to save the list: ");
        string fileName = Console.ReadLine();

        SaveToFile(string.Join(Environment.NewLine, listedItems), fileName);
    }

    private void SaveToFile(string content, string fileName)
    {
        try
        {
            System.IO.File.WriteAllText(fileName, content);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving to file: {ex.Message}");
        }
    }
}


