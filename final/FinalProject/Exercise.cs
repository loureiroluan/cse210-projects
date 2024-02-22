class Exercise
{
    public string Name { get; set; }
    public string Category { get; set; }
    public string Intensity { get; set; }

    public void RecordPerformance(PerformanceMetric performance)
    {
        Console.WriteLine($"Performance for exercise '{Name}' recorded successfully.");
    }
}

