using System.Runtime.CompilerServices;

public class Journal
{
   public List<Entry> _entries;

   public Journal()
   {
      _entries = new List<Entry>();
   }
   public void AddEntry(Entry newEntry)
   {
      _entries.Add(newEntry);
   }
   public void DisplayAll()
   {
      if (_entries.Count == 0)
      {
         Console.WriteLine("No entries in the journal");
      }
      else
      {
         foreach (var entry in _entries)
         {
            entry.Display();
            Console.WriteLine("----------------------");
         }
      }
   }
   public void SaveToFile(string file)
   {
      using(StreamWriter writer = new StreamWriter(file))
      {
         foreach (var entry in _entries)
         {
            writer.WriteLine($"{entry._date} | {entry._promptText} | {entry._entryText}");
         }
      }

   }
   public void LoadFromFile(string file)
   {
     _entries.Clear();
     try
     {
         using (StreamReader reader = new StreamReader(file))
         {
            while (!reader.EndOfStream)
            {
               string[] parts = reader.ReadLine().Split('|');
               string date = parts[0].Trim();
               string promptText = parts[1].Trim();
               string entryText = parts[2].Trim();

               Entry entry = new Entry(date, promptText, entryText);
               _entries.Add(entry); 
            }
         }
      }
      catch (FileNotFoundException)
      {
         Console.WriteLine($"File '{file}' not found.");
      }
   }

}