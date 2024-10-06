using System;
using System.Runtime.CompilerServices;
class Scripture
{
    public Reference _reference;
    public List<Word> _scriptureWords;
    //public int hiddenCount = 0;
    public bool _memorized = false;
    public Scripture(bool memorized, Reference reference, string scriptureText)
    {
        _memorized = memorized;
        _reference = reference;
        _scriptureWords = new List<Word>();

        foreach (var word in scriptureText.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries))
        {
            _scriptureWords.Add(new Word(word));
        }
    }

    public void unHideWords()
    {
        foreach (var word in _scriptureWords)
        {
            word.UnHideWord();
        }
    }
    public void HideWords(int numberToHide)
    {
        Random random = new Random();
        int wordsToHide = numberToHide;

        // Ensure words are not hidden if they've already been hidden
        while (wordsToHide > 0 && _scriptureWords.Any(w => !w._isHidden))
        {
            int index = random.Next(_scriptureWords.Count);

            // Only hide the word if it's not already hidden
            if (!_scriptureWords[index]._isHidden)
            {
                _scriptureWords[index].HideWord();
                wordsToHide--;
            }

            // If all words are hidden, stop the loop
            if (_scriptureWords.All(w => w._isHidden))
            {
                Console.WriteLine("All words are hidden!");
                break;
            }
        }
    }


    public string DisplayScripture()
    {
        List<string> wordsToDisplay = new List<string>();
        foreach (var word in _scriptureWords)
        {
            wordsToDisplay.Add(word.DisplayWord());
        }
        return $"Memorized: {_memorized.ToString()} - {_reference.Displaytext()} {string.Join(" ", wordsToDisplay)}";
    }

    public string GetScriptureText()
    {
        return string.Join(" ", _scriptureWords.Select(w => w.DisplayWord()));
    }
}
