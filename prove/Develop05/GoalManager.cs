class GoalManager
{
    private List<Goal> _goals;
    private int _score;
    public void CreateSimpleGoal(string name, string description, int points, bool isComplete)
    {
        AddGoal(new SimpleGoal(name, description, points) { _isComplete = isComplete });
    }

    public void CreateChecklistGoal(string name, string description, int points, int target, int bonus)
    {
        AddGoal(new ChecklistGoal(name, description, points, target, bonus));
    }

    public GoalManager()
    {
        _goals = new List<Goal>();
        _score = 0;
    }

    public void AddGoal(Goal goal)
    {
        _goals.Add(goal);
    }

    public void RecordEvent(int goalIndex)
    {
        if (goalIndex >= 0 && goalIndex < _goals.Count)
        {
            _score += _goals[goalIndex].RecordEvent();
        }
        else
        {
            Console.WriteLine("Invalid goal index.");
        }
    }

    public void DisplayPlayerInfo()
    {
        Console.WriteLine($"Current Score: {_score}");
    }

    public void ListGoalNames()
    {
        Console.WriteLine("Goal Names:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i]._shortName}");
        }
    }

    public void ListGoalDetails()
    {
        Console.WriteLine("Goal Details:");
        for (int i = 0; i < _goals.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {_goals[i].GetDetailsString()}");
        }
    }

    public void CreateGoal(string name, string description, int points, int target = 0, int bonus = 0)
    {
        if (target == 0)
        {
            AddGoal(new SimpleGoal(name, description, points));
        }
        else
        {
            AddGoal(new ChecklistGoal(name, description, points, target, bonus));
        }
    }

    public void SaveGoals(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }

    public void LoadGoals(string filename)
    {
        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split('|');
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                if (parts.Length == 4)
                {
                    bool isComplete = bool.Parse(parts[3]);
                    AddGoal(new SimpleGoal(name, description, points) { _isComplete = isComplete });
                }
                else if (parts.Length == 6)
                {
                    int amountCompleted = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    AddGoal(new ChecklistGoal(name, description, points, target, bonus) { _amountCompleted = amountCompleted });
                }
            }
        }
    }
        public void SaveProgress(string filename)
    {
        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine($"Score: {_score}");

            foreach (Goal goal in _goals)
            {
                writer.WriteLine(goal.GetStringRepresentation());
            }
        }
    }
    public void LoadProgress(string filename)
    {
        _goals.Clear();
        using (StreamReader reader = new StreamReader(filename))
        {
            string line;
            bool firstLine = true;
            while ((line = reader.ReadLine()) != null)
            {
                if (firstLine) // Read and set score from the first line
                {
                    _score = int.Parse(line.Split(':')[1].Trim());
                    firstLine = false;
                    continue;
                }
                string[] parts = line.Split('|');
                string name = parts[0];
                string description = parts[1];
                int points = int.Parse(parts[2]);
                if (parts.Length == 4)
                {
                    bool isComplete = bool.Parse(parts[3]);
                    AddGoal(new SimpleGoal(name, description, points) { _isComplete = isComplete });
                }
                else if (parts.Length == 6)
                {
                    int amountCompleted = int.Parse(parts[3]);
                    int target = int.Parse(parts[4]);
                    int bonus = int.Parse(parts[5]);
                    AddGoal(new ChecklistGoal(name, description, points, target, bonus) { _amountCompleted = amountCompleted });
                }
            }
        }
    }                    
}  