class User
{
    public string Username { get; set; }
    public string Password { get; set; }
    public int Age { get; set; }
    public float Weight { get; set; }
    public float Height { get; set; }

    public void UpdateProfile(int age, float weight, float height)
    {
        Age = age;
        Weight = weight;
        Height = height;
        Console.WriteLine("Profile updated successfully.");
    }
}

