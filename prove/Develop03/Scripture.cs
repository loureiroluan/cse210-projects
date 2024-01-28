public class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = InitializeWords(text);
    }

    public bool AllWordsHidden => _words.All(word => word.IsHidden);


    public void Display()
    {
        Console.WriteLine($"{_reference.ToString()}: {_GetVisibleText()}");
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = random.Next(_words.Count); 

        for (int i = 0; i < wordsToHide; i++)
        {
            int randomIndex = random.Next(_words.Count);
            _words[randomIndex].Hide();
        }
    }

    private List<Word> InitializeWords(string text)
    {
        List<Word> words = new List<Word>();
        string[] textWords = text.Split(' ');

        foreach (var wordText in textWords)
        {
            words.Add(new Word(wordText));
        }

        return words;
    }

    private string _GetVisibleText()
    {
        return string.Join(" ", _words.Select(word => word.GetDisplayText()));
    }
}
