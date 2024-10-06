using System;


class Word
{
    private string _word;
    private bool _isHidden;

    public Word(string word)
    {
        _word = word;
        _isHidden = false;
    }

    public void HideWord()
    {
        _isHidden = true;
    }

    public void UnHideWord()
    {
        _isHidden = false;
    }
    public bool GetHideValue()
    {
        return _isHidden;
    }

    public string DisplayWord()
    {
        return _isHidden ? new string('_', _word.Length) : _word;
    }
}
