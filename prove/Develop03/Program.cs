using System;
using System.Collections.Generic;
using System.Linq;

public class Program
{
    public static void Main()
    {
        ScriptureMemorizerApp app = new ScriptureMemorizerApp();
        app.Run();
    }
}

public class ScriptureMemorizerApp
{
    private readonly Scripture _scripture;

    public ScriptureMemorizerApp()
    {
        _scripture = new Scripture(new Reference("James", 1, 5, 6), "If any of you lack wisdom, let him ask of God, that giveth to all men liberally,\n\r and upbraideth not, and it shall be given him; But let him ask in faith, nothing wavering.\n\r For he that wavereth is like a wave of the sea driven with wind and tossed.");
    }

    public void Run()
    {
        Console.WriteLine("Welcome to Scripture Memorizer!");

        do
        {
            Console.Clear();
            _scripture.Display();

            Console.WriteLine("Press Enter to continue or type 'quit' to exit.");
            string userInput = Console.ReadLine();

            if (userInput.ToLower() == "quit")
                break;

            if (userInput == "")
            {
                _scripture.HideRandomWords();
            }

        } while (!_scripture.AllWordsHidden);

        Console.WriteLine("Memorization completed. Good job!");

        Console.WriteLine("");

        //Exceeding Requirements
        //I added this part called "Think about it" so that after memorizing the scripture the user can think about what he memorized
        Console.WriteLine("Think About it:");

        Console.WriteLine("");

        Console.WriteLine("This scripture teaches us that if we lack wisdom we can ask God that was what the young Joseph Smith \n\r did when he read this scripture, after that, he prayed and had what is known as the First Vision \n\r and the restoration of the gospel of Jesus Christ. Think about the questions you have when you are memorizing these verses, and then ask God!");
    }

}