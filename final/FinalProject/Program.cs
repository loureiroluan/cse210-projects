using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static User loggedInUser;
    static FitnessTracker tracker = new FitnessTracker();
    static List<Workout> workouts = new List<Workout>();
    static List<PerformanceMetric> performanceMetrics = new List<PerformanceMetric>();
    static List<Goal> goals = new List<Goal>();
    static DietPlan dietPlan = new DietPlan();
    static void Main(string[] args)
    {
        bool exit = false;

        while (!exit)
        {
            Console.WriteLine("\nFitness Tracking App Menu:");
            Console.WriteLine("1. Register User");
            Console.WriteLine("2. Log In");
            Console.WriteLine("3. Update Profile");
            Console.WriteLine("4. Create Workout");
            Console.WriteLine("5. View Workouts");
            Console.WriteLine("6. Record Performance");
            Console.WriteLine("7. View Progress");
            Console.WriteLine("8. Generate Report");
            Console.WriteLine("9. Set Goals");
            Console.WriteLine("10. Plan Diet");
            Console.WriteLine("11. Exit");
            Console.Write("Enter your choice: ");

            int choice;
            if (!int.TryParse(Console.ReadLine(), out choice))
            {
                Console.WriteLine("Invalid input. Please enter a number.");
                continue;
            }

            switch (choice)
            {
                case 1:
                    // Register User
                    User newUser = new User();
                    Console.Write("Enter username: ");
                    newUser.Username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    newUser.Password = Console.ReadLine();
                    tracker.AddUser(newUser);
                    break;
                case 2:
                    // Log In
                    Console.Write("Enter username: ");
                    string username = Console.ReadLine();
                    Console.Write("Enter password: ");
                    string password = Console.ReadLine();

                    loggedInUser = tracker.Users.FirstOrDefault(u => u.Username == username && u.Password == password);

                    if (loggedInUser != null)
                    {
                        Console.WriteLine($"User '{username}' logged in successfully.");
                    }
                    else
                    {
                        Console.WriteLine("Invalid username or password.");
                    }
                    break;
                case 3:
                    // Update Profile
                    if (loggedInUser != null)
                    {
                        Console.Write("Enter age: ");
                        int age = int.Parse(Console.ReadLine());
                        Console.Write("Enter weight: ");
                        float weight = float.Parse(Console.ReadLine());
                        Console.Write("Enter height: ");
                        float height = float.Parse(Console.ReadLine());

                        loggedInUser.UpdateProfile(age, weight, height);
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;

                case 4:
                    // Create Workout
                    if (loggedInUser != null)
                    {
                        tracker.CreateWorkout(loggedInUser);
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;
                case 5:
                    if (loggedInUser != null)
                    {
                        Console.WriteLine("Workouts:");
                        foreach (var workout in workouts.Where(w => w.User == loggedInUser))
                        {
                            Console.WriteLine($"Date: {workout.Date}, Duration: {workout.Duration}");
                            foreach (var exercise in workout.Exercises)
                            {
                                Console.WriteLine($"Exercise: {exercise.Name}, Category: {exercise.Category}, Intensity: {exercise.Intensity}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;

                case 6:
                    if (loggedInUser != null)
                    {
                        PerformanceMetric metric = new PerformanceMetric();
                        Console.Write("Enter number of repetitions: ");
                        metric.Repetitions = int.Parse(Console.ReadLine());
                        Console.Write("Enter weight lifted: ");
                        metric.Weight = float.Parse(Console.ReadLine());
                        Console.Write("Enter duration (in minutes): ");
                        int durationMinutes = int.Parse(Console.ReadLine());
                        metric.Duration = TimeSpan.FromMinutes(durationMinutes);

                        performanceMetrics.Add(metric);
                        Console.WriteLine("Performance recorded successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;
                case 7:
                    if (loggedInUser != null)
                    {
                        Console.WriteLine($"User: {loggedInUser.Username}");
                        Console.WriteLine($"Age: {loggedInUser.Age}");
                        Console.WriteLine($"Weight: {loggedInUser.Weight} kg");
                        Console.WriteLine($"Height: {loggedInUser.Height} cm");
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;
                case 8:
                    if (loggedInUser != null)
                    {

                        Console.WriteLine("Report generation logic will be implemented here.");
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;
                case 9:
                    if (loggedInUser != null)
                    {
                        Console.Write("Enter goal description: ");
                        string description = Console.ReadLine();
                        Goal goal = new Goal(description);
                        goals.Add(goal);
                        Console.WriteLine($"Goal '{description}' set successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;
                case 10:
                    if (loggedInUser != null)
                    {
                        Console.WriteLine("Adding meals to diet plan:");
                        Console.Write("Enter meal: ");
                        string meal = Console.ReadLine();
                        dietPlan.AddMeal(meal);
                        Console.WriteLine($"Meal '{meal}' added to diet plan successfully.");
                    }
                    else
                    {
                        Console.WriteLine("No user logged in. Please log in first.");
                    }
                    break;
                case 11:
                    exit = true;
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 11.");
                    break;
            }
        }
    }
}


