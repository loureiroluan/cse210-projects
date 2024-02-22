class Workout
{
    public List<Exercise> Exercises { get; set; }
    public TimeSpan Duration { get; set; }
    public DateTime Date { get; set; }
    public User User { get; set; }

    public Workout()
    {
        Exercises = new List<Exercise>();
        Date = DateTime.Now;
    }

    public void AddExercise(Exercise exercise)
    {
        Exercises.Add(exercise);
    }

    public void StartWorkout()
    {
        Console.WriteLine("Workout started.");
    }
    public void EndWorkout()
    {
        Console.WriteLine("Workout ended.");
    }
}
