using System;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("What is your grade percentage?");
        string answer = Console.ReadLine();
        int percent = int.Parse(answer);

        string letter = "";
        
        if (percent >= 90)
        {
            letter = "A";
        }
        else if (percent >= 80)
        {
            letter = "B";
        }
        else if (percent >= 70)
        {
            letter = "C";
        }
        else if (percent >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        int lastDigit = percent % 10;
        string sign = (lastDigit >= 7) ? "+" : (lastDigit < 3) ? "-" : "";

        if (letter == "A" && lastDigit >= 7)
        {
            sign = "";
        }
        else if (letter == "F" && (lastDigit < 3 || lastDigit >= 7))
        {
            sign = "";
        }

        Console.WriteLine($"Your grade is {letter}{sign}");

        if (percent >=70)
        {
            Console.WriteLine("Congratulations! You passed!");
        }
        else
        {
            Console.WriteLine("Sorry, better luck next time!");
        }
    }
}