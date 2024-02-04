using System;
using System.Collections.Generic;

//Exceeding the requirements 
//I added the option for the user to save what he wrote in the Listing class
//

class Program
{
    static void Main()
    {
        List<Activity> activities = new List<Activity>
        {
            new BreathingActivity(),
            new ReflectingActivity(),
            new ListingActivity()
        };

        while (true)
        {
            Console.WriteLine("\nMindfulness Activities");
            Console.WriteLine("");
            Console.WriteLine("\nMenu Options:");

            for (int i = 0; i < activities.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {activities[i].GetName()}");
            }

            Console.Write("Select a choice from the menu (or 'exit' to quit): ");
            string choice = Console.ReadLine();

            if (choice.ToLower() == "exit")
                break;

            if (int.TryParse(choice, out int activityIndex) && activityIndex >= 1 && activityIndex <= activities.Count)
            {
                Console.Write("Enter the duration in seconds: ");
                if (int.TryParse(Console.ReadLine(), out int duration))
                {
                    activities[activityIndex - 1].Run(duration);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid duration.");
                }
            }
            else
            {
                Console.WriteLine("Invalid choice. Please enter a valid number.");
            }
        }
    }
}
