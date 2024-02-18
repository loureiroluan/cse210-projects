class FitnessTracker
{
    private List<User> users;
    private List<Workout> workouts;
    private List<Goal> goals;
    private DietPlan dietPlan;

    public FitnessTracker()
    {
        users = new List<User>();
        workouts = new List<Workout>();
        goals = new List<Goal>();
        dietPlan = new DietPlan();
    }

    public void AddUser(User user)
    {
        users.Add(user);
        Console.WriteLine($"User '{user.Username}' added successfully.");
    }

    public void RemoveUser(User user)
    {
        users.Remove(user);
        Console.WriteLine($"User '{user.Username}' removed successfully.");
    }

    public void CreateWorkout(User user)
    {
        if (users.Contains(user))
        {
            Workout workout = new Workout();

            Console.WriteLine($"Workout created for user '{user.Username}'.");
        }
        else
        {
            Console.WriteLine("User not found.");
        }
    }

}