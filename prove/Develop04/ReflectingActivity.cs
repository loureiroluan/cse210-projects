using System;
using System.Collections.Generic;
using System.Threading;

public class ReflectingActivity : Activity
{
    private readonly List<string> prompts = new List<string>
    {
        "---Think of a time when you stood up for someone else.---",
        "---Think of a time when you did something really difficult.---",
        "---Think of a time when you helped someone in need.---",
        "---Think of a time when you did something truly selfless.---"
    };

    private readonly List<string> reflectionQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?",
    };

    public ReflectingActivity() : base("Reflecting", "This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.")
    {
    }

    protected override void DoActivity(int duration)
    {
        Random random = new Random();

        string randomPrompt = prompts[random.Next(prompts.Count)];

        Console.WriteLine($"Consider the following prompt:\n{randomPrompt}");
        WaitForEnter();

        int remainingTime = duration;

        while (remainingTime > 0)
        {
            string randomQuestion = GetRandomQuestion();
            Console.WriteLine(randomQuestion);

            Thread.Sleep(3000);
            remainingTime -= 3000;
        }    
    }
    private string GetRandomQuestion()
    {
        Random random = new Random();
        return reflectionQuestions[random.Next(reflectionQuestions.Count)];
    }

    private void WaitForEnter()
    {
        Console.WriteLine("Press Enter to continue...");
        Console.ReadLine();
    }
}


