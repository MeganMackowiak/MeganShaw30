using System;

class Scripture
{
    private Reference _reference;
    private Word[] _words;
    private Random _random;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _random = new Random();

        string[] words = text.Split(' ');
        _words = new Word[words.Length];

        for (int i = 0; i < words.Length; i++)
        {
            _words[i] = new Word(words[i]);
        }
    }

    public string GetDisplayText()
    {
        string result = _reference.GetDisplayText() + " ";

        foreach (Word word in _words)
        {
            result += word.GetDisplayText() + " ";
        }

        return result.Trim();
    }

    public void HideRandomWords(int numberToHide)
    {
        int hidden = 0;

        while (hidden < numberToHide && !IsCompletelyHidden())
        {
            int index = _random.Next(_words.Length);

            if (!_words[index].IsHidden())
            {
                _words[index].Hide();
                hidden++;
            }
        }
    }

    public bool IsCompletelyHidden()
    {
        foreach (Word word in _words)
        {
            if (!word.IsHidden())
            {
                return false;
            }
        }

        return true;
    }
}