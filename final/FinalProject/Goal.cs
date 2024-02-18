class Goal
{
    public string Description { get; set; }
    public bool IsAchieved { get; set; }

    public Goal(string description)
    {
        Description = description;
        IsAchieved = false;
    }

    public void UpdateProgress()
    {
        Console.WriteLine($"Progress for goal '{Description}' updated.");
    }
}
