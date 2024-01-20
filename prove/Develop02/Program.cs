using System;

class ProgramTo //To exceed the requirements I added an error message 
//when the user types a wrong file name 
//and added five more questions to the user
{
    static void ShowMenu()
    {
        Console.WriteLine("1. Add an entry");
        Console.WriteLine("2. Display journal");
        Console.WriteLine("3. Save to file");
        Console.WriteLine("4. Load from file");
        Console.WriteLine("5. Exit");
        Console.Write("Enter your choice (1-5): ");
    }

static void Main(string[] args)
{
    Journal theJournal = new Journal();
    PromptGenerator promptGenerator = new PromptGenerator();

    Console.WriteLine("Welcome to the Journal Program!");

    while (true)
    {
        ShowMenu();

        string choice = Console.ReadLine();

        switch (choice)
        {
                case "1":
                    string randomPrompt = promptGenerator.GetRandomPrompt();
                    Console.WriteLine($"{randomPrompt}");
                    Console.Write("Your response: ");
                    string entryText = Console.ReadLine();

                    Entry newEntry = new Entry();
                    newEntry._promptText = randomPrompt;
                    newEntry._entryText = entryText;

                    theJournal.AddEntry(newEntry);
                    Console.WriteLine("Added successfully!");
                    break;

                case "2":
                    Console.WriteLine("\nJournal Entries:");
                    theJournal.DisplayAll();
                    break;

                case "3":
                    Console.Write("Enter the filename to save the journal: ");
                    string saveFilename = Console.ReadLine();
                    
                    if (File.Exists(saveFilename))
                    {
                    theJournal.SaveToFile(saveFilename);
                    Console.WriteLine("Saved successfully!");
                    }
                    else
                    {
                        Console.WriteLine($"Error: File '{saveFilename}' not found.");
                    }
                    break;

                case "4":
                    Console.Write("Enter the filename to load the journal: ");
                    string loadFilename = Console.ReadLine();
                    theJournal.LoadFromFile(loadFilename);
                    Console.WriteLine("Loaded successfully!");
                    break;

                case "5":
                    Environment.Exit(0);
                    break;

                default:
                    Console.WriteLine("Please enter a number between 1 and 5.");
                    break;
            }
        Console.WriteLine("\nPress Enter to continue...");
        Console.ReadLine();
        Console.Clear();
    }
}
}
