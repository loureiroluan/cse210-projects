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

        for (int i = 5; i > 0; i--)
        {
            string prompt = GetRandomPrompt();
            Console.WriteLine("Consider the following prompt:");
            Console.WriteLine(prompt);
            WaitForEnter();
            
            string reflectionQuestion = GetRandomQuestion();
            Console.WriteLine(reflectionQuestion);
            List<string> animationStrings = new List<string> { "|", "/", "-", "\\" };
            {
            foreach (string s in animationStrings)
            {
                Console.Write(s);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
            }
        }
    }

    private string GetRandomPrompt()
    {
        return prompts[new Random().Next(prompts.Count)];
    }

    private string GetRandomQuestion()
    {
        return reflectionQuestions[new Random().Next(reflectionQuestions.Count)];
    }

    private void WaitForEnter()
    {
        Console.WriteLine("When you have something in mind, press Enter to continue...");
        Console.ReadLine();
        Console.WriteLine("Now ponder on each of the following questions as they related to this experience");
        Console.WriteLine("You may begin in:");
            for (int i = 5; i > 0; i--)
            {
                Console.Write(i);
                Thread.Sleep(1000);
                Console.Write("\b \b");
            }
    }
}
