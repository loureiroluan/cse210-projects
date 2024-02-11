class Program
{
    static void Main(string[] args)
    {
        GoalManager goalManager = new GoalManager();

        goalManager.LoadGoals("goals.txt");

        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("1. Create New Goal");
            Console.WriteLine("2. List Goals");
            Console.WriteLine("3. Save Goals");
            Console.WriteLine("4. Load Goals");
            Console.WriteLine("5. Record Events");
            Console.WriteLine("6. Quit");
            Console.Write("Enter your choice: ");
            int choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1:
                    CreateNewGoal(goalManager);
                    break;
                case 2:
                    goalManager.ListGoalDetails();
                    break;
                case 3:
                    goalManager.SaveGoals("goals.txt");
                    Console.WriteLine("Goals saved successfully.");
                    break;
                case 4:
                    goalManager.LoadGoals("goals.txt");
                    Console.WriteLine("Goals loaded successfully.");
                    break;
                case 5:
                    RecordEvents(goalManager);
                    break;
                case 6:
                    exit = true;
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number between 1 and 6.");
                    break;
            }
        }
    }

    static void CreateNewGoal(GoalManager goalManager)
    {
        Console.WriteLine("Choose the type of goal:");
        Console.WriteLine("1. Eternal Goal");
        Console.WriteLine("2. Simple Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Which type of goal would you like to create? ");
        int typeChoice = int.Parse(Console.ReadLine());

        Console.Write("What is the name of your goal? ");
        string name = Console.ReadLine();
        Console.Write("What is a short description of it? ");
        string description = Console.ReadLine();
        Console.Write("What is the amount of points associated with this goal? ");
        int points = int.Parse(Console.ReadLine());

        switch (typeChoice)
        {
            case 1:
                goalManager.CreateGoal(name, description, points);
                break;
            case 2:
                Console.Write("Is this goal already completed? (true/false): ");
                bool isComplete = bool.Parse(Console.ReadLine());
                goalManager.CreateSimpleGoal(name, description, points, isComplete);
                break;
            case 3:
                Console.Write("How many times does this goal need to be accomplished for a bonus? ");
                int target = int.Parse(Console.ReadLine());
                Console.Write("What is the bonus for accomplishing it that many times? ");
                int bonus = int.Parse(Console.ReadLine());
                goalManager.CreateChecklistGoal(name, description, points, target, bonus);
                break;
            default:
                Console.WriteLine("Invalid choice.");
                break;
        }
    }

    static void RecordEvents(GoalManager goalManager)
    {
        goalManager.ListGoalNames();
        Console.Write("Enter the index of the goal to record event: ");
        int goalIndex = int.Parse(Console.ReadLine()) - 1;
        goalManager.RecordEvent(goalIndex);
    }
}