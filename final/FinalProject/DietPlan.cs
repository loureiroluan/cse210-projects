class DietPlan
{
    public List<string> Meals { get; set; }

    public DietPlan()
    {
        Meals = new List<string>();
    }

    public void AddMeal(string meal)
    {
        Meals.Add(meal);
    }

    public void RemoveMeal(string meal)
    {
        Meals.Remove(meal);
    }
}

