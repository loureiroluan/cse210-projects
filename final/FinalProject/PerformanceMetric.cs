class PerformanceMetric
{
    public int Repetitions { get; set; }
    public float Weight { get; set; }
    public TimeSpan Duration { get; set; }

    public float CalculateCaloriesBurned()
    {
        return 0f;
    }

    public float CalculateAverageIntensity()
    {
        return 0f;
    }
}

